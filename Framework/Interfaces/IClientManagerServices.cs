using Reqnroll;

namespace Framework.Interfaces;

public interface IClientManagerServices
{
    IDictionary<string,string> CreateClient(Table table);
    bool IsClientCreatedSuccessfully();
}