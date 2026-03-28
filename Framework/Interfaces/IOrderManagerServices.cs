using Reqnroll;

namespace Framework.Interfaces;

public interface IOrderManagerServices
{
    string CreateOrder(Dictionary<string,string> inputData);
}