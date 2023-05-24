# Website Change Notifier

This is a simple C# console application that monitors a specified website for changes. It uses the `HttpClient` class to make HTTP requests to the website and compares the current content of the website with the previous content to detect changes.

The application accepts two command-line arguments: the URL of the website to monitor and the time interval in milliseconds between checks. If the content of the website changes, the application will call the `NotifyChange()` method, which prints a message to the console.

# Usage

```bash
dotnet run [URL] [Interval]
```

# Example
dotnet run https://example.com 5000

This will monitor the website at https://example.com and check for changes every 5 seconds.

# Limitations
Please note that this application is very basic and may not work correctly with websites that dynamically change their content with JavaScript. Also, this application does not handle errors, so it could fail if the website is not available or if there is some other network problem.



