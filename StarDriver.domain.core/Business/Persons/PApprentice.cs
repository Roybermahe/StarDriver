using System.Collections.Generic;
using StarDriver.domain.core.Business.Exams;

namespace StarDriver.domain.core.Business.Persons
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