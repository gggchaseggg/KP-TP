export type AnswerTypes = {
  id: number;
  text: string;
  isCorrect: boolean;
}

export type QuestionTypes = {
  id: number;
  question: string;
  answers: AnswerTypes[];
}

export type TestTypes = {
  id: number;
  theme: string;
  questions: QuestionTypes[];
}

export type CoursesTypes = {
  id: number;
  title: string;
  tests: TestTypes[];
  teacher: string;
}

export type CourseInProfileTypes = {
  id: number;
  title: string;
  tests: null;
  teacher: string;
}