using NUnit.Framework;
using System.Collections.Generic;

namespace StarDriver.domain.core.test
{
    public class InstructorTest
    {
        [SetUp]
        public void Setup()
        {
        }
        
        /*
          Escenario1: Identificación única
          H03: Cómo administrador, quiero realizar el registro de los instructores para asignarles salas virtuales.
          Criterio de Aceptación:
          La identificación de un instructor debe ser única.

          Dado
          Un instructor (identificación: “1065630800”, nombre: “Javier”, fecha de nacimiento “15/09/1990”,  telefono: 3022745590, especialización: “Normas de tránsito Urbanas”) 
          Cuando
          Va a ser registrado
          Entonces
          El sistema presentará el mensaje. “Instructor registrado”
        */
        
        [Test]
        public void IdentificacionInstructorUnicaInstructorTest()
        {
           
            //Preparar
            List<string> especializations = new List<string>();
            especializations.Add("Normas de tránsito Urbanas");
            var administrator = new Administrator(id: 1065630700, name: "Eva", surname: "Rodrigues", phone: "30227455890", mail: "eva@gmail.com", direction: "Manzana 58 Casa 13 450 años");
            var instructor1 = new Instructor(id: 1065630800, name: "Javier", surname: "Rodrigues", phone: "3022745590", mail: "javier@gmail.com", direction: "Manzana 59 Casa 13 450 años");
            instructor1.AddSpecializations("Normas de tránsito Urbanas");
            var instructor2 = new Instructor(id: 1065630700, name: "Alvaro", surname: "Camacho", phone: "3012745590", mail: "armando@gmail.com", direction: "Manzana 58 Casa 50 450 años");
            instructor2.AddSpecializations("Normas de tránsito Urbanas");
            var instructor3 = new Instructor(id: 1065630800, name: "Armando", surname: "Camacho", phone: "3012745590", mail: "armando@gmail.com", direction: "Manzana 58 Casa 50 450 años");
            
            var createInstructor1 = administrator.SaveInstructor(instructor1);
            var createInstructor2 = administrator.SaveInstructor(instructor2);
            

            //Acción
            instructor3.AddSpecializations("Normas de tránsito Urbanas");
            var createInstructor3 = administrator.SaveInstructor(instructor3);

            //Verificación
            Assert.AreEqual("No se puede realizar el registro,Ya existe un instructor con la misma identificación", createInstructor3);
            Assert.AreEqual(2,administrator.CountPersons());
        }

       
       
        /*
        No puede registrar instructor sin especializaciones (003)
        H1: Cómo administrador, quiero realizar el registro de los instructores para asignarles salas virtuales.
        Criterio de Aceptación:
        2. El instructor debe tener una o varias especializaciones.
        Dado
        Un instructor (identificación: “1065630430”, nombre: “Javier”, edad: “25”,  teléfono: 3022745590 ) que no tiene una especialización.
        Cuando
        Va a ser registrado.
        Entonces
        El sistema presentará el mensaje. “No se puede realizar el registro, Se necesita una o más especializaciones” 
        */

        [Test]
        public void CeroEspecializacionInstructorTest()
        {
            //Preparar
            
            var administrator = new Administrator(id: 1065630700, name: "Eva", surname: "Rodrigues", phone: "30227455890", mail: "eva@gmail.com", direction: "Manzana 58 Casa 13 450 años");
            var instructor = new Instructor(id: 1065630430, name: "Javier", surname: "Rodrigues", phone: "3022745590", mail: "javier@gmail.com", direction: "Manzana 59 Casa 13 450 años");
            //Acción
            
            var createInstructor = administrator.SaveInstructor(instructor);

            //Verificación
            Assert.AreEqual("No se puede realizar el registro, Se necesita una o más especializaciones", createInstructor);
            
        }


        /*
        Instructor con numero de especializaciones mayor a 0
        H1: Cómo administrador, quiero realizar el registro de los instructores para asignarles salas virtuales.
        Criterio de Aceptación:
        2. El instructor debe tener una o varias especializaciones.
        Dado
        Un instructor (nombre: “Esteban”, edad: “25”, Especializaciones: “Normas de tránsito rurales” y “Normas de tránsito Terrestre”, telefono: 3022745590 ) que aún no ha sido registrado  y que coincide con un el número de teléfono de otro instructor
        Cuando
        Va a ser registrado.
        Entonces
        El sistema presentará el mensaje. “Instructor Registrado”.
        */

        [Test]
        public void EspecializacionesMayorACeroInstructorTest()
        {
            //Preparar
            
            var administrator = new Administrator(id: 1065630700, name: "Eva", surname: "Rodrigues", phone: "30227455890", mail: "eva@gmail.com", direction: "Manzana 58 Casa 13 450 años");
            var instructor = new Instructor(id: 1065630800, name: "Javier", surname: "Rodrigues", phone: "3022745590", mail: "javier@gmail.com", direction: "Manzana 59 Casa 13 450 años");
            instructor.AddSpecializations("Normas de tránsito Urbanas");
            //Acción

            var createInstructor = administrator.SaveInstructor(instructor);

            //Verificación
            Assert.AreEqual("Instructor registrado", createInstructor);
        }
        
        /*
        Instructor con numero de especializaciones mayor a 0
        H1: Cómo administrador, quiero realizar el registro de los instructores para asignarles salas virtuales.
        Criterio de Aceptación:
        2. El instructor debe tener una o varias especializaciones.
        Dado
        Un instructor (nombre: “Esteban”, edad: “25”, Especializaciones: “” , telefono: 3022745590 ) que aún no ha sido registrado  y que coincide con un el número de teléfono de otro instructor
        Cuando
        Va a ser registrado.
        Entonces
        El sistema presentará el mensaje. “Instructor Registrado”.
        */

        [Test]
        public void EspecializacionesVaciasInstructorTest()
        {
            //Preparar
            
            var administrator = new Administrator(id: 1065630700, name: "Eva", surname: "Rodrigues", phone: "30227455890", mail: "eva@gmail.com", direction: "Manzana 58 Casa 13 450 años");
            var instructor = new Instructor(id: 1065630800, name: "Javier", surname: "Rodrigues", phone: "3022745590", mail: "javier@gmail.com", direction: "Manzana 59 Casa 13 450 años");
            var vacia=instructor.AddSpecializations("");
            //Acción

            var createInstructor = administrator.SaveInstructor(instructor);

            //Verificación
            Assert.AreEqual("No se puede realizar el registro",vacia);
            Assert.AreEqual("No se puede realizar el registro, Se necesita una o más especializaciones", createInstructor);
            
        }


        /*
         
        Puede registrar instructor con teléfono de 10 dígitos (05)
        H1: Cómo administrador, quiero realizar el registro de los instructores para asignarles salas virtuales
        Criterio de Aceptación:
        3. El teléfono de un instructor debe estar en un intervalo de 7 a 10 dígitos.
        Dado
        Un instructor (nombre: “Esteban”, edad: “25”, Especializaciones: “Normas de tránsito rurales” y “Normas de tránsito Terrestre”, teléfono: 3012745590 ) y que NO coincide con un el número de teléfono de otro instructor.
        Cuando
        Va a ser registrado.
        Entonces
        El sistema presentará el mensaje. “Instructor registrado”.
        */

        [Test]
        public void DigitosDeTelefonoCompletoInstructorTest()
        {
            //Preparar
            
            var administrator = new Administrator(id: 1065630700, name: "Eva", surname: "Rodrigues", phone: "30227455890", mail: "eva@gmail.com", direction: "Manzana 58 Casa 13 450 años");
            var instructor = new Instructor(id: 1065630800, name: "Javier", surname: "Rodrigues", phone: "3022745590", mail: "javier@gmail.com", direction: "Manzana 59 Casa 13 450 años");
            instructor.AddSpecializations("Normas de tránsito Urbanas");
            //Acción

            var createInstructor = administrator.SaveInstructor(instructor);

            //Verificación
            Assert.AreEqual("Instructor registrado", createInstructor);
        }

        /*
        No puede registrar instructor con teléfono mayor de 10 dígitos (06)     
        H1: Cómo administrador, quiero realizar el registro de los instructores para asignarles salas virtuales.
        Criterio de Aceptación:
        4. El teléfono de un instructor debe estar en un intervalo de 7 a 10 dígitos.
        Dado
        Un instructor  (nombre: “Javier”, edad: “25”, Especializaciones: “Normas de tránsito rurales” , teléfono: 302295894000 ) 
        Cuando
        Va a ser registrado.
        Entonces
        El sistema presentará el mensaje. “No se puede realizar el registro, la cantidad de digitos del telefono no es permitida”.
        */

        [Test]
        public void DigitosDeTelefonoNoPermitidoInstructorTest()
        {
            //Preparar
            var administrator = new Administrator(id: 1065630700, name: "Eva", surname: "Rodrigues", phone: "30227455890", mail: "eva@gmail.com", direction: "Manzana 58 Casa 13 450 años");
            var instructor = new Instructor(id: 1065630800, name: "Javier", surname: "Rodrigues", phone: "30227455890", mail: "javier@gmail.com", direction: "Manzana 59 Casa 13 450 años");
            instructor.AddSpecializations("Normas de tránsito Urbanas");
            //Acción

            var createInstructor = administrator.SaveInstructor(instructor);

            //Verificación
            Assert.AreEqual("No se puede realizar el registro, la cantidad de digitos del telefono no es permitida", createInstructor);
        }
        
        

    }
}
