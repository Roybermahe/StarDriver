using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StarDriver.domain.core.Contracts;

namespace StarDriver.domain.core.Business.Persons
{
    public class Instructor : Person
    {
        public List<Specialization> _specializations { get; set; }

        public Instructor()
        {
            _specializations =  new List<Specialization>();
        }
   
        public Instructor(int identificacion, string name, string surname,  string phone, string mail, string direction) 
        {
            _specializations =  new List<Specialization>();
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
            _specializations.Add(new Specialization(){Name = specializations});
            return "Especializaciones agregadas";
        }
       

        public bool HaveSpecialization()
        {
            return _specializations.Count > 0;
        }
    }
}