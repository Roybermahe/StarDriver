using Microsoft.EntityFrameworkCore;
using StarDriver.domain.core.Business.Exams;
using StarDriver.infrastructure.core.Base;

namespace StarDriver.infrastructure.core.DomainContexts
{
    public class ExamContext : DomainContextBase
    {
        public ExamContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Open> QuestionOpens { get; set; }
        public DbSet<MultipleChoice> MultipleChoices { get; set; }
        public DbSet<OnlyAnswer> OnlyAnswers { get; set; }
        //public DbSet<QExamAnswers> ExamsAnswer { get; set; }
    }
}