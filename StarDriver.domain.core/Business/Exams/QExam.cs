using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using StarDriver.domain.core.Base;
using StarDriver.domain.core.Contracts;

namespace StarDriver.domain.core.Business.Exams
{
    public class Exam : Entity<int>
    {
        public Exam()
        {
            _questions = new List<Question>();
        }
        
        public string Tittle { get; set; }
        public string Description { get; set; }
        public List<Question> _questions { get; set; }
        private readonly IDates _dateRealization;
        private readonly IDates _dateFinish;

        public string DateRealization
        {
            get => _dateRealization.GetTime();
            set => _dateRealization.SetTime(value);
        }

        public string DateFinish
        {
            get => _dateFinish.GetTime();
            set => _dateFinish.SetTime(value);
        }

        public Exam(int id, string tittle, string description, IDates dateRealization, IDates dateFinish)
        {
            Id = id;
            Tittle = tittle;
            Description = description;
            _dateRealization = dateRealization;
            _dateFinish = dateFinish;
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

        public string RespondQuestion(int idQuestion, string respond)
        {
            return GetQuestion(idQuestion)?.AddResponse(respond);
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
            return _questions.Find(t => t.Id == IdQuestion);
        }
    }
}