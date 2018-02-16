using OpenQA.Selenium;

namespace TripPlannerTestSuite
{
    //  This class is used to confirm various states within the page
    public class TripPlannerValidator : TripPlannerBase
    {
        //  An instance of the element map
        protected TripPlannerElementMap Map => new TripPlannerElementMap(driver);

        //  Constructor
        public TripPlannerValidator(IWebDriver driver) : base(driver) { }

        //  Confirm that both the from & to inputs have had their contents validated
        public bool IsTripSearchInputValid()
        {
            //  The search input elements have very dynamic membership to a number of classes, at any one time they're each typically a member of 10+ classes
            var isFromInputValid = !Map.SearchInputFrom.GetAttribute("class").Contains("ng-invalid-remove-active");
            var isToInputValid = !Map.SearchInputTo.GetAttribute("class").Contains("ng-invalid-remove-active");

            return isFromInputValid && isToInputValid;
        }

        //  Confirm that the trip search is complete by checking whether the results container is visible
        public bool IsTripSearchComplete()
        {
            return Map.SearchResultsContainer.Displayed;
        }
    }
}