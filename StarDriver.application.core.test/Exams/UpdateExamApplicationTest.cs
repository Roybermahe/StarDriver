using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using StarDriver.application.core.ExamsServices;
using StarDriver.domain.core.Business.Exams;
using StarDriver.infrastructure.core.Base;
using StarDriver.infrastructure.core.DomainContexts;

namespace StarDriver.application.core.test.Exams
{
    public class UpdateExamApplicationTest
    {
        private StarDriverContext _context;

        [SetUp]
        public void SetUp()
        {
            var optionsInMemory = new DbContextOptionsBuilder<StarDriverContext>().UseInMemoryDatabase(GetType().Name).Options;
            _context = new StarDriverContext(optionsInMemory);
        }
        
        [Test]
        public void UpdateExamExist()
        {
            _context.Exams.Add(new Exam(){ Id = 1, Description = "", Tittle = "", DateFinish = "01/02/2020", DateRealization = "01/02/2020" });
            _context.SaveChanges();
            var request = new UpdateExamRequest() { ExamId = 1, Description = "nueva description", Tittle = "nuevo titulo", DateFinish = "01/02/2020", DateRealization = "01/03/2020"};
            var service = new UpdateExamService(new UnitOfWork(_context));
            var result = service.Ejecutar(request);
            Assert.AreEqual("El examen fue actualizado." ,result.Message);
        }
        
        [Test]
        public void UpdateExamDontExist()
        {
            var request = new UpdateExamRequest() { ExamId = 2, Description = "nueva description", Tittle = "nuevo titulo", DateFinish = "01/02/2020", DateRealization = "01/03/2020"};
            var service = new UpdateExamService(new UnitOfWork(_context));
            var result = service.Ejecutar(request);
            Assert.AreEqual("El examen que desea editar no existe." ,result.Message);
        }
    }
}