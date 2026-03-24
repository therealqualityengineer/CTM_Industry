namespace Core.Interfaces;

public interface IConfig
{
    public string LoginUrl  { get; }
    public string BaseUrl  { get; }
    public string Username { get; }
    public string Password { get; }
    public string Browser  { get; }
}