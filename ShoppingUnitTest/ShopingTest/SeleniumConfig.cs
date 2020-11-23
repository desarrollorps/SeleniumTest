using RPSSeleniumProperties;
using System;

public sealed class SeleniumConfig
{
    public static SeleniumConfig Current = new SeleniumConfig();
    public string driverpath = $"U:\\Selenium\\";
    public string rpsurl = "http://localhost/RPSNextShopping/";
    public string user = "admin";
    public string password = "admin";
    public string company = "DEMOS";
    public SeleniumConfig()
    {
        SeleniumHelper.SeleniumFactoryConfig.ChromeDriverPath = driverpath;
        RPSEnvironment.RPSBaseURL = rpsurl;
        RPSEnvironment.DefaultUser = user;
        RPSEnvironment.DefaultPassword = password;
        RPSEnvironment.DefaultCodCompany = company;
    }
    ~SeleniumConfig()
    {
        Dispose();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        // Run at end
    }
}