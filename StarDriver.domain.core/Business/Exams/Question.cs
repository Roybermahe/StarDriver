namespace StarDriver.domain.core.Business.Exams
{
    public abstract class Question
    {
        public int Identification { get; }
        public string Content { get; }
        public decimal Score { get; }
        public string OptionalImage { get; }
        public decimal ScoreAnswer { get; set; }

        protected Question(int identification, string content, decimal score, string optionalImage)
        {
            Identification = identification;
            Content = content;
            Score = score;
            OptionalImage = optionalImage;
            ScoreAnswer = Score;
        }

        public abstract string AddResponse(string response = "");
        public abstract bool ValidateResponse();
    }
}