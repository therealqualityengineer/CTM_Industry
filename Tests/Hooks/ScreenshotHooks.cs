
using Allure.Net.Commons;
using Core.Interfaces;
using OpenQA.Selenium;
using Reqnroll;

namespace Tests.Hooks;

[Binding]
public class ScreenshotHooks
{
    private readonly ScenarioContext _scenarioContext;
    private readonly IWebDriver _driver;

    public ScreenshotHooks(ScenarioContext scenarioContext, IWebDriverManager driverManager)
    {
        _scenarioContext = scenarioContext;
        _driver = driverManager.Driver;
    }

    [AfterStep]
    public void TakeScreenshotOnFailure()
    {
        if (_scenarioContext.TestError != null)
        {
            var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();

            AllureApi.AddAttachment(
                "Screenshot on failure",
                "image/png",
                screenshot.AsByteArray
            );
        }
    }
}
