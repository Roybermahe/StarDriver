using System.Collections.Generic;
using NUnit.Framework;
using StarDriver.domain.core.Business.Persons;
using StarDriver.domain.core.Business.VirtualRooms;
using StarDriver.domain.core.Contracts;

namespace StarDriver.domain.core.test
{
    public class VirtualRoomTest
    {
        [SetUp]
        public void SetUp()
        {
        }
        
        /*
          Escenario 1: Actualizacion exitosa
          H02: Cómo administrador, quiero actualizar salas virtuales de cualquier tipo  para el desarrollo de las clases.

          Dado
           Un instructor (id: 1065630800, name: “Esteban”, surname: "Rodrigues", phone: 3022745590, mail: "esteban@gmail.com", direction: "Manzana 59 Casa 13 450 años", “Normas de tránsito rurales” )
           Un plan de desarrollo (identification: 1, level: "1"); (identification: 1, title: "Vías y carreteras", description: "En este tema hablaremos acerca de las vías...")
           Una lista de aprendices:
              (id: 1003874583, name: "Adriana", surname: "Castilla", phone: "3152745517", mail: "acastilla@gmail.com", direction: "Cra 35 # 17 - 08");
              (id: 1033858731, name: "Juan", surname: "Garcia", phone: "3182772119", mail: "jgarcia@gmail.com", direction: "Cra 16 # 25 - 14");
              (id: 1023871587, name: "Daniela", surname: "Curvelo", phone: "3152540118", mail: "dcurvelo@gmail.com", direction: "Cra 23 # 35 - 17"); 
           una sala virtual con los datos anteriores(identification: 001, name: "room1", description: "enseñanza de norvas rurales", state: true, instructor: instructor, developmentPlan: plan, apprentice: apprentices);
          
          Cuando
          Va a ser modificado con los siguientes datos
           (name: "room2", description: "enseñanza de normas urbanas y rurales", state: true, newApprentices: apprentices, instructor: instructor );
          
          Entonces
          El sistema presentará el mensaje. “sala virtual actualizada con exito”
       */
        
        [Test]
        public void CompleteDataEnteredTest()
        {
            //Preparar
               // crear instructor
               var instructor = new Instructor(id: 1065630800, name: "Esteban", surname: "Rodrigues", phone: "3022745590", mail: "esteban@gmail.com", direction: "Manzana 59 Casa 13 450 años");
               instructor.AddSpecializations("Normas de tránsito rurales");
               
               // crear plan de desarrollo
               var plan = new DevelopmentPlan(identification: 1, level: "1");
               var maintheme = new MainTheme(identification: 1, title: "Vías y carreteras", description: "En este tema hablaremos acerca de las vías...");
               maintheme.AddItems("primer vía");
               plan.AddMainTheme(maintheme);

               // crear lista de aprendices 
               List<Apprentice> apprentices = new List<Apprentice>();
               var apprentice1 = new Apprentice(id: 1003874583, name: "Adriana", surname: "Castilla", phone: "3152745517", mail: "acastilla@gmail.com", direction: "Cra 35 # 17 - 08");
               var apprentice2 = new Apprentice(id: 1033858731, name: "Juan", surname: "Garcia", phone: "3182772119", mail: "jgarcia@gmail.com", direction: "Cra 16 # 25 - 14");
               var apprentice3 = new Apprentice(id: 1023871587, name: "Daniela", surname: "Curvelo", phone: "3152540118", mail: "dcurvelo@gmail.com", direction: "Cra 23 # 35 - 17");
              
               apprentices.Add(apprentice1);
               apprentices.Add(apprentice2);
               apprentices.Add(apprentice3);
               
               // crear sala virtual
               var salaVirtual = new Room(identification: 001, name: "room1", description: "enseñanza de norvas rurales", state: true, instructor: instructor, developmentPlan: plan, apprentice: apprentices);
            
            //Acción
            var modificar = salaVirtual.UpdateVirtualRoom(name: "room2", description: "enseñanza de normas urbanas y rurales", state: true, newApprentices: apprentices, instructor: instructor );

            //Verificación
            Assert.AreEqual("sala virtual actualizada con exito", modificar);
        }
        
        
        /*
          Escenario 2: Actualizacion fallida
          H02: Cómo administrador, quiero actualizar salas virtuales de cualquier tipo  para el desarrollo de las clases.

          Dado
           Un instructor (id: 1065630800, name: “Esteban”, surname: "Rodrigues", phone: 3022745590, mail: "esteban@gmail.com", direction: "Manzana 59 Casa 13 450 años", “Normas de tránsito rurales” )
           Un plan de desarrollo (identification: 1, level: "1"); (identification: 1, title: "Vías y carreteras", description: "En este tema hablaremos acerca de las vías...")
           Una lista de aprendices:
              (id: 1003874583, name: "Adriana", surname: "Castilla", phone: "3152745517", mail: "acastilla@gmail.com", direction: "Cra 35 # 17 - 08");
              (id: 1033858731, name: "Juan", surname: "Garcia", phone: "3182772119", mail: "jgarcia@gmail.com", direction: "Cra 16 # 25 - 14");
              (id: 1023871587, name: "Daniela", surname: "Curvelo", phone: "3152540118", mail: "dcurvelo@gmail.com", direction: "Cra 23 # 35 - 17"); 
           una sala virtual con los datos anteriores(identification: 001, name: "room1", description: "enseñanza de norvas rurales", state: true, instructor: instructor, developmentPlan: plan, apprentice: apprentices);
          
          Cuando
          Va a ser modificado y no se ingresa ningun cambio
          
          Entonces
          El sistema presentará el mensaje. “Debe modificar al menos un campo para poder actualizar la sala virtual”
       */
        
        [Test]
        public void FailedDataEnteredTest()
        {
            //Preparar
               // crear instructor
               var instructor = new Instructor(id: 1065630800, name: "Esteban", surname: "Rodrigues", phone: "3022745590", mail: "esteban@gmail.com", direction: "Manzana 59 Casa 13 450 años");
               instructor.AddSpecializations("Normas de tránsito rurales");
               
               // crear plan de desarrollo
               var plan = new DevelopmentPlan(identification: 1, level: "1");
               var maintheme = new MainTheme(identification: 1, title: "Vías y carreteras", description: "En este tema hablaremos acerca de las vías...");
               maintheme.AddItems("primer vía");
               plan.AddMainTheme(maintheme);

               // crear lista de aprendices 
               List<Apprentice> apprentices = new List<Apprentice>();
               var apprentice1 = new Apprentice(id: 1003874583, name: "Adriana", surname: "Castilla", phone: "3152745517", mail: "acastilla@gmail.com", direction: "Cra 35 # 17 - 08");
               var apprentice2 = new Apprentice(id: 1033858731, name: "Juan", surname: "Garcia", phone: "3182772119", mail: "jgarcia@gmail.com", direction: "Cra 16 # 25 - 14");
               var apprentice3 = new Apprentice(id: 1023871587, name: "Daniela", surname: "Curvelo", phone: "3152540118", mail: "dcurvelo@gmail.com", direction: "Cra 23 # 35 - 17");
              
               apprentices.Add(apprentice1);
               apprentices.Add(apprentice2);
               apprentices.Add(apprentice3);
               
               // crear sala virtual
               var salaVirtual = new Room(identification: 001, name: "room1", description: "enseñanza de norvas rurales", state: true, instructor: instructor, developmentPlan: plan, apprentice: apprentices);
            
            //Acción
            List<Apprentice> emptyApprentices = new List<Apprentice>();
            var modificar = salaVirtual.UpdateVirtualRoom(name: "room1", description: "enseñanza de norvas rurales", state: true, newApprentices: emptyApprentices, instructor: instructor );

            //Verificación
            Assert.AreEqual("Debe modificar al menos un campo para poder actualizar la sala virtual", modificar);
        }
        
    }
}