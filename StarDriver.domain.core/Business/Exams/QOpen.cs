using System;
using System.Collections.Generic;
using StarDriver.domain.core.Contracts;

namespace StarDriver.domain.core.Business.Exams
{
    public class Open : Question
    {
        public Open(string content, decimal score, string optionalImage = "", string options = "", string answer = "", string type = "Open") : base(content, score, optionalImage, options, answer, type)
        {
        }

        public override string AddResponse(string response = "")
        {
            if (StringOperations.IsEmpty(response)) return "No se admite una respuesta sin contenido";
            Answer = response;
            return "Respuesta añadida";
        }
        
        public override bool ValidateResponse()
        {
            return true;
        }
    }
}