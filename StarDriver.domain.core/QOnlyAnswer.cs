using System.Collections.Generic;

namespace StarDriver.domain.core
{
    public class OnlyAnswer: Question
    {
        private readonly List<string> _options;
        private readonly string _answer;
        
        public OnlyAnswer(int identification, string content, decimal score, string optionalImage) : base(identification, content, score, optionalImage)
        {
            _options = new List<string>();
            _answer = string.Empty;
        }
    }
}