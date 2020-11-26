using System;
using System.Collections.Generic;
using StarDriver.domain.core.Base;
using StarDriver.domain.core.Business.DevPlans;
using StarDriver.domain.core.Business.Persons;
using  StarDriver.domain.core.Contracts;

namespace StarDriver.domain.core.Business.VirtualRooms
{
    public class Room: Entity<int>
    {
        
        public string Name { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        
        public Instructor Instructor { get; set; }
        
        public DevelopmentPlan DevelopmentPlan { get; set; }

        public List<Apprentice> _apprentice;

        public Room()
        {
            _apprentice = new List<Apprentice>();
        }

        public Room( string name, string description, string state, Instructor instructor, DevelopmentPlan developmentPlan, List<Apprentice> apprentice)
        {
            Name = name;
            Description = description;
            State = state;
            Instructor = instructor;
            DevelopmentPlan = developmentPlan;
            _apprentice = apprentice;
        }
        
        public string UpdateVirtualRoom(string name, string description, string state, Instructor instructor, DevelopmentPlan developmentPlan)
        {
            if ( StringOperations.IsEqual(Name, name) && StringOperations.IsEqual(Description, description) && StringOperations.IsEqual(state, State) && DevelopmentPlan.Id == DevelopmentPlan.Id && Instructor.Id == instructor.Id)
                return "Debe modificar al menos un campo para poder actualizar la sala virtual";

            Name = name;
            Description = description;
            State = state;
            Instructor = instructor;
            DevelopmentPlan = DevelopmentPlan;

            return "sala virtual actualizada con exito";
            
        }

        /*
         * estados del salon:
         *   creado
         *   en curso
         *   pausado
         *   finalizado
         */

    }
}