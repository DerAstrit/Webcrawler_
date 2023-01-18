

namespace Webcrawler;


public class CrawlManager
{
    InputOptions _inputOptions = new InputOptions();
    WebsiteDownloader _websiteDownloader = new WebsiteDownloader();
    
    public void Intro()
    { 
        Console.WriteLine("Welcome to the Webcrawler \n" +
                        "This Tool is for learn purpuses and should not be abused \n" +
                        "THANKS!\n" +
                        "");

    }

    public void Start()
    {
        Intro();
        _inputOptions.WriteOptions();
        _inputOptions.SelectOptions();
 


    }

}