using System.Collections.Generic;
using StarDriver.domain.core.Business.Exams;

namespace StarDriver.domain.core.Business.Persons
{
    public class Apprentice : Person
    {
        private List<QExamAnswers> ExamAnswerses;

        public Apprentice(int id, string name, string surname,  string phone, string mail, string direction)
        {
            ExamAnswerses = new List<QExamAnswers>();
            Id = id;
            Name = name;
            Surname = surname;
            Phone = phone;
            Mail = mail;
            Direction = direction;  
        }

        public string AddExamAnswers(QExamAnswers examAnswers)
        {
            if (examAnswers.GetExam().TotalScores() == 0m) return "El examen no contiene preguntas";
            ExamAnswerses.Add(examAnswers);
            return "Se agrego un examen respondido.";
        }

        public Exam GetExamAnswers(int id)
        {
            return ExamAnswerses.Find(t => t.Id == id)?.GetExam();
        }
    }
}