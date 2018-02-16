# AccessHQ Automation Exercise

This project executes an automated test on the https://transportnsw.info/trip page, to verify that the trip planner can accept valid location names and generate a list of results.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

* [NUnit] v3.9.0 (https://github.com/nunit/nunit3-vs-adapter) - Unit testing framework for .net languages
* [Nunit3TestAdapter] v3.9.0 (https://github.com/nunit/docswiki/VS-Adapter) - Adapter for NUnit to allow it to run tests from within Visual Studio
* [Selenium.WebDriver] v3.8.0 (http://www.seleniumhq.org/) - Automated testing framework for web browsers
* [geckodriver] v0.19.1 (https://github.com/mozilla/geckodriver) - Proxy to allow WebDriver to work with Firefox

### Installing

For development within VS2012+:
1. Download the version of GeckoDriver that's appropriate for your system and add the exe to your [system's PATH environmental variable.](https://en.wikipedia.org/wiki/PATH_(variable))
2. Open the project within VS2012 or later.
3. Within Visual Studio, use the NuGet Package Manager to install the following packages:
   * NUnit
   * NUnit3TestAdapter
   * Selenium.WebDriver

To run the test from within Visual Studio
Open the Test Explorer window (Test > Windows > Test Explorer), then right click on the 'TripSearchResultsTest' and select 'Run Selected Tests'.

## Authors

* **Mathieu Halley** - *Initial work* - [MathieuHalley](https://github.com/MathieuHalley)
