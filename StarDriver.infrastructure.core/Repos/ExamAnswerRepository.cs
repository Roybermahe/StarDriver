using StarDriver.domain.core.Business.Exams;
using StarDriver.domain.core.Repos;
using StarDriver.infrastructure.core.Base;

namespace StarDriver.infrastructure.core.Repos
{
    public class ExamAnswerRepository: GenericRepository<QExamAnswers>, IExamsAnswerRepository
    {
        public ExamAnswerRepository(IDbContext context) : base(context)
        {
        }
    }
}