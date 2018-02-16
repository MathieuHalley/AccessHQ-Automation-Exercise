using OpenQA.Selenium;

namespace TripPlannerTestSuite
{
    // A base class for initializing common variables
    public abstract class TripPlannerBase
    {
        protected readonly IWebDriver driver;

        protected TripPlannerBase(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}