using Framework.Interfaces;
using Framework.Models;
using Framework.TestData;
using Framework.UI.Pages;
using Infrastructure.UI.Pages;
using Reqnroll;

namespace Framework.Services;

public class OrderManagerServices : IOrderManagerServices
{
    private readonly OrderManagerPage _orderManagerPage;
    private readonly TestDataGenerator _data;
    
    public OrderManagerServices(OrderManagerPage orderManagerPage, TestDataGenerator data)
    {
        _orderManagerPage = orderManagerPage;
        _data = data;
    }

    public string CreateOrder(Dictionary<string,string> inputData)
    {
        var input = inputData.ToDictionary(kvp => kvp.Key, kvp => _data.Resolve(kvp.Value));

        var orderData = new OrderModel
        {
            ClientName = input["ClientName"],
            TempName =  input["TempName"],
            Shiftdate =  input["ShiftDate"],
            ShiftId = input["ShiftId"],
            Certification =  input["Certification"],
            Specialty =  input["Specialty"]
        };
        
        _orderManagerPage.ClickNew();
        _orderManagerPage.SwitchToEditOrderWindow();
        _orderManagerPage.EnterClientName(orderData.ClientName);
        _orderManagerPage.EnterTempName(orderData.TempName);
        _orderManagerPage.StartDate(orderData.Shiftdate);
        _orderManagerPage.SelectShiftId(orderData.ShiftId);
        _orderManagerPage.SelectCertification(orderData.Certification);
        _orderManagerPage.SelectSpecialty(orderData.Specialty);
        _orderManagerPage.CreateDone();
        _orderManagerPage.TempConfirmYn(); 
        _orderManagerPage.ClientConfirmYn();
        _orderManagerPage.FillOrder();
        _orderManagerPage.SwitchToOrderManagerWindow();
        _orderManagerPage.NavigateToNewOrderPage();
        _orderManagerPage.ClientSearchinOrderSearchBox(orderData.ClientName);

       return _orderManagerPage.GetorderId();
    }
}