using System.Collections.Generic;
using NUnit.Framework;
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
            var exam = new Exam(id: 1, tittle: "Examen 1", description: "Examen de estado",dateRealization: new MyDate("01/09/2020"),dateFinish: new MyDate("01/09/2020"));
            GetQuestions().ForEach(delegate(Question question)
            {
                exam.AddQuestion(question);
            });
            exam.RespondQuestion(1, "Option A");
            exam.RespondQuestion(2, "Response");
            exam.RespondQuestion(3, "Option A|Option C");
            Assert.AreEqual(exam.ExamResult(), exam.TotalScores());
        }
        
        [Test]
        public void ExamResultsResponsesFails()
        {
            var exam = new Exam(id: 1, tittle: "Examen 1", description: "Examen de estado",dateRealization: new MyDate("01/09/2020"),dateFinish: new MyDate("01/09/2020"));
            GetQuestions().ForEach(delegate(Question question)
            {
                exam.AddQuestion(question);
            });
            exam.RespondQuestion(1, "Option B");
            exam.RespondQuestion(2, "Response");
            exam.RespondQuestion(3, "Option A|Option C");
            var result = exam.ExamResult() < exam.TotalScores();
            Assert.AreEqual(result, true);
        }

        [Test]
        public void ApprenticeDoneExam()
        {
            var apprentice = new Apprentice(id: 1065630700, name: "Ana", surname: "Castillo", phone: "30227455890", mail: "ana@gmail.com", direction: "Manzana 59 Casa 13 450 años");
            var exam = new Exam(id: 1, tittle: "Examen 1", description: "Examen de estado",dateRealization: new MyDate("01/09/2020"),dateFinish: new MyDate("01/09/2020"));
            GetQuestions().ForEach(delegate(Question question)
            {
                exam.AddQuestion(question);
            });
            exam.RespondQuestion(1, "Option B");
            exam.RespondQuestion(2, "Response");
            exam.RespondQuestion(3, "Option A|Option C");
            var result = apprentice.AddExamAnswers(new QExamAnswers(1, apprentice, exam));
            Assert.AreEqual("Se agrego un examen respondido.", result);
        }
        
        [Test]
        public void GetExamResultOfApprentice()
        {
            var apprentice = new Apprentice(id: 1065630700, name: "Ana", surname: "Castillo", phone: "30227455890", mail: "ana@gmail.com", direction: "Manzana 59 Casa 13 450 años");
            var exam = new Exam(id: 1, tittle: "Examen 1", description: "Examen de estado",dateRealization: new MyDate("01/09/2020"),dateFinish: new MyDate("01/09/2020"));
            GetQuestions().ForEach(delegate(Question question)
            {
                exam.AddQuestion(question);
            });
            exam.RespondQuestion(1, "Option A");
            exam.RespondQuestion(2, "Response");
            exam.RespondQuestion(3, "Option A|Option C");
            apprentice.AddExamAnswers(new QExamAnswers(1, apprentice, exam));
            apprentice.AddExamAnswers(new QExamAnswers(2, apprentice, exam));
            var examAnswer = apprentice.GetExamAnswers(2);
            Assert.AreEqual(examAnswer.TotalScores(), examAnswer.ExamResult());
        }
        
        [Test]
        public void ApprenticeDoneExamQuestionOuts()
        {
            var apprentice = new Apprentice(id: 1065630700, name: "Ana", surname: "Castillo", phone: "30227455890", mail: "ana@gmail.com", direction: "Manzana 59 Casa 13 450 años");
            var exam = new Exam(id: 1, tittle: "Examen 1", description: "Examen de estado",dateRealization: new MyDate("01/09/2020"),dateFinish: new MyDate("01/09/2020"));
            var result = apprentice.AddExamAnswers(new QExamAnswers(1, apprentice, exam));
            Assert.AreEqual("El examen no contiene preguntas", result);
        }
        
        private static List<Question> GetQuestions()
        {
            var options = new List<string> {"Option A","Option B", "Option C"};
            const string answer = "Option A";
            var question1 = new OnlyAnswer(
                content: "Elija una de las siguientes opciones", 
                id: 1, score: 2.1m, optionalImage:"",
                answer: answer, options: options);
            var question2 = new Open(id: 2, content: "Elija una de las siguientes opciones", score: 2.7m, optionalImage: "");
            var possibleAnswer = new List<string> {"Option A", "Option C" };
            var question3 = new MultipleChoice(
                content: "Elija una de las siguientes opciones", 
                id: 3, score: 2.7m, optionalImage:"", 
                options: options, possibleAnswer: possibleAnswer);
            return new List<Question>() { question1, question2, question3 };
        }
    }
}