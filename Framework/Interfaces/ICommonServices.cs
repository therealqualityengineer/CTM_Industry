namespace Framework.Interfaces;

public interface ICommonServices
{
    public void NavigateToTab(string tabName);
    public void NavigateToPage(string pageName);
    public void VerifyTextDisplayed(List<string?> expectedTextList);
    public void NavigateToProfilePage(string profileName,  string id);
    public void FilterOnNewSearchBox(Dictionary<string, string> filterValues);
}