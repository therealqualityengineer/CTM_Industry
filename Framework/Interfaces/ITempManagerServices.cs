using Reqnroll;

namespace Framework.Interfaces;

public interface ITempManagerServices
{
    public IDictionary<string,string> CreateTemp(Table table);
    public bool IsTempCreatedSuccessfully();
}