using System;

namespace StarDriver.domain.core
{
    public class Open : Question
    {
        public string Answer { get; set; }
        
        public Open(int identification, string content, decimal score, string optionalImage) : base(identification, content, score, optionalImage)
        {
            Answer = String.Empty;
        }
    }
}