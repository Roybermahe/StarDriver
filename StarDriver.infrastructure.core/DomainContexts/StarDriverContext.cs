using Microsoft.EntityFrameworkCore;
using StarDriver.domain.core.Business.Exams;
using StarDriver.domain.core.Business.Persons;
using StarDriver.infrastructure.core.Base;

namespace StarDriver.infrastructure.core.DomainContexts
{
    public class StarDriverContext: DomainContextBase
    {
        public StarDriverContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<QExamAnswers> ExamAnswerses { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<OnlyAnswer> OnlyAnswers { get; set; }
        public DbSet<MultipleChoice> MultipleChoices { get; set; }
        public DbSet<Open> Opens { get; set; }
        
        public DbSet<Person> Persons { get; set; }
        public DbSet<Apprentice> Apprentices { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
    }
}