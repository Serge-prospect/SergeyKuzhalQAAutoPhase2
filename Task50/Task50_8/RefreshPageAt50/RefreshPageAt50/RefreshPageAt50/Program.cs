using OpenQA.Selenium.Chrome;

namespace RefreshPageAt50
{
    class Program
    {
        const int PCT_AMOUNT = 50;
        static readonly int[] _timeOutAndPollTime = new int[2] { 60, 2 };

        static void Main(string[] args)
        {
            var driver = new ChromeDriver(".");
            var page = BootstrapDownloadProgressDemoPage.GoToBootstrapDownloadProgressDemoPage(driver, _timeOutAndPollTime);
            
            page.GetelementBy(page.DownloadButton)?.Click();

            if (page.IsProgressAchievedPctAmount(PCT_AMOUNT))
                page.RefreshPage();
            
            driver.Quit();
        }
    }
}
