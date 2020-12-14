using System.Linq;
using Microsoft.EntityFrameworkCore;
using StarDriver.domain.core.Business.Exams;
using StarDriver.domain.core.Repos;
using StarDriver.infrastructure.core.Base;

namespace StarDriver.infrastructure.core.Repos
{
    public class ExamRepository : GenericRepository<Exam>, IExamRepository
    {
        public ExamRepository(IDbContext context) : base(context)
        {
        }
        
        public Exam getAllData(int id)
        {
            return _dbset.Include(x => x.Questions).Single(y => y.Id == id);
        }
        
    }
}