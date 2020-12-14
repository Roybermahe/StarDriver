using System;
using System.Collections.Generic;
using StarDriver.domain.core.Base;
using StarDriver.domain.core.Contracts;


namespace StarDriver.domain.core.Business.Exams
{
    public class Exam : Entity<int>
    {
        public string Tittle { get; set; }
        public string Description { get; set; }
        public List<Question> Questions { get; set; }
        public List<QExamAnswers> Answerses { get; set; }
        private IDates _dateRealization;
        private IDates _dateFinish;

        public Exam()
        {
            Questions = new List<Question>();
            Answerses = new List<QExamAnswers>();
        }
        
        public string DateRealization
        {
            get => _dateRealization.GetTime();
            set => _dateRealization = new MyDate(value);
        }

        public string DateFinish
        {
            get => _dateFinish.GetTime();
            set => _dateFinish = new MyDate(value);
        }

        public Exam(string tittle, string description, IDates dateRealization, IDates dateFinish)
        {
            Tittle = tittle;
            Description = description;
            _dateRealization = dateRealization;
            _dateFinish = dateFinish;
            Questions = new List<Question>();
            Answerses = new List<QExamAnswers>();
        }

        public string AddQuestion(Question question)
        {
            if (StringOperations.IsEmpty(question.Content)) return "No se permite una Pregunta sin contenido";
            Questions.Add(question);
            return "Se agrego la pregunta al examen";
        }

        public string DeleteQuestion(Question question)
        {
            if (GetQuestionResponse(question.Id)) return "No se puede eliminar una pregunta que ya tiene respuestas";
            Questions.Remove(GetQuestion(question.Id));
            return "La pregunta fue eliminada del examen";
        }

        public string ExamAnswersed()
        {
            return Answerses.Count == Questions.Count ? "Examen respondido." : "Examen no completado.";
        }

        public decimal TotalScores()
        {
            var total = 0m;
            Questions.ForEach(delegate(Question question)
            {
                total += question.Score;
            });
            return total;
        }

        public string RespondQuestion(QExamAnswers qExamAnswers)
        {
            if (StringOperations.IsEmpty(qExamAnswers.UserResponse)) return "No se admite una respuesta vacia.";
            Answerses.Add(qExamAnswers);
            return "Respuesta Añadida.";
        }

        public decimal ExamResult()
        {
            var total = 0m;
            Answerses.ForEach(delegate(QExamAnswers answers)
            {
                if (GetQuestion(answers.QuestionId).ValidateResponse(answers))
                {
                    total += answers.ScoreAnswer;
                    
                }
            });
            return total;
        }

        public string ModifyScoreAnswer(QExamAnswers examAnswers, decimal scorePoints)
        {
            var question = GetQuestion(examAnswers.QuestionId);
            if (scorePoints > question.Score) return "Los puntos de respuesta no pueden ser mayor al puntaje total";
            var answer = Answerses.Find(t => t.Id == examAnswers.Id);
            if (answer != null) answer.ScoreAnswer = scorePoints;
            return "Se modificó los puntos de esta pregunta";
        }

        public bool ValidateDates()
        {
            return _dateFinish.CompareTo(DateRealization) >= 0;
        }
        
        private Question GetQuestion(int idQuestion)
        {
            return Questions.Find(t => t.Id == idQuestion);
        }

        private bool GetQuestionResponse(int idQuestion)
        {
            return Answerses.FindAll(t => t.QuestionId == idQuestion).Count > 0;
        }
        
    }
}