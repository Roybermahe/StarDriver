using System.Collections.Generic;
using StarDriver.domain.core.Business.Exams;
using StarDriver.domain.core.Contracts;

namespace StarDriver.application.core.QuestionsServices
{
    public class GetQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetQuestionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public GetQuestionsResponse Ejecutar(int Id)
        {
            var question = _unitOfWork.QuestionRepository.Find(Id);
            if (question == null) return new GetQuestionsResponse() { Message = "No existe esta pregunta"};
            return new GetQuestionsResponse()
            {
                Message = "Se encontro 1 pregunta",
                question = question
            };
        }
        
    }

    public class GetQuestionsResponse
    {
        public string Message { get; set; }
        public Question question { get; set; }
    }
}