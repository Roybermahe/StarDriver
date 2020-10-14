using System.Collections.Generic;

namespace StarDriver.domain.core
{
    public class OnlyAnswer: Question
    {
        public readonly List<string> _options;
        private readonly string _answer;
        
        public OnlyAnswer(int identification, string content, decimal score, string optionalImage, List<string> options, string answer) : base(identification, content, score, optionalImage)
        {
            _options = options;
            _answer = answer;
        }
    }
}