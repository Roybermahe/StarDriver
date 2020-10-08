using System;
using System.Collections.Generic;
using System.Text;

namespace StarDriver.domain.core
{
    public class PAdministrator : Person
    {

        public PAdministrator(int idPerson, string name, string surname, string phone, string mail, string direction) : base(idPerson, name, surname, phone, mail, direction)
        {
        }


    }
}
