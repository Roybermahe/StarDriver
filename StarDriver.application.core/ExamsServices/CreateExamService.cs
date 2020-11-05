using System.ComponentModel.DataAnnotations;
using StarDriver.domain.core.Business.Exams;
using StarDriver.domain.core.Contracts;

namespace StarDriver.application.core.ExamsServices
{
    public class CreateExamService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateExamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ExamCreateResponse Ejecutar(CreateExamRequest request)
        {
            var exam = request.Map();
            if (!exam.ValidateDates()) return new ExamCreateResponse() {Message = "La fecha de finalización debe ser posterior o igual a la fecha de realización."};
            _unitOfWork.ExamRepository.Add(exam);
            _unitOfWork.Commit();
            return new ExamCreateResponse() { Message = "El examen fue creado con exito."};
        }
        
    }

    public class CreateExamRequest
    {
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
            return new Exam(Tittle, Description, new MyDate(DateRealization), new MyDate(DateFinish));
        }
    }
    
    public class ExamCreateResponse
    {
        public string Message { get; set; }
    }
}