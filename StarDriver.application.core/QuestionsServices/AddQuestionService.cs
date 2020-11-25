using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using StarDriver.domain.core.Business.Exams;
using StarDriver.domain.core.Contracts;
using StarDriver.domain.core.Factorys.Questions;

namespace StarDriver.application.core.QuestionsServices
{
    public class AddQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddQuestionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CreateQuestionResponse Ejecutar(CreateQuestionRequest request)
        {
            var exam = _unitOfWork.ExamRepository.FindFirstOrDefault(t => t.Id == request.ExamId);
            if(exam == null) return new CreateQuestionResponse() { Message = "Este examen no existe" };
            var question = request.Map();
            var result = exam.AddQuestion(question);
            _unitOfWork.ExamRepository.Edit(exam);
            _unitOfWork.Commit();
            return new CreateQuestionResponse() { Message = result };
        }
    }

    public class CreateQuestionRequest
    {
        [Required(ErrorMessage = "Es necesario el id del examen.")]
        public int ExamId { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public decimal Score { get; set; }
        public string OptionalImage { get; set; }
        public string Options { get; set; }
        public string Answer { get; set; }
        [Required]
        public string Type { get; set; }

        public Question Map()
        {
            var question = new QuestionFactory().FactoryMethod(Type);
            question.Content = Content;
            question.Options = Options;
            question.Score = Score;
            question.OptionalImage = OptionalImage;
            question.Answer = Answer;
            return question;
        }
    }

    public class CreateQuestionResponse
    {
        public string Message { get; set; }
    }
}