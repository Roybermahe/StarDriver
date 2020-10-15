using System;
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
            if (StringOperations.IsEmpty(question.Content)) return "No se permite una Pregunta sin contenido";
            _questions.Add(question);
            return "Se agrego la pregunta al examen";
        }

        public decimal TotalScores()
        {
            var total = 0m;
            _questions.ForEach(delegate(Question question)
            {
                total += question.Score;
            });
            return total;
        }

        public string RespondQuestion(int IdQuestion, string respond)
        {
            
            return GetQuestion(IdQuestion)?.AddResponse(respond);
        }

        public decimal ExamResult()
        {
            var total = 0m;
            _questions.ForEach(delegate(Question question)
            {
                question.ValidateResponse();
                total += question.ScoreAnswer;
            });
            return total;
        }

        public string ModifyScoreAnswer(int idPregunta, decimal scorePoints)
        {
            var question = GetQuestion(idPregunta);
            if (scorePoints > question.Score) return "Los puntos de respuesta no pueden ser mayor al puntaje total";
            GetQuestion(idPregunta).ScoreAnswer = scorePoints;
            return "Se modificó los puntos de esta pregunta";
        }
        
        private Question GetQuestion(int IdQuestion)
        {
            return _questions.Find(t => t.Identification == IdQuestion);
        }
    }
}