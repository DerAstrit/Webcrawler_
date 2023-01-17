namespace Webcrawler;

public class InputOptions
{
    public void Options()
    {
        Console.WriteLine("type what option you want to use\n" +
                          "\n" +
                          "Single Site Download = --single\n" +
                          "Multiple Site Download = --multiple\n" +
                          "Show statistic = --stats");
        
        
        Linkfinder linkFinder = new Linkfinder();
        WebsiteDownloader websiteDownloader = new WebsiteDownloader();
        
        string chosenOption = Console.ReadLine();
        string? url;
        switch (chosenOption)
        {
            case "--single":
                
                url = linkFinder.InputUrl();
                websiteDownloader.DownloadWebsite(url);
                break;
            
            case "--multiple":
                ;
                break;
            
            case "--stats":
                
                
                url = linkFinder.InputUrl();
                linkFinder.ShowStats(url);
                
                break;

        }
    }
}