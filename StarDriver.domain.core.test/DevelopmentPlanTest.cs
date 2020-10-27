using NUnit.Framework;
using StarDriver.domain.core.Business.DevPlans;

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
            var plan = new DevelopmentPlan(id: 1, level: "1");
            Assert.AreEqual(plan.LevelOfPlan(), "1");
            var maintheme = new MainTheme(id: 1, title: "Vías y carreteras", description: "En este tema hablaremos acerca de las vías...");
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
            var plan = new DevelopmentPlan(id: 1, level: "1");
            var maintheme = new MainTheme(id: 1, title: "", description: "");
            maintheme.AddItems("primer vía");
            maintheme.AddItems("segunda vía");
            maintheme.AddItems("tercera vía");
            var result = plan.AddMainTheme(maintheme);
            Assert.AreEqual("Se debe añadir el detalle al eje tematico", result);
        }
        [Test]
        public void AddMainThemeExistToPlan()
        {
            var plan = new DevelopmentPlan(id: 1, level: "1");
            var maintheme = new MainTheme(id: 1, title: "eje tematico 1", description: "vías");
            maintheme.AddItems("primer vía");
            maintheme.AddItems("segunda vía");
            maintheme.AddItems("tercera vía");
            plan.AddMainTheme(maintheme);
            var result = plan.AddMainTheme(maintheme);
            Assert.AreEqual("Ya este eje temático fue agregado al plan", result);
        }
        
        [Test]
        public void ModifyMainThemeAdded()
        {
            var plan = new DevelopmentPlan(id: 1, level: "1");
            var maintheme = new MainTheme(id: 1, title: "eje tematico 1", description: "vías");
            maintheme.AddItems("primer vía");
            maintheme.AddItems("segunda vía");
            maintheme.AddItems("tercera vía");
            plan.AddMainTheme(maintheme);
            maintheme.AddItems("cuarta vía");
            maintheme.AddItems("quinta vía");
            var result = plan.UpdateMainTheme(maintheme);
            Assert.AreEqual("Se actualizo el eje temático", result);
        }
        
        [Test]
        public void ModifyMainThemeAddedFail()
        {
            var plan = new DevelopmentPlan(id: 1, level: "1");
            var maintheme = new MainTheme(id: 1, title: "eje tematico 1", description: "vías");
            maintheme.AddItems("primer vía");
            maintheme.AddItems("segunda vía");
            maintheme.AddItems("tercera vía");
            plan.AddMainTheme(maintheme);
            maintheme = new MainTheme(id: 2, title: "eje tematico 2", description: "vías");
            maintheme.AddItems("cuarta vía");
            maintheme.AddItems("quinta vía");
            var result = plan.UpdateMainTheme(maintheme);
            Assert.AreEqual("No existe este eje temático", result);
        }
    }
}