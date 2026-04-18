using Framework.Interfaces;
using Reqnroll;
using Tests.Context;

namespace Tests.StepDefinitions;

[Binding]
public class TimecardStep
{
    private readonly ITimecardService _timecardService;
    private readonly ResolveDynamic _resolveDynamic;

    public TimecardStep(ITimecardService timecardService, ResolveDynamic resolveDynamic)
    {
        _timecardService = timecardService;
        _resolveDynamic = resolveDynamic;
    }
    
    [Given("the user reconciled the {string} in staffing timecard popup")]
    public void GivenTheUserReconciledTheInStaffingTimecardPopup(string orderid)
    {
        var orderId = _resolveDynamic.ResolveDynamicValues(orderid);
        bool isTimecardReconciled = _timecardService.TimecardReconciled(orderId);
        Assert.That(isTimecardReconciled, Is.True, "Timecard Reconciled Failed");
    }
}