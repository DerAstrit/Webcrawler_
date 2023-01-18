namespace Webcrawler;

public class InputOptions
{


    public void WriteOptions()
    {
        Console.WriteLine("type what option you want to use\n" +
                          "\n" +
                          "Single Site Download = single\n" +
                          "Multiple Site Download = multiple\n" +
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
        
    }
    public void Stats()
    {
        Linkfinder linkFinder = new Linkfinder();
        string? url = linkFinder.InputUrl();
        linkFinder.ShowStats(url);
    }
}