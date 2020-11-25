using System;
using StarDriver.domain.core.Base;

namespace StarDriver.domain.core.Business.Exams
{
    public abstract class Question : Entity<int>
    {
        public string Content { get; set; }
        public decimal Score { get; set; }
        public string OptionalImage { get; set; }
        public string Options { get; set; }
        public string Answer { get; set; }
        public string Type { get; set; }
        
        public Question() {}

        public Question(string content, decimal score, string optionalImage = "",  string options = "", string answer = "", string type = "")
        {
            Content = content;
            Score = score;
            OptionalImage = optionalImage;
            Options = options;
            Answer = answer;
            Type = type;
        }
        
        public abstract bool ValidateResponse(QExamAnswers answers);
    }
}