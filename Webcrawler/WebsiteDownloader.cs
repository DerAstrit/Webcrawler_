using HtmlAgilityPack;
using System.Net;

namespace Webcrawler;

public class WebsiteDownloader
{

    public void DownloadWebsite(string? url)
    {
        // Create directory to store website if it doesn't exist
        Console.WriteLine("\nWrite the Path of the Directory that you want to save the files from");
        
        string? dir = Console.ReadLine();
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        
        // Download HTML from website
        HtmlWeb web = new HtmlWeb();
        var doc = web.Load(url);
        
        // Save HTML to file
        string? htmlPath = $"{dir}/index.html";
        File.WriteAllText(htmlPath, doc.DocumentNode.OuterHtml);

        // Download and save CSS and images
        Uri baseUrl = new Uri(url);
        HtmlNodeCollection cssNodes = doc.DocumentNode.SelectNodes("//link[@rel='stylesheet']");
        HtmlNodeCollection imgNodes = doc.DocumentNode.SelectNodes("//img");

        // Download and save CSS files
        if (cssNodes != null)
        {
            foreach (var cssNode in cssNodes)
            {
                string cssUrl = cssNode.Attributes["href"].Value;
                string cssPath = $"{dir}/{Path.GetFileName(cssUrl)}";
                
                try
                {
                    DownloadFile(baseUrl, cssUrl, cssPath);
                }
                catch (WebException ex)
                {
                    //Log the exception or do any other error handling
                    Console.WriteLine("An error occurred while trying to download a file: " + ex.Message);
                }
            }
        }

        // Download and save image files
        if (imgNodes != null)
        {
            foreach (var imgNode in imgNodes)
            {
                string imgUrl = imgNode.Attributes["src"].Value;
                string imgPath = $"{dir}/{Path.GetFileName(imgUrl)}";
                
                try
                {
                    DownloadFile(baseUrl, imgUrl, imgPath);
                }
                catch (WebException ex)
                {
                    //Log the exception or do any other error handling
                    
                }
            }
        }
    }

    static void DownloadFile(Uri baseUrl, string url, string path)
    {
        using (var client = new WebClient())
        {
            Uri absoluteUrl = new Uri(baseUrl, url);
            client.DownloadFile(absoluteUrl, path);
        }
    }
}

