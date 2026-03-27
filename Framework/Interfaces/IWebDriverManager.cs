using OpenQA.Selenium;

namespace Core.Interfaces;

public interface IWebDriverManager
{
    IWebDriver Driver { get; }
}