using Core.Interfaces;
using Framework.Interfaces;
using Framework.UI.Pages;
using Infrastructure.UI.Pages;

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
}