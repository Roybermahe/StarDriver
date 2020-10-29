using System;
using StarDriver.domain.core.Base;

namespace StarDriver.domain.core.Business.Exams
{
    public abstract class Question : Entity<int>
    {
        public string Content { get; set; }
        public decimal Score { get; set; }
        public string OptionalImage { get; set; }
        public decimal ScoreAnswer { get; set; }
        public string Options { get; set; }
        public string Answer { get; set; }
        public string Type { get; set; }

        protected Question() {}

        protected Question(string content, decimal score, string optionalImage = "",  string options = "", string answer = "", string type = "")
        {
            Content = content;
            Score = score;
            OptionalImage = optionalImage;
            ScoreAnswer = score;
            Options = options;
            Answer = answer;
            Type = type;
        }

        public abstract string AddResponse(string response = "");
        public abstract bool ValidateResponse();
    }
}