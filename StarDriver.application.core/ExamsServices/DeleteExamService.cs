using System.ComponentModel.DataAnnotations;
using StarDriver.domain.core.Business.Exams;
using StarDriver.domain.core.Contracts;

namespace StarDriver.application.core.ExamsServices
{
    public class DeleteExamService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteExamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public DeleteExamResponse Ejecutar(DeleteExamRequest request)
        {
            var exam = _unitOfWork.ExamRepository.Find(request.ExamId);
            if(exam == null) return new DeleteExamResponse() { Message = "El examen no existe."};
            _unitOfWork.ExamRepository.Delete(exam);
            _unitOfWork.Commit();
            return new DeleteExamResponse() { Message = "El examen fue eliminado."};
        }
    }

    public class DeleteExamRequest
    {
        [Required]
        public int ExamId { get; set; }

        public Exam Map()
        {
            return new Exam() { Id = ExamId};
        }
    }

    public class DeleteExamResponse
    {
        public string Message { get; set; }
    }
}