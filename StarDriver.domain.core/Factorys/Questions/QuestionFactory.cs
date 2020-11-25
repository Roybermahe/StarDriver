using StarDriver.domain.core.Business.Exams;

namespace StarDriver.domain.core.Factorys.Questions
{
    public class QuestionFactory : IFactoryGeneric<Question>
    {
        public Question FactoryMethod(string type)
        {
            Question factory = type switch
            {
                "Open" => new Open() { Type = type},
                "MultipleChoice" => new MultipleChoice() { Type = type},
                "OnlyAnswer" => new OnlyAnswer() { Type = type},
                _ => null
            };
            return factory;
        }
    }
}