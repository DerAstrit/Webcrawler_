

namespace Webcrawler;


public class CrawlManager
{
    InputOptions inputOptions = new InputOptions();
    
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
        inputOptions.Options();

        
        
    }

}