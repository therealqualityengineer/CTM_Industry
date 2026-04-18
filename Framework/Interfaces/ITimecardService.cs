namespace Framework.Interfaces;

public interface ITimecardService
{
    bool TimecardReconciled(string orderid);
}