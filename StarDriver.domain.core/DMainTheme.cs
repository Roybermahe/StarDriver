using System.Collections.Generic;
using StarDriver.domain.core.Contracts;

namespace StarDriver.domain.core
{
    public class MainTheme
    {
       private int Identification { get; set; }
       private string Title { get; set; } 
       private string Description { get; set; }
       private List<string> Items { get; set; }

       public MainTheme(int identification, string title, string description)
       {
           Identification = identification;
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
           return Identification;
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