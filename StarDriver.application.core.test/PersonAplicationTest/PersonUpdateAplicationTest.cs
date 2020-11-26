using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using StarDriver.application.core.PersonServices;
using StarDriver.domain.core.Business.Persons;
using StarDriver.infrastructure.core.Base;
using StarDriver.infrastructure.core.DomainContexts;

namespace StarDriver.application.core.test
{
    public class PersonUpdateAplicationTest
    {
        StarDriverContext _context;
        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<StarDriverContext>().UseInMemoryDatabase("StarDriver").Options;
            _context = new StarDriverContext(optionsInMemory);
            
        }
    
        [Test]
        public void UpdatePersonTest()
        {
            _context.Persons.Add(new Apprentice(1003386884, "Esteban", "Gañan", "3104454915", "estban@email.com", "Valledupar"){Id = 1});
            _context.SaveChanges();
            var request = new UpdatePersonRequest() {Id = 1,Name = "Esteban", Surname = "Gañan", Phone= "3104454915" , Mail= "estban@email.com", Direction= "Valledupar"};
            UpdatePersonService _service = new UpdatePersonService(new UnitOfWork(_context));
            var response = _service.Ejecutar(request);
            Assert.AreEqual("La persona fue actualizada.", response.Message);
        }
        
        [Test]
        public void NotUpdatePersonTest()
        {
            var request = new UpdatePersonRequest() {Id = 3,Name = "Esteban", Surname = "Gañan", Phone= "3104454915" , Mail= "estban@email.com", Direction= "Valledupar"};
            UpdatePersonService _service = new UpdatePersonService(new UnitOfWork(_context));
            var response = _service.Ejecutar(request);
            Assert.AreEqual("La persona no existe", response.Message);
        }

        [TearDown]
        public void Tear()
        {
            _context.Dispose();
        }
    }
}