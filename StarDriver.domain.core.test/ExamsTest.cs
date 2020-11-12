using System.Collections.Generic;
using NUnit.Framework;
using StarDriver.domain.core.Business.Exams;
using StarDriver.domain.core.Business.Persons;
using StarDriver.domain.core.Contracts;

namespace StarDriver.domain.core.test
{
    public class ExamsTest
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void ExamResults()
        {
            var exam = new Exam(tittle: "Examen 1", description: "Examen de estado",dateRealization: new MyDate("01/09/2020"),dateFinish: new MyDate("01/09/2020"));
            GetQuestions().ForEach(delegate(Question question)
            {
                exam.AddQuestion(question);
            });
            exam.RespondQuestion(new QExamAnswers() { Id = 1, PersonId = 1, QuestionId = 1, UserResponse = "Option A"});
            exam.RespondQuestion(new QExamAnswers() { Id = 2, PersonId = 1, QuestionId = 2, UserResponse = "Response"});
            exam.RespondQuestion(new QExamAnswers() { Id = 3, PersonId = 1, QuestionId = 3, UserResponse = "Option A|Option C"});
            Assert.AreEqual(exam.ExamResult(), exam.TotalScores());
        }
        
        [Test]
        public void ExamResultsResponsesFails()
        {
            var exam = new Exam(tittle: "Examen 1", description: "Examen de estado",dateRealization: new MyDate("01/09/2020"),dateFinish: new MyDate("01/09/2020"));
            GetQuestions().ForEach(delegate(Question question)
            {
                exam.AddQuestion(question);
            });
            exam.RespondQuestion(new QExamAnswers() { Id = 1, PersonId = 1, QuestionId = 1, UserResponse = "Option B"});
            exam.RespondQuestion(new QExamAnswers() { Id = 2, PersonId = 1, QuestionId = 2, UserResponse = "Response"});
            exam.RespondQuestion(new QExamAnswers() { Id = 3, PersonId = 1, QuestionId = 3, UserResponse = "Option A|Option C"});
            var result = exam.ExamResult() < exam.TotalScores();
            Assert.AreEqual(result, true);
        }

        [Test]
        public void ApprenticeDoneExam()
        {
            var apprentice = new Apprentice(identificacion: 1065630700, name: "Ana", surname: "Castillo", phone: "30227455890", mail: "ana@gmail.com", direction: "Manzana 59 Casa 13 450 años");
            var exam = new Exam(tittle: "Examen 1", description: "Examen de estado",dateRealization: new MyDate("01/09/2020"),dateFinish: new MyDate("01/09/2020"));
            GetQuestions().ForEach(delegate(Question question)
            {
                exam.AddQuestion(question);
            });
            exam.RespondQuestion(new QExamAnswers() { Id = 1, PersonId = 1, QuestionId = 1, UserResponse = "Option B"});
            exam.RespondQuestion(new QExamAnswers() { Id = 2, PersonId = 1, QuestionId = 2, UserResponse = "Response"});
            exam.RespondQuestion(new QExamAnswers() { Id = 3, PersonId = 1, QuestionId = 3, UserResponse = "Option A|Option C"});
            Assert.AreEqual("Examen respondido.", exam.ExamAnswersed());
        }
        
        [Test]
        public void GetExamResultOfApprentice()
        {
            var apprentice = new Apprentice(identificacion: 1065630700, name: "Ana", surname: "Castillo", phone: "30227455890", mail: "ana@gmail.com", direction: "Manzana 59 Casa 13 450 años");
            var exam = new Exam(tittle: "Examen 1", description: "Examen de estado",dateRealization: new MyDate("01/09/2020"),dateFinish: new MyDate("01/09/2020"));
            GetQuestions().ForEach(delegate(Question question)
            {
                exam.AddQuestion(question);
            });
            exam.RespondQuestion(new QExamAnswers() { Id = 1, PersonId = 1, QuestionId = 1, UserResponse = "Option A"});
            exam.RespondQuestion(new QExamAnswers() { Id = 2, PersonId = 1, QuestionId = 2, UserResponse = "Response"});
            exam.RespondQuestion(new QExamAnswers() { Id = 3, PersonId = 1, QuestionId = 3, UserResponse = "Option A|Option C"});
            Assert.AreEqual(exam.TotalScores(), exam.ExamResult());
        }

        private static List<Question> GetQuestions()
        {
            var options = "Option A|Option B|Option C";
            const string answer = "Option A";
            var question1 = new OnlyAnswer(
                content: "Elija una de las siguientes opciones", 
                score: 2.1m, optionalImage:"",
                answer: answer, options: options) { Id = 1};
            
            var question2 = new Open( content: "Elija una de las siguientes opciones", score: 2.7m, optionalImage: "") { Id = 2 };
            const string answerc = "Option A|Option C";
            
            var question3 = new MultipleChoice(
                content: "Elija una de las siguientes opciones", 
                score: 2.7m, optionalImage:"", 
                options: options, answer: answerc) { Id = 3};
            return new List<Question>() { question1, question2, question3 };
        }
    }
}