using System.Collections.Generic;
using StarDriver.domain.core.Contracts;

namespace StarDriver.domain.core.Business.Exams
{
    public class OnlyAnswer: Question
    {
        public readonly List<string> _options;
        private readonly string _answer;
        public string UserAnswer { get; private set; }

        public OnlyAnswer(int id, string content, decimal score, string optionalImage, List<string> options, string answer) : base(id, content, score, optionalImage)
        {
            _options = options;
            _answer = answer;
            UserAnswer = string.Empty;
        }

        public override string AddResponse(string response = "")
        {
            if (StringOperations.IsEmpty(response)) return "No se admite una respuesta vacia.";
            UserAnswer = response;
            return "Respuesta añadida";
        }

        public override bool ValidateResponse()
        {
            var validate = StringOperations.IsEqual(UserAnswer, _answer);
            ScoreAnswer =  validate ? Score : 0m;
            return validate;
        }
    }
}