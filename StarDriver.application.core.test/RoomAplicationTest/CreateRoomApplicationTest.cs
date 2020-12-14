using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using StarDriver.application.core.RoomServices;
using StarDriver.domain.core.Business.DevPlans;
using StarDriver.domain.core.Business.Persons;
using StarDriver.infrastructure.core.Base;
using StarDriver.infrastructure.core.DomainContexts;

namespace StarDriver.application.core.test.RoomAplicationTest
{
    public class Tests
    {
        StarDriverContext _context;
        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<StarDriverContext>().UseInMemoryDatabase(GetType().Name).Options;
            _context = new StarDriverContext(optionsInMemory);

        }

        [Test]
        public void YesCanCreateRoomTest()
        {
            LoadData();
            var request = new CreateRoomRequest(){Name = "salon 3", Description = "salon clases intensivas", State = "creado", IdInsturctor = 1, IdDevPlan = 1};
            var service = new CreateRoomService(new UnitOfWork(_context));
            var response = service.Run(request);
            Assert.AreEqual("El salon fue creado con exito.", response.Message);
        }
        
        [Test]
        public void CannotCreateRoomWithoutRegisteredInstructorTest()
        {
            LoadData();
            var request = new CreateRoomRequest(){ Name = "salon 3", Description = "salon clases intensivas", State = "creado", IdInsturctor = 4, IdDevPlan = 1};
            var service = new CreateRoomService(new UnitOfWork(_context));
            var response = service.Run(request);
            Assert.AreEqual("El instructor ingresado no se encuentra registrado.", response.Message);
        }
        
        [Test]
        public void CannotCreateRoomWithoutRegisteredDevelopmentPlanTest()
        {
            LoadData();
            var request = new CreateRoomRequest(){Name = "salon 3", Description = "salon clases intensivas", State = "creado", IdInsturctor = 1, IdDevPlan = 4};
            var service = new CreateRoomService(new UnitOfWork(_context));
            var response = service.Run(request);
            Assert.AreEqual("El plan de desarrollo ingresado no se encuentra registrado.", response.Message);
        }

        private void LoadData()
        {
            var instructor = new Instructor(){ Id = 1, Name = "Esteban", Surname = "Rodrigues", Phone = "3022745590", Mail = "esteban@gmail.com", Direction = "Manzana 59 Casa 13 450 años"};
            _context.Instructors.Add(instructor);
            
            var plan = new DevelopmentPlan() { Id = 1,Level  = "1"};
            _context.DevelopmentPlans.Add(plan);
        }
        
    }
}