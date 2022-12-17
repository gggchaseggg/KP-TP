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
        public Course getCourse(int id)
        {
            return _context.Courses
                .Where(c => c.id == id)
                .Include(c => c.tests)
                .OrderBy(c => c.id)
                .First();
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
            int testId = Int32.Parse(test["testid"][0]);
            var DBTest = _context.Tests
                .Where(t => t.id == testId)
                .Include(t => t.questions)
                .ThenInclude(q => q.answers)
                .OrderBy(t => t.id)
                .First();

            var correctTest = new Dictionary<string, List<string>>();

            int correctQuestionCount = 0;

            foreach (var _question in DBTest.questions)
            {
                correctTest.Add(_question.id.ToString(), new List<string>());
                foreach (var _answer in _question.answers)
                {
                    if (_answer.isCorrect) correctTest[_question.id.ToString()].Add(_answer.id.ToString());
                    else correctTest[_question.id.ToString()].Add("");
                }

                if (correctTest[_question.id.ToString()].SequenceEqual(test[_question.id.ToString()])) correctQuestionCount++;
            }

            return (int)Math.Round((double)correctQuestionCount / correctTest.Count * 100);
        }
    }
}
