using System.Diagnostics;
using Core.Interfaces;
using Framework.Interfaces;
using Framework.UI.Pages;
using Infrastructure.UI.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Framework.Services;

public class CommonServices : ICommonServices
{
    private readonly CommonPage _commonPage;

    public CommonServices(CommonPage commonPage)
    {
        _commonPage = commonPage;
    }

    public void NavigateToTab(string tabName)
    {
        _commonPage.NavigateToTab(tabName);
    }

    public void NavigateToPage(string pageName)
    {
        _commonPage.NavigateToPage(pageName); 
    }

    public void VerifyTextDisplayed(List<string?> expectedTextList)
    {
        var failedTextList = new List<string>();

        foreach (var expectedText in expectedTextList)
        {
            if (expectedText != null && !_commonPage.IsTextsDisplyed(expectedText))
            {
                failedTextList.Add(expectedText);
            }
        }
        if (failedTextList.Any())
        {
            Assert.Fail($"These texts were NOT displayed: {string.Join(", ", failedTextList)}");
        }
    }
    
    public void NavigateToProfilePage(string profileName, string id)
    {
        _commonPage.NavigateTo(profileName, id);
    }

    public void FilterOnNewSearchBox(Dictionary<string, string> filterValues)
    {
        _commonPage.ResetSearchBox();
        foreach (var filterValue in filterValues)
        {
            _commonPage.TypeInNewSearchBox(filterValue.Key, filterValue.Value);
        }
        _commonPage.SubmitSearch();
    }
}