﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using StarDriver.domain.core;

namespace StarDriver.domain.core.test
{
    class PInstructorTest
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
        public void IdentificacionInstructorUnicaTest()
        {
            //Preparar
            List<string> especializations = new List<string>();
            especializations.Add("Normas de tránsito Urbanas");
            var instructor = new PInstructor(idPerson: 1065630800, name: "Javier", surname: "Rodrigues", phone: "3022745590", mail: "javier@gmail.com", direction: "Manzana 59 Casa 13 450 años");

            //Acción

            var createInstructor=instructor.CreateInstructor(instructor, especializations);

            //Verificación
            Assert.AreEqual("Instructor registrado", createInstructor);
        }

        /*
        Escenario 2: No puede registrar instructor con identificación no única (002)
        H1: Cómo administrador, quiero realizar el registro de los instructores para asignarles salas virtuales.
        Criterio de Aceptación:
        1. El instructor debe tener una identificación única 
        Dado
        Un instructor (identificación: “1065630800”, nombre: “Javier”, edad: “25”,  telefono: 3022745590, especialización: “Normas de tránsito Urbanas”) y ya existe otro instructor registrado con esa identificación
        Cuando
        Va a ser registrado.
        Entonces
        El sistema presentará el mensaje. “No se puede realizar el registro,Ya existe un instructor con la misma identificación”.
        */

        [Test]
        public void IdentificacionInstructorNoUnicaTest()
        {
            //Preparar
            List<string> especializations = new List<string>();
            especializations.Add("Normas de tránsito Urbanas");
            var instructor1 = new PInstructor(idPerson: 1065630800, name: "Javier", surname: "Rodrigues", phone: "3022745590", mail: "javier@gmail.com", direction: "Manzana 59 Casa 13 450 años");
            var instructor2 = new PInstructor(idPerson: 1065630800, name: "Armando", surname: "Camacho", phone: "3012745590", mail: "armando@gmail.com", direction: "Manzana 58 Casa 50 450 años");
            var createInstructor1 = instructor2.CreateInstructor(instructor1, especializations);

            //Acción

            var createInstructor2 = instructor1.CreateInstructor(instructor2, especializations);

            //Verificación
            Assert.AreEqual("No se puede realizar el registro,Ya existe un instructor con la misma identificación", createInstructor2);
        }
    }
}
