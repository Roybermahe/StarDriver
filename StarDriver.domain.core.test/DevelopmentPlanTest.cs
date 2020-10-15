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
            var Plan = new DevelopmentPlan(identification: 1, level: "1");
        }
        
    }
}