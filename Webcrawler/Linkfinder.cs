using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Webcrawler;

public class Linkfinder
{


    public string? InputUrl()
    {
        Console.WriteLine("\nPlease Insert the Url");
        string? url = Console.ReadLine();
        return url;
    }


    public static List<string> ParseLinks(string? url)
    {
        List<string> links = new List<string>();
        HtmlWeb web = new HtmlWeb();
        HtmlDocument doc = web.Load(url);
        foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
        {
            HtmlAttribute att = link.Attributes["href"];
            if (att.Value.StartsWith("http"))
            {
                links.Add(att.Value);
            }
        }

        return links;

    }

    public void ShowStats(string? url)
    {
        List<string> links = ParseLinks(url);
        links.ForEach(link => Console.WriteLine(link));
        int linkCount = links.Count;
        Console.WriteLine("\n" +
                          "There were " +
                          "" + linkCount
                          + " Url's on this Page\n");
    }
    
}