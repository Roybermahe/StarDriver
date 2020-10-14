using System;
using System.Collections.Generic;
using System.Text;

namespace StarDriver.domain.core
{
    public class Administrator : Person
    {

        public Administrator(int idPerson, string name, string surname, string phone, string mail, string direction) : base(idPerson, name, surname, phone, mail, direction)
        {
        }
    }
}
