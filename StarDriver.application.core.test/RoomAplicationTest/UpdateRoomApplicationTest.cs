using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using StarDriver.application.core.RoomServices;
using StarDriver.domain.core.Business.DevPlans;
using StarDriver.domain.core.Business.Persons;
using StarDriver.infrastructure.core.Base;
using StarDriver.infrastructure.core.DomainContexts;

namespace StarDriver.application.core.test.RoomAplicationTest

{
    public class UpdateRoomApplicationTest
    {
        StarDriverContext _context;
        [SetUp]
        public void Setup()
        {
            var optionsInMemory = new DbContextOptionsBuilder<StarDriverContext>().UseInMemoryDatabase(GetType().Name).Options;
            _context = new StarDriverContext(optionsInMemory);
        }

        [Test]
        public void YesCanUpdateRoomTest()
        {
            LoadData();
            
            var request = new UpdateRoomRequest(){RoomId = 1, Name = "salon 3", Description = "salon normas rurales", State = "en curso", IdInsturctor = 1, IdDevPlan = 1};
            UpdateRoomService service = new UpdateRoomService(new UnitOfWork(_context));
            var response = service.Run(request);
            Assert.AreEqual("La sala virtual fue actualizada.", response.Message);
        }
        
        [Test]
        public void CannotUpdateRoomWithoutRegisteredInstructorTest()
        {
            LoadData();
            var request = new UpdateRoomRequest(){RoomId = 1, Name = "salon 3", Description = "salon normas rurales", State = "en curso", IdInsturctor = 3, IdDevPlan = 1};
            UpdateRoomService service = new UpdateRoomService(new UnitOfWork(_context));
            var response = service.Run(request);
            Assert.AreEqual("El instructor que desea modificar no se encuentra registrado.", response.Message);
        }
        
        [Test]
        public void CannotUpdateRoomWithoutRegisteredDevelopmentPlanTest()
        {
            LoadData();
            
            var request = new UpdateRoomRequest(){RoomId = 1, Name = "salon 3", Description = "salon normas rurales", State = "en curso", IdInsturctor = 1, IdDevPlan = 12};
            UpdateRoomService service = new UpdateRoomService(new UnitOfWork(_context));
            var response = service.Run(request);
            Assert.AreEqual("El plan de desarrollo que desea modificar no se encuentra registrado.", response.Message);
        }

        private void LoadData()
        {
            var instructor = new Instructor(){ Id = 1, Name = "Esteban", Surname = "Rodrigues", Phone = "3022745590", Mail = "esteban@gmail.com", Direction = "Manzana 59 Casa 13 450 años"};
            _context.Instructors.Add(instructor);
            
            var plan = new DevelopmentPlan() { Id = 1,Level  = "1"};
            _context.DevelopmentPlans.Add(plan);
            
            /*var room = new Room(){ Name = "salon 3", Description = "salon clases intensivas", State = "creado", Instructor = instructor, DevelopmentPlan = plan};
              _context.Rooms.Add(room);
              _context.SaveChanges(); */
            
            var requestSave = new CreateRoomRequest(){ Name = "salon 3", Description = "salon clases intensivas", State = "creado", IdInsturctor = 1, IdDevPlan = 1};
            var serviceSave = new CreateRoomService(new UnitOfWork(_context));
            var responseSave = serviceSave.Run(requestSave);
        }
    }
}