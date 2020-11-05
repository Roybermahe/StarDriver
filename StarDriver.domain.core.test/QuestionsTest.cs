using System.Collections.Generic;
using NUnit.Framework;
using StarDriver.domain.core.Business.Exams;
using StarDriver.domain.core.Contracts;

namespace StarDriver.domain.core.test
{
    public class QuestionTest
    {
        [SetUp]
        public void Setup()
        {
        }
        /**
         * 
            Instructor, incluye una pregunta (Seleccion Multiple) al examen válida
            Cómo instructor quiero elegir el tipo(Selección Múltiple, Abierta, Única respuesta) de pregunta que puedo incluir en el examen para medir el conocimiento de mis aprendices.
            Criterio de Aceptación:
            Una pregunta debe tener un contexto y una o varias posible respuesta de acuerdo al tipo

            Dado
            Un usuario Instructor que elige una pregunta de selección múltiple contexto: “elija una de las siguientes opciones:”, respuestas: 2
            Cuando
            Va a crear la pregunta para el examen
            Entonces
            El sistema presentará un mensaje. “Se agrego la pregunta al examen”

         */
        [Test]
        public void AddQuestionMultipleChoiceToExam()
        {
            var options = "Option A|Option B|Option C";
            var possibleAnswer = "Option A|Option C";
            var question = new MultipleChoice(
                content: "Elija una de las siguientes opciones", 
                score: 2.7m, optionalImage:"", 
                options: options, answer: possibleAnswer) { Id = 1};
            var exam = new Exam(tittle: "Examen 1", description: "Examen de estado",dateRealization: new MyDate("01/09/2020"),dateFinish: new MyDate("01/09/2020"));
            var result = exam.AddQuestion(question);
            Assert.AreEqual("Se agrego la pregunta al examen", result);
        }
        
        [Test]
        public void AddQuestionOnlyAnswerToExam()
        {
            var options = "Option A|Option B|Option C";
            const string answer = "Option A";
            var question = new OnlyAnswer(
                content: "Elija una de las siguientes opciones", 
                score: 2.7m, optionalImage:"",
                answer: answer, options: options) {Id = 1};
            var exam = new Exam(tittle: "Examen 1", description: "Examen de estado",dateRealization: new MyDate("01/09/2020"),dateFinish: new MyDate("01/09/2020"));
            var result = exam.AddQuestion(question);
            Assert.AreEqual("Se agrego la pregunta al examen", result);
        }
        
        [Test]
        public void AddQuestionOpen()
        {
            var question = new Open(content: "Elija una de las siguientes opciones", score: 2.7m, optionalImage: "") { Id = 1 };
            var exam = new Exam(tittle: "Examen 1", description: "Examen de estado",
                dateRealization: new MyDate("01/09/2020"), dateFinish: new MyDate("01/09/2020"));
            var result = exam.AddQuestion(question: question);
            Assert.AreEqual("Se agrego la pregunta al examen", result);
        }

        [Test]
        public void AddQuestionContentNull()
        {
            var options = "Option A|Option B|Option C";
            const string answer = "Option A";
            var question = new OnlyAnswer(
                content: "", score: 2.1m, optionalImage:"",
                answer: answer, options: options){Id = 1};
            var exam = new Exam(tittle: "Examen 1", description: "Examen de estado",dateRealization: new MyDate("01/09/2020"),dateFinish: new MyDate("01/09/2020"));
            var result = exam.AddQuestion(question);
            Assert.AreEqual("No se permite una Pregunta sin contenido", result);
        }

        [Test]
        public void TotalScoresOfExam()
        {
            var exam = new Exam(tittle: "Examen 1", description: "Examen de estado",dateRealization: new MyDate("01/09/2020"),dateFinish: new MyDate("01/09/2020"));
            GetQuestions().ForEach(delegate(Question question)
            {
                exam.AddQuestion(question);
            });
            Assert.AreEqual(7.5m, exam.TotalScores());
        }

        [Test]
        public void AddResponsesToQuestion()
        {
            var exam = new Exam(tittle: "Examen 1", description: "Examen de estado",dateRealization: new MyDate("01/09/2020"),dateFinish: new MyDate("01/09/2020"));
            GetQuestions().ForEach(delegate(Question question)
            {
                exam.AddQuestion(question);
            });
            var result = exam.RespondQuestion(new QExamAnswers() { Id = 1, PersonId = 1, QuestionId = 1, UserResponse = "Opcion A"});
            var result2 = exam.RespondQuestion(new QExamAnswers() { Id = 2, PersonId = 1, QuestionId = 2, UserResponse = "Response"});
            var result3 = exam.RespondQuestion(new QExamAnswers() { Id = 3, PersonId = 1, QuestionId = 3, UserResponse = "Option B|Option C"});
            Assert.AreEqual("Respuesta Añadida.",result);
            Assert.AreEqual("Respuesta Añadida.",result2);
            Assert.AreEqual("Respuesta Añadida.",result3);
        }
        
        [Test]
        public void AddResponsesToQuestionNull()
        {
            var exam = new Exam(tittle: "Examen 1", description: "Examen de estado",dateRealization: new MyDate("01/09/2020"),dateFinish: new MyDate("01/09/2020"));
            GetQuestions().ForEach(delegate(Question question)
            {
                exam.AddQuestion(question);
            });
            var result = exam.RespondQuestion(new QExamAnswers() { Id = 1, PersonId = 1, QuestionId = 1, UserResponse = ""});
            Assert.AreEqual("No se admite una respuesta vacia.",result);
        }
        
        [Test]
        public void ModifyScoreAnswerToQuestion()
        {
            var exam = new Exam(tittle: "Examen 1", description: "Examen de estado",dateRealization: new MyDate("01/09/2020"),dateFinish: new MyDate("01/09/2020"));
            GetQuestions().ForEach(delegate(Question question)
            {
                exam.AddQuestion(question);
            });
            exam.RespondQuestion(new QExamAnswers() { Id = 1, PersonId = 1, QuestionId = 1, UserResponse = "Option A"});
            exam.RespondQuestion(new QExamAnswers() { Id = 2, PersonId = 1, QuestionId = 2, UserResponse = "Response"});
            exam.RespondQuestion(new QExamAnswers() { Id = 3, PersonId = 1, QuestionId = 3, UserResponse = "Option A|Option C"});
            var result = exam.ModifyScoreAnswer(new QExamAnswers() { Id = 1, QuestionId = 1, PersonId = 1 }, 2.0m);
            Assert.AreEqual("Se modificó los puntos de esta pregunta",result);
        }
        
        [Test]
        public void ResponseScoreNoHigherThanTheQuestionScore()
        {
            var exam = new Exam(tittle: "Examen 1", description: "Examen de estado",dateRealization: new MyDate("01/09/2020"),dateFinish: new MyDate("01/09/2020"));
            GetQuestions().ForEach(delegate(Question question)
            {
                exam.AddQuestion(question);
            });
            exam.RespondQuestion(new QExamAnswers() { Id = 1, PersonId = 1, QuestionId = 1, UserResponse = "Option A"});
            exam.RespondQuestion(new QExamAnswers() { Id = 2, PersonId = 1, QuestionId = 2, UserResponse = "Response"});
            exam.RespondQuestion(new QExamAnswers() { Id = 3, PersonId = 1, QuestionId = 3, UserResponse = "Option A|Option C"});
            var result = exam.ModifyScoreAnswer(new QExamAnswers() { Id = 1, QuestionId = 1, PersonId = 1 }, 3m);
            Assert.AreEqual("Los puntos de respuesta no pueden ser mayor al puntaje total",result);
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
            var possibleAnswer = "Option A|Option C";
            var question3 = new MultipleChoice(
                content: "Elija una de las siguientes opciones", 
                score: 2.7m, optionalImage:"", 
                options: options, answer: possibleAnswer) { Id = 3};
            return new List<Question>() { question1, question2, question3 };
        }
        
    }
}