using System;
using System.Collections.Generic;
using StarDriver.domain.core.Base;
using StarDriver.domain.core.Business.Persons;

namespace StarDriver.domain.core.Business.Exams
{
    public class QExamAnswers : Entity<int>
    {
        public int PersonId { get; set; }
        public int QuestionId { get; set; }
        public string UserResponse { get; set; }
        public decimal ScoreAnswer { get; set; }

        public QExamAnswers()
        {
            UserResponse = string.Empty;
            ScoreAnswer = 0m;
        }

        public QExamAnswers(int personId, int questionId, string userResponse, decimal scoreAnswer)
        {
            PersonId = personId;
            QuestionId = questionId;
            UserResponse = userResponse;
            ScoreAnswer = scoreAnswer;
        }
    }
}