using System;
using System.Collections.Generic;

namespace StarDriver.domain.core.Business.ServiceOffer
{
    public class DetailService
    {
        private int Identification { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        
        public DetailService(int identification, string title, string description)
        {
            Identification = identification;
            Title = title;
            Description = description;
        }
        
    }
}