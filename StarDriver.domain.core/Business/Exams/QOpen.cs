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

        public override bool ValidateResponse(QExamAnswers answers)
        {
            answers.ScoreAnswer = Score;
            return true;
        }
    }
}