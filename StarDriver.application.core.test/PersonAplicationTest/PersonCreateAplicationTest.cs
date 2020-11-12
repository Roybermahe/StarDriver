using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using StarDriver.application.core.PersonServices;
using StarDriver.infrastructure.core.Base;
using StarDriver.infrastructure.core.DomainContexts;

namespace StarDriver.application.core.test
{
    public class PersonCreateAplicationTest
    {
        StarDriverContext _context;
        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<StarDriverContext>().UseInMemoryDatabase("StarDriver").Options;
            _context = new StarDriverContext(optionsInMemory);
        }

        [Test]
        public void CreatePersonTest()
        {
            var request = new PersonCreateRequest() { Identificacion =  1003376884, Name = "Esteban", Surname = "Gañan", Phone= "3104454915" , Mail= "estban@email.com", Direction= "Valledupar", Type = "Instructor"};
            CreatePersonServices _service = new CreatePersonServices(new UnitOfWork(_context));
            var response = _service.Ejecutar(request);
            Assert.AreEqual("Persona creada con exito", response.Message);
        }
        
        
        
        
    }
}