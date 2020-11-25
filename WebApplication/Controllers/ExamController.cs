using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StarDriver.application.core;
using StarDriver.application.core.ExamsServices;
using StarDriver.application.core.QuestionsServices;
using StarDriver.domain.core.Contracts;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExamController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpPost]
        public ActionResult<ExamCreateResponse> Post(CreateExamRequest request)
        {
            var service = new CreateExamService(_unitOfWork);
            var response = service.Ejecutar(request);
            return Ok(response);
        }

        [HttpPut]
        public ActionResult<UpdateExamResponse> Put(UpdateExamRequest request)
        {
            var service = new UpdateExamService(_unitOfWork);
            var response = service.Ejecutar(request);
            return Ok(response);
        }

        [HttpDelete]
        public ActionResult<DeleteExamResponse> Delete(DeleteExamRequest request)
        {
            var service = new DeleteExamService(_unitOfWork);
            var response = service.Ejecutar(request);
            return Ok(response);
        }

        [HttpGet]
        public ActionResult<GetExamResponse> Get()
        {
            var service = new GetExamService(_unitOfWork);
            var response = service.Ejecutar();
            return Ok(response);
        }
        
        [Route("GetExam")]
        [HttpGet]
        public ActionResult<GetExamResponse> GetById([FromQuery] int id)
        {
            var service = new GetExamService(_unitOfWork);
            var response = service.Ejecutar(id);
            return Ok(response);
        }

        [Route("Question")]
        [HttpPost]
        public ActionResult<CreateQuestionResponse> AddQuestion(CreateQuestionRequest request)
        {
            var service = new AddQuestionService(_unitOfWork);
            var response = service.Ejecutar(request);
            return Ok(response);
        }

        [Route("Question")]
        [HttpDelete]
        public ActionResult<DelQuestionResponse> DeleteQuestion(DelQuestionRequest request)
        {
            var service = new DeleteQuestionService(_unitOfWork);
            var response = service.Ejecutar(request);
            return Ok(response);
        }
        
        [Route("GetQuestions")]
        [HttpGet]
        public ActionResult<DelQuestionResponse> DeleteQuestion([FromQuery] int IdExam)
        {
            var service = new GetQuestionService(_unitOfWork);
            var response = service.Ejecutar(IdExam);
            return Ok(response);
        }
        
    }
}