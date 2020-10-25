using System;
using System.Collections.Generic;
using StarDriver.domain.core.Contracts;

namespace StarDriver.domain.core
{
    public class Open : Question
    {
        public string Answer { get; set; }
        
        public Open(int identification, string content, decimal score, string optionalImage) : base(identification, content, score, optionalImage)
        {
            Answer = string.Empty;
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