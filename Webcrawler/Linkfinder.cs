using System.Collections.Concurrent;
using System.Net;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Webcrawler;

public class Linkfinder
{
    
    
    public string? InputUrl()
    {
        Console.WriteLine("Please Insert the Url you want to Download");
        string? url = Console.ReadLine();
        return url;
    }

    public List<string> ParseLinks(string? url)
    {
        var links = new List<string>();

// Create a new instance of the Chrome driver
        using (var driver = new ChromeDriver())
        {
            // Navigate to the website
            driver.Navigate().GoToUrl(url);

            // Find all the anchor tags on the page
            var anchorTags = driver.FindElements(By.TagName("a"));

            // Iterate through the anchor tags and add the href attribute to the links list
            foreach (var tag in anchorTags)
            {
                var href = tag.GetAttribute("href");
                if (href != null)
                {
                    links.Add(href);
                }
        
            }
        }

        return links;
    }

    public void ShowStats(string? url)
    {
        List<string> links = ParseLinks(url);
        int linkCount = links.Count;
        Console.WriteLine("\n" +
                          "There were " +
                          "" + linkCount
                          + " Url's on this Page\n");
        
        links.ForEach(link => Console.WriteLine(link));

    }

}