using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using StarDriver.domain.core.Contracts;

namespace StarDriver.application.core.QuestionsServices
{
    public class AddQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddQuestionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }

    public class CreateQuestionRequest
    {
        [Required]
        public string Content { get; set; }
        [Required]
        public decimal Score { get; set; }
        public string OptionalImage { get; set; }
        public string Options { get; set; }
        public string Answer { get; set; }
        [Required]
        public string Type { get; set; }
    }
}