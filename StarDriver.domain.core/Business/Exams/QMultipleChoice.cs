using System.Collections.Generic;
using StarDriver.domain.core.Contracts;

namespace StarDriver.domain.core.Business.Exams
{
    public class MultipleChoice : Question
    {
        private List<string> _possibleAnswer; 
        private readonly List<string> _userResponse = new List<string>();

        public MultipleChoice(string content, decimal score, string optionalImage = "", string options = "", string answer = "", string type = "MultipleChoice") : base(content, score, optionalImage, options, answer, type)
        {
        }

        public override string AddResponse(string response = "")
        {
            if(StringOperations.IsEmpty(response)) return "No se admite una respuesta vacia.";
            foreach (var responses in StringOperations.Split(response))
            {
                _userResponse.Add(responses);
            }
            return "Respuesta añadida";
        }

        public override bool ValidateResponse()
        {
            _possibleAnswer = (List<string>) StringOperations.Split(Options); 
            var totalCount = 0;
            _userResponse.ForEach(delegate(string resp)
            {
                totalCount = _possibleAnswer.Contains(resp) ? (totalCount + 1) : totalCount;
            });
            var validate = totalCount == _possibleAnswer.Count;
            ScoreAnswer = validate ? Score : (Score / _possibleAnswer.Count) * totalCount;
            return validate;
        }
    }
}