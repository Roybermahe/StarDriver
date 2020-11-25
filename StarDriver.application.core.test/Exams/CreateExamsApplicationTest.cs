using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using StarDriver.application.core.ExamsServices;
using StarDriver.infrastructure.core.Base;
using StarDriver.infrastructure.core.DomainContexts;

namespace StarDriver.application.core.test.Exams
{
    public class ExamServiceTest
    {
        private StarDriverContext _context;

        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<StarDriverContext>().UseInMemoryDatabase(GetType().Name).Options;
            _context = new StarDriverContext(optionsInMemory);
        }

        [Test]
        public void CreateExamWithDateFinishMinorToDateStart()
        {
            var request = new CreateExamRequest() { Tittle = "Exam", Description = "Exam number one", DateRealization = "01/02/98", DateFinish = "01/01/98" };
            var service = new CreateExamService(new UnitOfWork(_context));
            var result = service.Ejecutar(request);
            Assert.AreEqual("La fecha de finalización debe ser posterior o igual a la fecha de realización.", result.Message);
        }

        [Test]
        public void CreateExamWithDateFinishExcedingDateStart()
        {
            var request = new CreateExamRequest() { Tittle = "Exam", Description = "Exam number one", DateRealization = "01/02/98", DateFinish = "03/02/98" };
            var service = new CreateExamService(new UnitOfWork(_context));
            var result = service.Ejecutar(request);
            Assert.AreEqual("El examen fue creado con exito.", result.Message);
        }

        [Test]
        public void CreateExamWithDateFinishEqualsDateStart()
        {
            var request = new CreateExamRequest() { Tittle = "Exam", Description = "Exam number one", DateRealization = "01/02/98", DateFinish = "01/02/98" };
            var service = new CreateExamService(new UnitOfWork(_context));
            var result = service.Ejecutar(request);
            Assert.AreEqual("El examen fue creado con exito.", result.Message);
        }

    }
}