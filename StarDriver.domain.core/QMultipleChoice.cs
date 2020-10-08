using System.Collections.Generic;

namespace StarDriver.domain.core
{
    public class MultipleChoice : Question
    {
        public readonly List<string> Options;
        public readonly List<string> PossibleAnswer;
        
        public MultipleChoice(int identification, string content, decimal score, string optionalImage, List<string> options, List<string> possibleAnswer) : base(identification, content, score, optionalImage)
        {
            Options = options;
            PossibleAnswer = possibleAnswer;
        }
    }
}