using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace TripPlannerTestSuite
{
    //  A collection of notable elements on the trip planner page
    public class TripPlannerElementMap : TripPlannerBase
    {
        public IWebElement SearchInputFrom => driver.FindElement(By.Id("search-input-From"));
        public IWebElement SearchInputTo => driver.FindElement(By.Id("search-input-To"));
        public IWebElement SearchButton => driver.FindElement(By.Id("search-button"));
        public IWebElement SearchResultsContainer => driver.FindElement(By.CssSelector("trip-results"));
        public ReadOnlyCollection<IWebElement> SearchResultList => driver.FindElements(By.CssSelector("div[class*='tripResults']"));

        //  Constructor
        public TripPlannerElementMap(IWebDriver driver) : base(driver) { }
    }
}