using HtmlAgilityPack;
using System.Net;

namespace Webcrawler;

public class WebsiteDownloader
{

    public void DownloadWebsite(string? url)
    {

        Console.WriteLine("\nWrite the Path of the Directory that you want to save the files from");

        // Create directory to store website if it doesn't exist
        string? dir = Console.ReadLine();
        if (!Directory.Exists(dir))
        {
            if (dir != null) Directory.CreateDirectory(dir);
        }



        // Download HTML from website
        HtmlWeb web = new HtmlWeb();
        HtmlDocument? doc = web.Load(url);



        // Save HTML to file
        var htmlPath = $"{dir}/index.html";
        File.WriteAllText(htmlPath, doc.DocumentNode.OuterHtml);



        // Find all linked CSS, JS and image files
        if (url != null)
        {
            Uri baseUrl = new Uri(url);

            HtmlNodeCollection? cssNodes = doc.DocumentNode.SelectNodes("//link[@rel='stylesheet']");
            HtmlNodeCollection? jsNodes = doc.DocumentNode.SelectNodes("//script[@src]");
            HtmlNodeCollection? imgNodes = doc.DocumentNode.SelectNodes("//img");


            if (dir != null)
            {
                SaveCssNodes(cssNodes, dir, baseUrl);
                SaveImgNodes(imgNodes, dir, baseUrl);
                SaveJsNodes(jsNodes, dir, baseUrl);
            }
        }

        void SaveCssNodes(HtmlNodeCollection? cssNodes, string directoryName, Uri baseUrl)
        {
            // Download and save CSS files
            if (cssNodes != null)
            {
                foreach (var cssNode in cssNodes)
                {
                    string cssUrl = cssNode.Attributes["href"].Value;
                    string cssPath = $"{directoryName}/{Path.GetFileName(cssUrl)}";

                    try
                    {
                        DownloadFile(baseUrl, cssUrl, cssPath);
                    }
                    catch (WebException ex)
                    {
                        //Log the exception or do any other error handling
                        Console.WriteLine("An error occurred while trying to download a file: " + ex.Message +
                                          "\n  resources may be hosted on external servers!!!");
                    }
                }
            }
        }

        void SaveImgNodes(HtmlNodeCollection? imgNodes, string directoryName, Uri baseUrl)
        {
            // Download and save image files
            if (imgNodes != null)
            {
                foreach (var imgNode in imgNodes)
                {
                    string imgUrl = imgNode.Attributes["src"].Value;
                    string imgPath = $"{directoryName}/{Path.GetFileName(imgUrl)}";

                    try
                    {
                        DownloadFile(baseUrl, imgUrl, imgPath);
                    }
                    catch (WebException ex)
                    {
                        //Log the exception or do any other error handling
                        Console.WriteLine("An error occurred while trying to download a file: " + ex.Message +
                                          "\n  resources may be hosted on external servers!!!");
                    }
                }
            }
        }

        void SaveJsNodes(HtmlNodeCollection? jsNodes, string directoryName, Uri baseUrl)
        {
            // Download and save image files
            if (jsNodes != null)
            {
                foreach (var jsNode in jsNodes)
                {
                    string jsUrl = jsNode.Attributes["src"].Value;
                    string jsPath = $"{directoryName}/{Path.GetFileName(jsUrl)}";

                    try
                    {
                        DownloadFile(baseUrl, jsUrl, jsPath);
                    }
                    catch (WebException ex)
                    {
                        //Log the exception or do any other error handling
                        Console.WriteLine("An error occurred while trying to download a file: " + ex.Message +
                                          "\n  resources may be hosted on external servers!!!");
                    }
                }
            }
        }


        static void DownloadFile(Uri baseUrl, string url, string path)
        {
            if (!string.IsNullOrEmpty(url))
            {
                if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
                {
                    // if the url is not absolute, construct a new Uri using the baseUrl
                    url = new Uri(baseUrl, url).AbsoluteUri;
                }

                WebClient client = new WebClient();
                Uri absoluteUrl = new Uri(url);
                client.DownloadFile(absoluteUrl, path);
            }
        }
    }
}

