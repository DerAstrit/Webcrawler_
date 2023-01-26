namespace Webcrawler;

public class InputOptions
{


    public void WriteOptions()
    {
        Console.WriteLine("type what option you want to use\n" +
                          "\n" +
                          "Single Site Download = single\n" +
                          "Multiple Site Download = multi\n" +
                          "Show statistic = stats\n");
    }
    
    public void SelectOptions()
    {
        string? chosenOption = Console.ReadLine();

        switch (chosenOption)
        {
            case "single":
                Single();
                break;
            
            case "multi":
                Multi();
                break;
            
            case "stats":
                Stats();
                break;

        }
    }
    
    // Single mode 
    private void Single()
        {
            LinkFinder linkFinder = new LinkFinder(); 
            WebsiteDownloader websiteDownloader = new WebsiteDownloader(); 
            string? url = linkFinder.InputUrl(); 
            websiteDownloader.DownloadWebsite(url);
        }

    
    
    // Multi mode
    private void Multi()
    {
        // Create a new LinkFinder and WebsiteDownloader instance
        LinkFinder linkFinder = new LinkFinder(); 
        WebsiteDownloader websiteDownloader = new WebsiteDownloader(); 
        
        // Put a Limit for Pages to download
        Console.WriteLine("\nEnter how many Links you want to download\n");
        int limit = Convert.ToInt32(Console.ReadLine());
        
        // Get all the Links and save them to links
        string? url = linkFinder.InputUrl();
        var links = LinkFinder.ParseLinks(url);
        
        // Limit the Links to the Limit set
        List<string> limitedLinks = links.Take(limit).ToList();

        // Foreach Link in Links Download
        limitedLinks.ForEach(link => {
            if (Uri.TryCreate(link, UriKind.Absolute, out var uri) && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps))
            {
                websiteDownloader.DownloadWebsite(link);
            }
        });

    }
    
    
    //Stats mode
    private void Stats()
    {
        LinkFinder linkFinder = new LinkFinder();
        string? url = linkFinder.InputUrl();
        linkFinder.ShowStats(url);
        
        Console.WriteLine("\nTo Exit the Webcrawler press any key");
        Console.ReadLine();
    }
}