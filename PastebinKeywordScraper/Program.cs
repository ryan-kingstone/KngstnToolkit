using System;
using System.Runtime.InteropServices;

namespace PastebinKeywordScraper
{
    class Program
    {
        private static ScraperConfig _config;
        private static Scraper _scraper;

        static void Main(string[] args)
        {
            _config = ScraperConfig.ReadSettings("config.xml");

            _scraper = new Scraper(_config);

            _scraper.StartScraping();
            _scraper.Scrape();
        }
    }
}
