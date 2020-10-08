namespace StarDriver.domain.core
{
    public class Open : Question
    {
        private readonly string _answer;
        
        public Open(int identification, string content, decimal score, string optionalImage, string answer) : base(identification, content, score, optionalImage)
        {
            _answer = answer;
        }
    }
}