

namespace Webcrawler;


public class CrawlManager
{
    
    
    
    public void Intro()
    { 
        Console.WriteLine("Welcome to the Webcrawler \n" +
                        "This Tool is for learn purpuses and should not be abused \n" +
                        "THANKS!\n" +
                        "");
    }

    public void Start()
    {
        InputOptions inputOptions = new InputOptions();
        Intro();
        inputOptions.WriteOptions();
        inputOptions.SelectOptions();
    }

}