public class WelcomeService: IWelcomeService
{
    public string GetWelcomeMessage()
    {
        return "Welcome to the .NET Core Web API";
    }
}

public interface IWelcomeService
{
    string GetWelcomeMessage();
}