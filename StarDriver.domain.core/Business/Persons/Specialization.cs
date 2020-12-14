using System;
using StarDriver.domain.core.Base;

namespace StarDriver.domain.core.Business.Persons
{
    public class Specialization: Entity<int>
    {
        public string Name { get; set; }
    }
}