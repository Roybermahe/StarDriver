using System;
using System.Collections.Generic;
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

        public string UpdateVirtualRoom(string name, string description, bool state, List<Apprentice> apprentices)
        {
            if (StringOperations.IsEmpty(name) && StringOperations.IsEmpty(description) && state.Equals(State) && apprentices.Count == 0)
                return "Debe ingresar al menos un campo para poder actualizar la sala virtual";

            Name = name;
            Description = description;
            State = state;
            foreach (var apprentice in apprentices)
            {
                _apprentice.Add(apprentice);
            }
            return "sala virtual actualizada con exito";
            
        }

    }
}