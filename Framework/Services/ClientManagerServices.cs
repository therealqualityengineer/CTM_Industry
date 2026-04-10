using Framework.Interfaces;
using Framework.Models;
using Framework.TestData;
using Framework.UI.Pages;
using Reqnroll;

namespace Framework.Services;

public class ClientManagerServices : IClientManagerServices
{
    private readonly ClientManagerPage _clientManagerPage;
    private readonly TestDataGenerator _data;
    
    public ClientManagerServices(ClientManagerPage clientManagerPage, TestDataGenerator data)
    {
        _clientManagerPage = clientManagerPage;
        _data = data;
    }

    public IDictionary<string,string> CreateClient(Table table)
    {
        var input = table.Rows.ToDictionary(row => row[0], row => _data.Resolve(row[1]));

        var clientData = new ClientModel
        {
            ClientName =  input["ClientName"],
            Status =  input["Status"],
            Region =   input["Region"],
            Address =  input["Address"],
            City =  input["City"],
            State =  input["State"],
            Zip =  input["Zip"],
            //QuickbooksId =  input["QuickbooksId"],
        };
        
        _clientManagerPage.ClickNew();
        _clientManagerPage.EnterClientName(clientData.ClientName);
        _clientManagerPage.EnterAddress(clientData.Address);
        _clientManagerPage.EnterCity(clientData.City);
        _clientManagerPage.EnterState(clientData.State);
        _clientManagerPage.EnterZip(clientData.Zip);
        _clientManagerPage.SelectStatus(clientData.Status);
        _clientManagerPage.SelectRegion(clientData.Region);
        //_clientManagerPage.QuickBooksId(clientData.QuickbooksId);
        
        _clientManagerPage.ClickSave();
        
        var clientId = _clientManagerPage.GetClientId();
        input.Add("ClientId", clientId);
        
        return input;
    }

    public bool IsClientCreatedSuccessfully()
    {
        return _clientManagerPage.IsClientCreatedSuccessfully();
    }
}