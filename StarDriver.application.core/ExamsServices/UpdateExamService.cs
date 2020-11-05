using System.ComponentModel.DataAnnotations;
using StarDriver.domain.core.Business.Exams;
using StarDriver.domain.core.Contracts;

namespace StarDriver.application.core.ExamsServices
{
    public class UpdateExamService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateExamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public UpdateExamResponse Ejecutar(UpdateExamRequest request)
        {
            var exam = request.Map();
            if (!exam.ValidateDates()) return new UpdateExamResponse() {Message = "La fecha de finalización debe ser posterior o igual a la fecha de realización."};
            _unitOfWork.ExamRepository.Edit(exam);
            _unitOfWork.Commit();
            return new UpdateExamResponse() { Message = "El examen fue actualizado."};
        }
    }
    
    public class UpdateExamRequest
    {
        [Required(ErrorMessage = "Es necesario el Id del examen.")]
        public int ExamId { get; set; }
        [Required(ErrorMessage ="El titulo es un campo requerido")]
        public string Tittle { get; set; }
        [Required]
        public  string Description { get; set; }

        [Required(ErrorMessage = "Las fechas deben ser en formato 'DD/MM/YYYY' o algunos de los formatos para fechas de .Net core")]
        public string DateRealization { get; set; }

        [Required(ErrorMessage = "Las fechas deben ser en formato 'DD/MM/YYYY' o algunos de los formatos para fechas de .Net core")]
        public string DateFinish { get; set; }

        public Exam Map()
        {
            return new Exam(Tittle, Description, new MyDate(DateRealization), new MyDate(DateFinish)) { Id = ExamId };
        }
    }
    
    public class UpdateExamResponse
    {
        public string Message { get; set; }
    }
}