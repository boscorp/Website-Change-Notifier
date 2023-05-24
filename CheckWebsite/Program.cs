using System;
using System.Net.Http;
using System.Threading;

class Program
{
    // Store the previous content of the website
    static string previousContent = "";
    // HttpClient is intended to be instantiated once and re-used throughout the life of an application
    static HttpClient client = new HttpClient();

    static void Main(string[] args)
    {
        // Check if the user asked for help or provided incorrect arguments
        if (args.Length < 2 || args[0] == "-h" || args[0] == "--help")
        {
            DisplayHelp();
            return;
        }

        // Get the URL from the first argument
        string url = args[0];
        // Ensure the URL is an absolute URL
        if (!url.StartsWith("http://") && !url.StartsWith("https://"))
        {
            url = "http://" + url;
        }

        // Try to parse the time interval from the second argument
        if (!int.TryParse(args[1], out int interval))
        {
            Console.WriteLine("The provided time interval is not a valid number.");
            DisplayHelp();
            return;
        }

        // Continuously check the website for changes
        while (true)
        {
            CheckWebsite(url);
            Thread.Sleep(interval);
        }
    }

    // Asynchronously checks the website for changes
    static async void CheckWebsite(string url)
    {
        // Get the current content of the website
        string currentContent = await client.GetStringAsync(url);

        // If the content has changed, notify the change and update the previous content
        if (previousContent != currentContent)
        {
            NotifyChange();
            previousContent = currentContent;
        }
    }

    // Notifies that the website content has changed
    static void NotifyChange()
    {
        Console.WriteLine("The website has changed.");
    }

    // Displays help information
    static void DisplayHelp()
    {
        Console.WriteLine("Usage: dotnet run [URL] [Interval]");
        Console.WriteLine("URL: The URL of the website to monitor.");
        Console.WriteLine("Interval: The time interval in milliseconds between checks.");
    }
}
