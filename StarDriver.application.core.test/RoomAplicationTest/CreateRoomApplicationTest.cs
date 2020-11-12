using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using StarDriver.application.core.RoomServices;
using StarDriver.domain.core.Business.DevPlans;
using StarDriver.domain.core.Business.Persons;
using StarDriver.infrastructure.core.Base;
using StarDriver.infrastructure.core.DomainContexts;

namespace StarDriver.application.core.test
{
    public class Tests
    {
        StarDriverContext _context;
        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<StarDriverContext>().UseInMemoryDatabase("StarDriver").Options;
            _context = new StarDriverContext(optionsInMemory);

        }

        [Test]
        public void YesCanCreateRoomTest()
        {
            loadData();
            var request = new CreateRoomRequest(){Name = "salon 3", Description = "salon clases intensivas", State = "creado", IdInsturctor = 1, IdDevPlan = 1};
            CreateRoomService _service = new CreateRoomService(new UnitOfWork(_context));
            var response = _service.Run(request);
            Assert.AreEqual("El salon fue creado con exito.", response.Message);
        }
        
        [Test]
        public void CanNotCreateRoomWithoutInstructorCreated()
        {
            loadData();
            var request1 = new CreateRoomRequest(){ Name = "salon 3", Description = "salon clases intensivas", State = "creado", IdInsturctor = 4, IdDevPlan = 1};
            CreateRoomService _service = new CreateRoomService(new UnitOfWork(_context));
            var response = _service.Run(request1);
            Assert.AreEqual("El instructor ingresado no se encuentra registrado.", response.Message);
        }
        
        [Test]
        public void CanNotCreateRoomWithoutDevelopmentPlanCreated()
        {
            loadData();
            var request2 = new CreateRoomRequest(){Name = "salon 3", Description = "salon clases intensivas", State = "creado", IdInsturctor = 1, IdDevPlan = 4};
            CreateRoomService _service = new CreateRoomService(new UnitOfWork(_context));
            var response = _service.Run(request2);
            Assert.AreEqual("El plan de desarrollo ingresado no se encuentra registrado.", response.Message);
        }

        private void loadData()
        {
            var instructor = new Instructor(){ Id = 1, Name = "Esteban", Surname = "Rodrigues", Phone = "3022745590", Mail = "esteban@gmail.com", Direction = "Manzana 59 Casa 13 450 años"};
            _context.Instructors.Add(instructor);
            
            var plan = new DevelopmentPlan() { Id = 1,Level  = "1"};
            _context.DevelopmentPlans.Add(plan);
        }
        
    }
}