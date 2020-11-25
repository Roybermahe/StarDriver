using System.Collections.Generic;
using StarDriver.domain.core.Contracts;

namespace StarDriver.domain.core.Business.Exams
{
    public class OnlyAnswer: Question
    {
        public OnlyAnswer(string content, decimal score, string optionalImage = "", string options = "", string answer = "", string type = "OnlyAnswer") : base(content, score, optionalImage, options, answer, type)
        {
        }

        public OnlyAnswer()
        {
        }

        public override bool ValidateResponse(QExamAnswers answers)
        {
            var validate = StringOperations.IsEqual(answers.UserResponse, Answer);
            answers.ScoreAnswer =  validate ? Score : 0m;
            return validate;
        }
    }
}