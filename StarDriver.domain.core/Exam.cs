using System.Collections.Generic;
using StarDriver.domain.core.Contracts;

namespace StarDriver.domain.core
{
    public class Exam
    {
        private int Identification { get; set; }
        private string Tittle { get; set; }
        private string Description { get; set; }
        private readonly List<Question> _questions;
        private IDates DateRealization { get; set; }
        private IDates DateFinish { get; set; }

        public Exam(int identification, string tittle, string description, IDates dateRealization, IDates dateFinish)
        {
            Identification = identification;
            Tittle = tittle;
            Description = description;
            DateRealization = dateRealization;
            DateFinish = dateFinish;
            _questions = new List<Question>();
        }

        public string AddQuestion(Question question)
        {
            _questions.Add(question);
            return "Se agrego la pregunta al examen";
        }
    }
}