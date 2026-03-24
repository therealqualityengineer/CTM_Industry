using OpenQA.Selenium;

namespace Core.Interfaces;

public interface IWebDriverManager
{
    void InitDriver(string browser);
    IWebDriver GetDriver();
    void QuitDriver();
}