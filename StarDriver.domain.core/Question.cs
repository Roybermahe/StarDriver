namespace StarDriver.domain.core
{
    public abstract class Question
    {
        private int Identification { get; }
        public string Content { get; }
        public decimal Score { get; }
        public string OptionalImage { get; }

        protected Question(int identification, string content, decimal score, string optionalImage)
        {
            Identification = identification;
            Content = content;
            Score = score;
            OptionalImage = optionalImage;
        }
    }
}