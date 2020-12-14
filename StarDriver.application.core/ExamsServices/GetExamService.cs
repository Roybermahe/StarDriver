using System.Collections.Generic;
using System.Linq;
using StarDriver.domain.core.Business.Exams;
using StarDriver.domain.core.Contracts;
using StarDriver.infrastructure.core.Repos;

namespace StarDriver.application.core.ExamsServices
{
    public class GetExamService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetExamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public GetExamResponse Ejecutar()
        {
            var list = _unitOfWork.ExamRepository.GetAll().ToArray();
            return !list.Any() ? 
                new GetExamResponse("No se encontro ningun examen.") : 
                new GetExamResponse($"Se encontraron {list.Count()} examenes.", examlist: list);
        }
        
        public GetExamResponse Ejecutar(int id)
        {
            var exam = ((ExamRepository) _unitOfWork.ExamRepository).getAllData(id);
            return exam == null ? 
                new GetExamResponse("No se encontro el examen") : 
                new GetExamResponse($"El examen {exam.Id} fue encontrado.", exam: exam);
        }

    }
    
    public class GetExamResponse
    {
        public string Message { get; }
        public object Exam { get; }
        public IEnumerable<object> Examlist { get; }

        public GetExamResponse(string message, IEnumerable<object> examlist = null, object exam = null)
        {
            Message = message;
            Exam = exam;
            Examlist = examlist;
        }
    }
}