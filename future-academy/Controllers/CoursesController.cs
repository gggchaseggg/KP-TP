using future_academy.Contexts;
using future_academy.Models;
using future_academy.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace future_academy.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CoursesController : ControllerBase
    {
        private readonly UniversityContext _context;

        public CoursesController(UniversityContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Course> getCourse() {
            return _context.Courses
                .Include(c => c.tests)
                .ThenInclude(t => t.questions)
                .ThenInclude(q => q.answers)
                .ToList();
        }

        [HttpGet("{id}")]
        public Course getCourseById(int id)
        {
            var cookieLogin = HttpContext.Request.Cookies["login"];
            if (cookieLogin == null) {
                return _context.Courses
                    .Where(c => c.id == id)
                    .Include(c => c.tests.Where(t => t.endDate > DateTime.Now && t.isAvailable))
                    .OrderBy(c => c.id)
                    .First();
            }
            else {
                var student = _context.Students.Where(s => s.account.login == cookieLogin).OrderBy(s => s.id).First();
                return _context.Courses
                    .Where(c => c.id == id)
                    .Include(c => c.tests.Where(t => t.endDate > DateTime.Now && t.isAvailable && !t.passedStudents.Contains(student)))
                    .OrderBy(c => c.id)
                    .First();
            }
        }

        [HttpGet("toprofilepage")]
        public List<Course> getCourseToProfile() {
            return _context.Courses.ToList();
        }


        [HttpGet("testbyid/{id}")]
        public Test getTestById(int id)
        {
            return _context.Tests
                .Where(t => t.id == id)
                .Include(t => t.questions)
                .ThenInclude(t => t.answers)
                .OrderBy(c => c.id)
                .First();
        }

        [HttpPost("test")]
        public int getTestGrade(Dictionary<string, List<string>> test)
        {
            int testId;
            try { testId = Int32.Parse(test["testId"][0]); }
            catch (ArgumentNullException) { return 0; }
            
            var DBTest = _context.Tests.Where(t => t.id == testId)
                .Include(t => t.passedStudents).Include(t => t.questions).ThenInclude(q => q.answers)
                .OrderBy(t => t.id).First();

            var correctTest = new Dictionary<string, List<string>>();

            int correctQuestionCount = 0;

            foreach (var _question in DBTest.questions) {
                correctTest.Add(_question.id.ToString(), new List<string>());
                foreach (var _answer in _question.answers) {
                    if (_answer.isCorrect) correctTest[_question.id.ToString()].Add(_answer.id.ToString());
                    else correctTest[_question.id.ToString()].Add("");
                }
                if (correctTest[_question.id.ToString()].SequenceEqual(test[_question.id.ToString()])) correctQuestionCount++;
            }

            var account = _context.Accounts.Where(a => a.login == test["userLogin"][0]).OrderBy(a => a.id).First();
            account.score += (int)Math.Round((double)correctQuestionCount / correctTest.Count * 100);
            var student = _context.Students
                .Where(s => s.account == account)
                .OrderBy(s => s.id)
                .First();

            DBTest.passedStudents.Add(student);
            _context.SaveChanges();

            return account.score;
        }
    }
}
