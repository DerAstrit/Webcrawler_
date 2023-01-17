using HtmlAgilityPack;
using System.Net;

namespace Webcrawler;

public class WebsiteDownloader
{
    public void DownloadWebsite(string url)
    {

        // Download HTML from website
        var web = new HtmlWeb();
        var doc = web.Load(url);

        // Create directory to store website if it doesn't exist
        Console.WriteLine("Write the Path of the Directory that you want to save the files from");
        var dir = Console.ReadLine();
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        // Save HTML to file
        var htmlPath = $"{dir}/index.html";
        File.WriteAllText(htmlPath, doc.DocumentNode.OuterHtml);

        // Download and save CSS and images
        var baseUrl = new Uri(url);
        var cssNodes = doc.DocumentNode.SelectNodes("//link[@rel='stylesheet']");
        var imgNodes = doc.DocumentNode.SelectNodes("//img");

// Download and save CSS files
        if (cssNodes != null)
        {
            foreach (var cssNode in cssNodes)
            {
                var cssPath = $"{dir}/styles.css";
                
                
                var cssUrl = cssNode.Attributes["href"].Value;
                var cssUri = new Uri(cssUrl);
                /*var cssPath = $"{dir}/{Path.GetFileName(cssUri.LocalPath)}";*/
                DownloadFile(baseUrl, cssUrl, cssPath);
            }
        }

        // Download and save image files
        if (imgNodes != null)
        {
            foreach (var imgNode in imgNodes)
            {
                var imgPath = $"{dir}";
                var imgUrl = imgNode.Attributes["src"].Value;
                var imgUri = new Uri(imgUrl);
                /*var imgPath = $"{dir}/{Path.GetFileName(imgUri.LocalPath)}";*/
                DownloadFile(baseUrl, imgUrl, imgPath);
            }
        }
    }
    static void DownloadFile(Uri baseUrl, string url, string path)
    {
        using (var client = new WebClient())
        {
            var absoluteUrl = new Uri(baseUrl, url);
            client.DownloadFile(absoluteUrl, path);
        }
    }
}

