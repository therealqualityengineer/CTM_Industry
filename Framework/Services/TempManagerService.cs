using Framework.Interfaces;
using Framework.TestData;
using Framework.UI.Pages;
using Reqnroll;

namespace Framework.Services;

public class TempManagerService : ITempManagerServices
{
    private readonly TempManagerPage _page;
    private readonly TestDataGenerator _data;

    public TempManagerService(
        TempManagerPage page,
        TestDataGenerator data)
    {
        _page = page;
        _data = data;
    }

    public IDictionary<string,string> CreateTemp(Table table)
    {
        var input = table.Rows.ToDictionary(r => r[0], r => _data.Resolve(r[1]));

        _page.ClickNew();
        _page.EnterFirstName(input["FirstName"]);
        _page.EnterLastName(input["LastName"]);
        _page.EnterEmail(input["PrimaryEmail"]);
        _page.EnterAddress(input["Address"]);
        _page.EnterCity(input["City"]);
        _page.EnterState(input["State"]);
        _page.EnterZip(input["Zip"]);
        _page.SelectStatus(input["Status"]);
        _page.SelectHomeRegion(input["HomeRegion"]);
        _page.SelectContract(input["ContractEE"]);
        _page.SelectCertification(input["Certification"]);
        _page.SelectSpecialty(input["Specialty"]);
        _page.ClickSave();
        
        
        var tempId = _page.GetTempId();
        input.Add("TempId", tempId);
        return input;
    }

    public bool IsTempCreatedSuccessfully()
    {
        return _page.IsTempCreatedSuccessfully();
    }
}