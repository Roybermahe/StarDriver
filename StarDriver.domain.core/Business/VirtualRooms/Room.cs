using System;
using System.Collections.Generic;
using StarDriver.domain.core.Business.Persons;
using  StarDriver.domain.core.Contracts;

namespace StarDriver.domain.core.Business.VirtualRooms
{
    public class Room
    {
        private int Identification { get; set; }
        private string Name { get; set; }
        private string Description { get; set; }
        private bool State { get; set; }
        private Instructor _instructor { get; set; }
        private DevelopmentPlan _developmentPlan { get; set; }

        private List<Apprentice> _apprentice;

        public Room(int identification, string name, string description, bool state, Instructor instructor, DevelopmentPlan developmentPlan, List<Apprentice> apprentice)
        {
            Identification = identification;
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