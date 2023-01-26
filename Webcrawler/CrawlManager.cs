

namespace Webcrawler;


public class CrawlManager
{


    public void Start()
    {
        InputOptions inputOptions = new InputOptions();
        Intro();
        inputOptions.WriteOptions();
        inputOptions.SelectOptions();
    }
    
      
    private void Intro()
    {
        Console.WriteLine("\nWelcome to the Webcrawler \n" +
                          "This Tool is for learn purposes and should not be abused \n" +
                          "THANKS!\n" +
                          "");
    }

}