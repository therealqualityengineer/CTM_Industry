namespace Core.Interfaces;

public interface ILoginService
{ 
    bool Login(string site, string user, string browser);
}