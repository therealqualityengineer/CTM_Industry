namespace Framework.Interfaces;

public interface ILtOrderServices
{
    public string CreateDefaultRatesheetForLtOrder();
    public void OpenRatesheet(string ratesheetId);
    public void AddChangestoRatesheetId(string item, List<Dictionary<string,string>> itemTable);
    public void SaveRatesheet();
}