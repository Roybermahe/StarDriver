using System.Collections.Generic;
using NUnit.Framework;

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
            Una pregunta debe tener un contexto y una o varias posible respuesta

            Dado
            Un usuario Instructor que elige una pregunta de selección múltiple contexto: “elija una de las siguientes opciones:”, respuestas: 2
            Cuando
            Va a crear la pregunta para el examen
            Entonces
            El sistema presentará un mensaje. “Se agrego la pregunta al examen”

         */
        [Test]
        public void AddQuestionToExam()
        {
            var options = new List<string> {"Option A","Option B", "Option C"};
            var possibleAnswer = new List<string> {"Option A", "Option C" };
            var question = new MultipleChoice(
                content: "Elija una de las siguientes opciones", 
                identification: 1, score: 2.7m, optionalImage:"", 
                options: options, possibleAnswer: possibleAnswer);
            var exam = new Exam(identification: 1, tittle: "Examen 1", description: "Examen de estado",dateRealization: new MyDate("01/09/2020"),dateFinish: new MyDate("01/09/2020"));
            var result = exam.AddQuestion(question);
            Assert.AreEqual("Se agrego la pregunta al examen", result);
        }
    }
}