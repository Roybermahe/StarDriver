using System.Collections.Generic;
using StarDriver.domain.core.Contracts;

namespace StarDriver.domain.core.Business.Exams
{
    public class OnlyAnswer: Question
    {
        
        public string UserAnswer { get; private set; }

        public OnlyAnswer(string content, decimal score, string optionalImage = "", string options = "", string answer = "", string type = "OnlyAnswer") : base(content, score, optionalImage, options, answer, type)
        {
        }

        public override string AddResponse(string response = "")
        {
            if (StringOperations.IsEmpty(response)) return "No se admite una respuesta vacia.";
            UserAnswer = response;
            return "Respuesta añadida";
        }

        public override bool ValidateResponse()
        {
            var validate = StringOperations.IsEqual(UserAnswer, Answer);
            ScoreAnswer =  validate ? Score : 0m;
            return validate;
        }
    }
}