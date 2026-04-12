using Framework.Interfaces;
using Framework.UI.Pages;

namespace Framework.Services;

public class LtOrderServices : ILtOrderServices
{
    private readonly LtOrderPage _ltOrderPages;
    private readonly CommonPage _commonPage;
    
    public LtOrderServices(LtOrderPage ltOrderPage, CommonPage commonPage)
    {
        _ltOrderPages = ltOrderPage;
        _commonPage = commonPage;
    }

    public string CreateDefaultRatesheetForLtOrder()
    {
        return _ltOrderPages.CreateRateSheetFromLto();
    }

    public void OpenRatesheet(string ratesheetId)
    {
        _ltOrderPages.OpenRatesheet(ratesheetId);
    }

    public void AddChangestoRatesheetId(string item, List<Dictionary<string,string>> itemTable)
    {
        int n = 0;
        foreach (var row in itemTable)
        {
            if (item.Equals("Taxable Item"))
            {
                _ltOrderPages.AddTaxableItem();   
            }
            else if (item.Equals("Non Taxable Item"))
            {
                _ltOrderPages.AddNonTaxableItem();
            }

            n = n + 1;
            foreach (var field in row)
            {
                var header = field.Key;
                var value = field.Value;

                if (!value.Contains("N/A"))
                {
                    _ltOrderPages.AddChangestoRatesheet(header, value, n);
                }
            }
        }
    }

    public void SaveRatesheet()
    {
        _ltOrderPages.SaveRatesheet();
    }
}