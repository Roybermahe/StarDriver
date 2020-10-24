using System.Collections.Generic;

namespace StarDriver.domain.core
{
    public class QExamAnswers
    {
        private int Identification { get; set; }
        private Apprentice Apprentice { get; }
        private Exam Exam { get; }

        public QExamAnswers(int identification,Apprentice apprentice, Exam exam)
        {
            Identification = identification;
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

        public int Id()
        {
            return Identification;
        }
    }
}