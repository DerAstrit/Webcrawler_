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
    public void Single()
        {
            Linkfinder linkFinder = new Linkfinder(); 
            WebsiteDownloader websiteDownloader = new WebsiteDownloader(); 
            string? url = linkFinder.InputUrl(); 
            websiteDownloader.DownloadWebsite(url);
        }

    public void Multi()
    {
        Console.WriteLine("Enter how many Links you want to download\n");
        int limit = Convert.ToInt32(Console.ReadLine());
        
        Linkfinder linkFinder = new Linkfinder(); 
        WebsiteDownloader websiteDownloader = new WebsiteDownloader(); 
        
        string? url = linkFinder.InputUrl();
        var links = Linkfinder.ParseLinks(url);
        
        List<string> limitedLinks = links.Take(limit).ToList();

        limitedLinks.ForEach(link => {
            Uri uri;
            if (Uri.TryCreate(link, UriKind.Absolute, out uri) && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps))
            {
                websiteDownloader.DownloadWebsite(link);
            }
        });

    }
    
    public void Stats()
    {
        Linkfinder linkFinder = new Linkfinder();
        string? url = linkFinder.InputUrl();
        linkFinder.ShowStats(url);
        Console.ReadLine();
    }
}