using System.ComponentModel.DataAnnotations;
using StarDriver.domain.core.Contracts;

namespace StarDriver.application.core.QuestionsServices
{
    public class DeleteQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteQuestionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public DelQuestionResponse Ejecutar(DelQuestionRequest request)
        {
            var question = _unitOfWork.QuestionRepository.Find(request.IdQuestion);
            if(question == null) return new DelQuestionResponse() {Message = "Esta pregunta no existe"};
            var exam = _unitOfWork.ExamRepository.Find(request.IdExam);
            if( exam == null) return new DelQuestionResponse() { Message = "Este examen no existe" };
            var result = exam.DeleteQuestion(question);
            _unitOfWork.ExamRepository.Edit(exam);
            _unitOfWork.QuestionRepository.Delete(question);
            _unitOfWork.Commit();
            return new DelQuestionResponse() { Message = result };
        }
    }

    public class DelQuestionRequest
    { 
       [Required(ErrorMessage = "Se necesita el Id del examen para realizar esta operacion")]
       public int IdExam { get; set; }
       [Required(ErrorMessage = "Se necesita el Id de la pregunta para realizar esta operación")]
       public int IdQuestion { get; set; }
    }

    public class DelQuestionResponse
    {
        public string Message { get; set; }
    }
}