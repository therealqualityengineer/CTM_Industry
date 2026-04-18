using Framework.Interfaces;
using Framework.UI.Actions;
using Framework.UI.Pages;

namespace Framework.Services;

public class TimecardService : ITimecardService
{
    private readonly TimecardPage _timecardPage;
    private readonly CommonPage _commonPage;
    
    public TimecardService(TimecardPage timecardPage, CommonPage commonPage)
    {
        _timecardPage = timecardPage;   
        _commonPage = commonPage;
    }

    public bool TimecardReconciled(string orderid)
    {
        _commonPage.NavigateToPage("index2.cfm?action=timecard.getTimecardManager");
        _timecardPage.OpenTimecard(orderid);
        return _timecardPage.SaveTimecard();
    }
}