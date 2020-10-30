using System;
using System.Collections.Generic;
using StarDriver.domain.core.Business.VirtualRooms;

namespace StarDriver.domain.core.Business.ServiceOffer
{
    public class Service
    {
        private Room _room { get; set; }
        private List<Apprentice> _apprentices;
        private DetailService _detailService { get; set; }

        public Service(Room room, DetailService detailService)
        {
            _room = room;
            _apprentices = new List<Apprentice>();
            _detailService = detailService;
        }
    }
}