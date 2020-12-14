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

        public List<Apprentice> _apprentice  { get; set; }

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

        public string AddApprentices(Apprentice apprentice)
        {
            var item = _apprentice.Find(t => t.Id == apprentice.Id);
            if (item != null) return "Ya este aprendiz esta agregado";
            _apprentice.Add(apprentice);
            return "Se añadio el aprendiz a la sala.";
        }
    }
}