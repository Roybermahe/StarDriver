using NUnit.Framework;

namespace StarDriver.domain.core.test
{
    public class DevelopmentPlanTest
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void AddMainThemeToPlan()
        {
            var plan = new DevelopmentPlan(identification: 1, level: "1");
            Assert.AreEqual(plan.LevelOfPlan(), "1");
            var maintheme = new MainTheme(identification: 1, title: "Vías y carreteras", description: "En este tema hablaremos acerca de las vías...");
            var resultItem = maintheme.AddItems("primer vía");
            Assert.AreEqual("Se agrego el item al eje temático", resultItem);
            
            resultItem = maintheme.AddItems("");
            Assert.AreEqual("No se permite un item sin descripción", resultItem);
            
            maintheme.AddItems("tercera vía");
            var result = plan.AddMainTheme(maintheme);
            Assert.AreEqual(maintheme.TotalItems(), 2);
            Assert.AreEqual("Se agrego un eje temático", result);
            Assert.AreEqual(plan.TotalMainThemes(), 1);
        }

        [Test]
        public void AddMainThemeToPlanFail()
        {
            var plan = new DevelopmentPlan(identification: 1, level: "1");
            var maintheme = new MainTheme(identification: 1, title: "", description: "");
            maintheme.AddItems("primer vía");
            maintheme.AddItems("segunda vía");
            maintheme.AddItems("tercera vía");
            var result = plan.AddMainTheme(maintheme);
            Assert.AreEqual("Se debe añadir el detalle al eje tematico", result);
        }
        
    }
}