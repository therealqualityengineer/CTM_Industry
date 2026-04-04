using System.Text.Json;
using Framework.Interfaces;
using Framework.Models;
using Framework.TestData;
using Framework.UI.Pages;
using NUnit.Framework;
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

    public DefaultTempModel CreateDefaultTemp()
    {
        var path = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "TestData",
            "Json",
            "Default_Temp.json"
        );
        
        var jason = File.ReadAllText(path);
        
        var data = JsonSerializer.Deserialize<DefaultTempModel>(jason);

        var resolvedData = new DefaultTempModel
        {
            FirstName = _data.Resolve(data.FirstName),
            LastName = _data.Resolve(data.LastName),
            Email = _data.Resolve(data.Email),
            Address = _data.Resolve(data.Address),
            City = _data.Resolve(data.City),
            State = _data.Resolve(data.State),
            Zip = _data.Resolve(data.Zip),
            Status = _data.Resolve(data.Status),
            Region = _data.Resolve(data.Region),
            Specialty = _data.Resolve(data.Specialty),   
            Certification = _data.Resolve(data.Certification),
            ContractEE =  _data.Resolve(data.ContractEE),
        };
        
        _page.ClickNew();
        _page.EnterFirstName(resolvedData.FirstName);
        _page.EnterLastName(resolvedData.LastName);
        _page.EnterEmail(resolvedData.Email);
        _page.EnterAddress(resolvedData.Address);
        _page.EnterCity(resolvedData.City);
        _page.EnterState(resolvedData.State);
        _page.EnterZip(resolvedData.Zip);
        _page.SelectStatus(resolvedData.Status);
        _page.SelectHomeRegion(resolvedData.Region);
        _page.SelectContract(resolvedData.ContractEE);
        _page.SelectCertification(resolvedData.Certification);
        _page.SelectSpecialty(resolvedData.Specialty);
        _page.ClickSave();
        
        resolvedData.TempId = _page.GetTempId();
        
        return resolvedData;
    }

    public void EnterFlatPayBillAmount(Table table)
    {
        var flatPayBillAmount = table.Rows.ToDictionary(row => row[0],row => row[1]);
        
        _page.ClickTempSubnav("Pay");
        _page.ClickPayEdit();
        _page.ClickFlatEnable();
        
        foreach (var amount in flatPayBillAmount)
        {
            if(amount.Key == "PayFlat")
                _page.EnterFlatPayBill(amount.Key, amount.Value);
            else if (amount.Key == "BillFlat")
                _page.EnterFlatPayBill(amount.Key, amount.Value);
            else
                Assert.Fail($"{amount.Key} is not a valid option.");
        }
        _page.TemppaySave();
    }

    public void IsFlatPayBillEnabledSuccessfully(string status)
    {
        Assert.That(_page.IsFlatPayBillEnabled(status), Is.True, $"Flat pay bill status is not {status}");
    }

    public void IsFlatPayBillAmountDisplayed(List<string?> amountDetails)
    {
        foreach (var amount in amountDetails)
        {
            Assert.That(_page.IsFlatPayAmountDisplayed(amount), Is.True, $"Flat {amount} amount is not displayed");
        }
    }
}