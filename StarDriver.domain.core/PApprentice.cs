using System.Collections.Generic;

namespace StarDriver.domain.core
{
    public class Apprentice
    {
        private List<QExamAnswers> ExamAnswerses;

        public Apprentice()
        {
            ExamAnswerses = new List<QExamAnswers>();
        }

        public string AddExamAnswers(QExamAnswers examAnswers)
        {
            if (examAnswers.GetExam().TotalScores() == 0m) return "El examen no contiene preguntas";
            ExamAnswerses.Add(examAnswers);
            return "Se agrego un examen respondido.";
        }

        public Exam GetExamAnswers(int id)
        {
            return ExamAnswerses.Find(t => t.Id() == id)?.GetExam();
        }
    }
}