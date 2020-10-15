using System.Collections.Generic;

namespace StarDriver.domain.core
{
    public class MainTheme
    {
       private int Identification { get; set; }
       private string Title { get; set; } 
       private string Description { get; set; }
       private List<string> Items { get; set; }

       public MainTheme(int identification, string title, string description, List<string> items)
       {
           Identification = identification;
           Title = title;
           Description = description;
           Items = items;
       }

       public string AddItems(string item)
       {
           Items.Add(item);
           return "Se agrego el item al eje temático";
       }
    }
}