using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StarDriver.domain.core.Contracts;

namespace StarDriver.domain.core.Business.Persons
{
    public class Instructor : Person
    {
        public readonly List<string> _specializations;
        
        public Instructor(){}
   
        public Instructor(int identificacion, string name, string surname,  string phone, string mail, string direction) 
        {
            _specializations =  new List<string>();
            Id = identificacion;
            Name = name;
            Surname = surname;
            Phone = phone;
            Mail = mail;
            Direction = direction;
        }

        public string AddSpecializations(string specializations)
        {
            if (StringOperations.IsEmpty(specializations)) return "No se puede realizar el registro";
            _specializations.Add(specializations);
            return "Especializaciones agregadas";
        }
       

        public bool HaveSpecialization()
        {
            return _specializations.Count > 0;
        }
    }
}