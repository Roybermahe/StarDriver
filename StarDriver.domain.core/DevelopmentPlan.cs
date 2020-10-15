using System.Collections.Generic;

namespace StarDriver.domain.core
{
    public class DevelopmentPlan
    {
        private int Identification { get; set; }
        private string Level { get; set; }
        private List<MainTheme> MainThemes { get; set; }

        public DevelopmentPlan(int identification, string level)
        {
            Identification = identification;
            Level = level;
            MainThemes = new List<MainTheme>();
        }

        public string AddMainTheme(MainTheme mainTheme)
        {
            MainThemes.Add(mainTheme);
            return "Se agrego un eje temático";
        }

        public int TotalMainThemes()
        {
            return MainThemes.Count;
        }

        public string LevelOfPlan()
        {
            return Level;
        }
    }
}