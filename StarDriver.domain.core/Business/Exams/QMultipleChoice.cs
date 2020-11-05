using System.Collections.Generic;
using StarDriver.domain.core.Contracts;

namespace StarDriver.domain.core.Business.Exams
{
    public class MultipleChoice : Question
    {
        private List<string> PossibleAnswer { get; set; } 
        private List<string> UserResponse { get; set; }

        public MultipleChoice(string content, decimal score, string optionalImage = "", string options = "", string answer = "", string type = "MultipleChoice") : base(content, score, optionalImage, options, answer, type)
        {
        }
        
        public override bool ValidateResponse(QExamAnswers answers)
        {
            PossibleAnswer = StringOperations.Split(Answer);
            UserResponse = StringOperations.Split(answers.UserResponse);
            var totalCount = 0;
            UserResponse.ForEach(delegate(string resp)
            {
                totalCount = PossibleAnswer.Contains(resp) ? (totalCount + 1) : totalCount;
            });
            var validate = totalCount == PossibleAnswer.Count;
            answers.ScoreAnswer = validate ? Score : (Score / PossibleAnswer.Count) * totalCount;
            return validate;
        }
    }
}