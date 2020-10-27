using System.Collections.Generic;
using StarDriver.domain.core.Base;
using StarDriver.domain.core.Business.Persons;

namespace StarDriver.domain.core.Business.Exams
{
    public class QExamAnswers : Entity<int>
    {
        private Apprentice Apprentice { get; }
        private Exam Exam { get; }

        public QExamAnswers(int id,Apprentice apprentice, Exam exam)
        {
            Id= id;
            Apprentice = apprentice;
            Exam = exam;
        }

        public Exam GetExam()
        {
            return Exam;
        }

        public Apprentice GetApprentice()
        {
            return Apprentice;
        }

        /*public int Id()
        {
            return Identification;
        }*/
    }
}