using Core.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Config;

public class ConfigReader : IConfig
{
    private readonly IConfiguration _config;
    
    public ConfigReader(IConfiguration config)
    {
        _config = config;
    }

    public string LoginUrl =>  _config["TestSettings:LoginUrl"];
    public string BaseUrl =>  _config["TestSettings:BaseUrl"];
    public string Username =>  _config["TestSettings:Username"];
    public string Password =>  _config["TestSettings:Password"];
    public string Browser =>  _config["TestSettings:Browser"];
}