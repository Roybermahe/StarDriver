using System.Collections.Generic;
using StarDriver.domain.core.Base;

namespace StarDriver.domain.core
{
    public abstract class Question : Entity<int>
    {
        
        
        public string Content { get; }
        public decimal Score { get; }
        public string OptionalImage { get; }
        public decimal ScoreAnswer { get; set; }

        protected Question(int id, string content, decimal score, string optionalImage)
        {
            Id = id;
            Content = content;
            Score = score;
            OptionalImage = optionalImage;
            ScoreAnswer = Score;
        }

        public abstract string AddResponse(string response = "");
        public abstract bool ValidateResponse();
    }
}