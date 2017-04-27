using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web.UI.HtmlControls;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using ScrapySharp.Html;
using ScrapySharp.Html.Dom;
using ScrapySharp.Html.Forms;
using ScrapySharp.Network;
using System.Threading.Tasks;
using System.Web;

namespace PastebinKeywordScraper
{
    public class Scraper
    {
        private bool scrape;

        private ScraperConfig _config;

        private List<string> _pastes;

        private List<string> _keywords;

        private Queue<string> _downloaded;

        public Scraper(ScraperConfig config)
        {
            _pastes = new List<string>();
            _downloaded = new Queue<string>(12);

            _config = config;

            _keywords = _config.Keywords.Split(' ', '@', ':', '\"', '\'').ToList();

            Scrape();
        }

        public void StartScraping()
        {
            scrape = true;
        }

        public void StopScraping()
        {
            scrape = false;
        }

        public void Scrape()
        {
            while (scrape)
            {
                if (Directory.Exists(_config.Folder))
                {
                    GetPastes();
                    DownloadPastes();
                }
                else
                {
                    Directory.CreateDirectory(_config.Folder);
                }

                // Sleep the thread to save resources.
                Thread.Sleep(new TimeSpan(0, 0, _config.Delay));
            }
        }

        public void GetPastes()
        {
            ScrapingBrowser browser = new ScrapingBrowser();

            //set UseDefaultCookiesParser as false if a website returns invalid cookies format
            //browser.UseDefaultCookiesParser = false;

            WebPage homePage = browser.NavigateToPage(new Uri("http://www.pastebin.com/"));

            var rightMenu = homePage.Html.CssSelect("ul.right_menu");

            HtmlNode[] links = homePage.Html.CssSelect("ul.right_menu").ToArray();
            foreach (var element in links)
            {
                foreach (var childNode in element.ChildNodes)
                {

                    string linkText = childNode.SelectSingleNode("a").Attributes["href"].Value;

                    if (!_pastes.Contains(linkText))
                    {
                        Console.WriteLine(linkText);
                        _pastes.Add(linkText);
                    }
                }
            }
        }

        public void DownloadPastes()
        {
            if (_pastes.Count > 0)
            {
                foreach (var link in _pastes.ToList())
                {
                    if (_pastes.Contains(link))
                    {
                        DownloadPaste(link);
                    }
                }
            }
        }

        private void DownloadPaste(string link)
        {
            using (var client = new WebClient())
            {
                Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

                Uri url = new Uri("http://pastebin.com/raw" + link);

                string pasteText = client.DownloadString(url);

                bool containsKeyword = _keywords.Any(w => pasteText.Contains(w));

                if (containsKeyword)
                {
                    client.DownloadFile(url, _config.Folder.TrimEnd('/') + "/paste_" + link.TrimStart('/') + ".txt");
                    Console.WriteLine("[Scraping..] Downloading " + link);
                    _downloaded.Enqueue(link);
                    _pastes.Remove(link);
                }
                else
                {
                    _pastes.Remove(link);
                }
            }
        }
    }
}