using System.Collections.Generic;
using StarDriver.domain.core.Contracts;

namespace StarDriver.domain.core
{
    public class MultipleChoice : Question
    {
        public readonly List<string> Options;
        public readonly List<string> PossibleAnswer;
        public List<string> UserResponse { get; private set; }
        
        public MultipleChoice(int identification, string content, decimal score, string optionalImage, List<string> options, List<string> possibleAnswer) : base(identification, content, score, optionalImage)
        {
            Options = options;
            PossibleAnswer = possibleAnswer;
            UserResponse = new List<string>();
        }

        public override string AddResponse(string response = "")
        {
            if(StringOperations.IsEmpty(response)) return "No se admite una respuesta vacia.";
            foreach (var responses in StringOperations.Split(response))
            {
                UserResponse.Add(responses);
            }
            return "Respuesta añadida";
        }

        public override bool ValidateResponse()
        {
            var totalCount = 0;
            UserResponse.ForEach(delegate(string resp)
            {
                totalCount = PossibleAnswer.Contains(resp) ? (totalCount + 1) : totalCount;
            });
            var validate = totalCount == PossibleAnswer.Count;
            ScoreAnswer = validate ? Score : (Score / PossibleAnswer.Count) * totalCount;
            return validate;
        }
    }
}