using Framework.Interfaces;
using Framework.TestData;
using Reqnroll;
using Tests.Context;

namespace Tests.StepDefinitions;

[Binding]
public class OrderManagerSteps
{
    private readonly IOrderManagerServices _orderManagerServices;
    private readonly ResolveDynamic _resolveDynamic;
    private readonly ScenarioData _scenarioData;
    
    public OrderManagerSteps(IOrderManagerServices orderManagerServices, ResolveDynamic resolveDynamic, ScenarioData scenarioData)
    {
        _orderManagerServices = orderManagerServices;
        _resolveDynamic = resolveDynamic;
        _scenarioData = scenarioData;
    }


    [Given("user creates a order with following details")]
    public void GivenUserCreatesAOrderWithFollowingDetails(Reqnroll.Table table)
    {
        var orderData = table.Rows.ToDictionary(row => row[0], row => _resolveDynamic.ResolveDynamicValues(row[1]));
        var orderId = _orderManagerServices.CreateOrder(orderData);
        
        Assert.That(orderId, Is.Not.Null, "Order is not created");
        
        _scenarioData.Set(ScenarioKeys.OrderId, orderId);
        Console.WriteLine("Order created: " + _scenarioData.Get<string>(ScenarioKeys.OrderId));
    }
}