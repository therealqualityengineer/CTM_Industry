using Framework.Models;
using Reqnroll;

namespace Framework.Interfaces;

public interface ITempManagerServices
{
    public IDictionary<string,string> CreateTemp(Table table);
    public bool IsTempCreatedSuccessfully();
    public DefaultTempModel CreateDefaultTemp();
    public void EnterFlatPayBillAmount(Table table);
    public void IsFlatPayBillEnabledSuccessfully(string status);
    public void IsFlatPayBillAmountDisplayed(List<string?> amountDetails);
}