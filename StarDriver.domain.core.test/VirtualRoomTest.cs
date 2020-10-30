using System.Collections.Generic;
using NUnit.Framework;
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
          Escenario1: Actualizacion exitosa
          H02: Cómo administrador, quiero actualizar salas virtuales de cualquier tipo  para el desarrollo de las clases.

          Dado
          Un instructor (id: 1065630800, name: “Esteban”, surname: "Rodrigues", phone: 3022745590, mail: "esteban@gmail.com", direction: "Manzana 59 Casa 13 450 años", “Normas de tránsito rurales” )
          Cuando
          Va a ser registrado
          Entonces
          El sistema presentará el mensaje. “Instructor registrado”
       */
        [Test]
        public void CompleteDataEnteredTest()
        {
            //Preparar
               // crear instructor
               var instructor = new Instructor(idPerson: 1065630800, name: "Esteban", surname: "Rodrigues", phone: "3022745590", mail: "esteban@gmail.com", direction: "Manzana 59 Casa 13 450 años");
               instructor.AddSpecializations("Normas de tránsito rurales");
               
               // crear plan de desarrollo
               var plan = new DevelopmentPlan(identification: 1, level: "1");
               var maintheme = new MainTheme(identification: 1, title: "Vías y carreteras", description: "En este tema hablaremos acerca de las vías...");
               maintheme.AddItems("primer vía");
               plan.AddMainTheme(maintheme);

               // crear lista de aprendices 
               List<Apprentice> apprentices;
               var apprentice1 = new Apprentice();
               
               //Acción

               //Verificación
        }
        
    }
}