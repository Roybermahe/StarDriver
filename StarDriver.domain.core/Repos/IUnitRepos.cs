namespace StarDriver.domain.core.Repos
{
    public interface IUnitRepos
    {
        IExamRepository ExamRepository { get; }
        IDevPlanRepository DevPlanRepository { get; }
        IExamsAnswerRepository ExamsAnswerRepository { get; }
        IPersonsRepository PersonsRepository { get; }
        IQuestionRepository QuestionRepository { get; }
        IMainThemeRepository MainThemeRepository { get; }
        IRoomRepository RoomRepository { get; }
    }
}