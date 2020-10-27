using System.Collections.Generic;
using StarDriver.domain.core.Base;
using StarDriver.domain.core.Contracts;

namespace StarDriver.domain.core.Business.DevPlans
{
    public class MainTheme : Entity<int>
    {
        private string Title { get; set; } 
       private string Description { get; set; }
       private List<string> Items { get; set; }

       public MainTheme(int id, string title, string description)
       {
           Id = id;
           Title = title;
           Description = description;
           Items = new List<string>();
       }

       public string GetTitle()
       {
           return Title;
       }

       public string GetDescription()
       {
           return Description;
       }

       public int GetIdentification()
       {
           return Id;
       }
       
       public string AddItems(string item)
       {
           if (StringOperations.IsEmpty(item)) return "No se permite un item sin descripción";
           Items.Add(item);
           return "Se agrego el item al eje temático";
       }

       public int TotalItems()
       {
           return Items.Count;
       }
    }
}