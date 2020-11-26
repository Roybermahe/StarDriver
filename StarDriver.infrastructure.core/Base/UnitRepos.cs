using StarDriver.domain.core.Repos;
using StarDriver.infrastructure.core.Repos;

namespace StarDriver.infrastructure.core.Base
{
    public abstract class UnitRepos: IUnitRepos
    {
        protected IDbContext DbContext;
        
        private IExamRepository _examRepository;
        public IExamRepository ExamRepository
        {
            get { return _examRepository ??= new ExamRepository(DbContext); }
        }

        private IDevPlanRepository _devPlanRepository;
        public IDevPlanRepository DevPlanRepository
        {
            get { return _devPlanRepository ??= new DevPlanRepository(DbContext); }
        }

        private IExamsAnswerRepository _examsAnswerRepository;
        public IExamsAnswerRepository ExamsAnswerRepository
        {
            get { return _examsAnswerRepository ??= new ExamAnswerRepository(DbContext); }
        }

        private IMainThemeRepository _mainThemeRepository;
        public IMainThemeRepository MainThemeRepository
        {
            get { return _mainThemeRepository ??= new MainThemeRepository(DbContext); }
        }

        private IRoomRepository _roomRepository;

        public IRoomRepository RoomRepository
        {
            get { return _roomRepository ??= new RoomRepository(DbContext); }
        }
        
        

        private IPersonsRepository _personsRepository;
        public IPersonsRepository PersonsRepository
        {
            get { return _personsRepository ??= new PersonRepository(DbContext); }
        }

        private IQuestionRepository _questionRepository;
        public IQuestionRepository QuestionRepository
        {
            get { return _questionRepository ??= new QuestionRepository(DbContext); }
        }
    }
}