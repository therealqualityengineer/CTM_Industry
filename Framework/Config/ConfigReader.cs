using Core.Interfaces;
using Microsoft.Extensions.Options;

namespace Framework.Config;

public class ConfigReader : IConfig
{
    private readonly TestSettings _settings;

    public ConfigReader(IOptions<TestSettings> options)
    {
        _settings = options.Value ?? throw new ArgumentNullException(nameof(options));
    }

    public string LoginUrl => _settings.LoginUrl;
    public string BaseUrl => _settings.BaseUrl;
    public string Username => _settings.Username;
    public string Password => _settings.Password;
    public string Browser => _settings.Browser;
}