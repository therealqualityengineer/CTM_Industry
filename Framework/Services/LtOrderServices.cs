using Framework.Interfaces;
using Framework.UI.Pages;

namespace Framework.Services;

public class LtOrderServices : ILtOrderServices
{
    private readonly LtOrderPage _ltOrderPages;
    
    public LtOrderServices(LtOrderPage ltOrderPage)
    {
        _ltOrderPages = ltOrderPage;
    }

    public string CreateDefaultRatesheetForLtOrder()
    {
        return _ltOrderPages.CreateRateSheetFromLto();
    }
}