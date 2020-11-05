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
        public bool State { get; set; }
        public Instructor _instructor { get; set; }
        public DevelopmentPlan _developmentPlan { get; set; }

        private List<Apprentice> _apprentice;

        public Room()
        {
        }

        public Room(int identification, string name, string description, bool state, Instructor instructor, DevelopmentPlan developmentPlan, List<Apprentice> apprentice)
        {
            Id = identification;
            Name = name;
            Description = description;
            State = state;
            _instructor = instructor;
            _developmentPlan = developmentPlan;
            _apprentice = apprentice;
        }
        
        public string UpdateVirtualRoom(string name, string description, bool state, List<Apprentice> newApprentices, Instructor instructor)
        {
            if (Name.Equals(name) && Description.Equals(description) && state.Equals(State) && newApprentices.Count == 0 && instructor.Id == _instructor.Id)
                return "Debe modificar al menos un campo para poder actualizar la sala virtual";

            Name = name;
            Description = description;
            State = state;
            _instructor = instructor;
            
            foreach (var newApprentice in newApprentices)
            {
                int count = 0;

                foreach (var apprenticeRegister in _apprentice){

                    if(apprenticeRegister.Id == newApprentice.Id ){
                        count = 1;
                    }
                }
                if(count == 0){
                    _apprentice.Add(newApprentice);
                }
            }

            return "sala virtual actualizada con exito";
            
        }

    }
}