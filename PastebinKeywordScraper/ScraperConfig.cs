using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace PastebinKeywordScraper
{
    [XmlRoot("config")]
    public class ScraperConfig
    {
        [XmlElement("output_folder")]
        public string Folder { get; set; }

        [XmlElement("scrape_keywords")]
        public string Keywords { get; set; }

        [XmlElement("scrape_delay")]
        public int Delay { get; set; }

        public ScraperConfig()
        {
            Folder = "scraped_pastes";

            Keywords = "keywords seperated by space";
            
            // Seconds
            Delay = 2;
        }
        public static ScraperConfig ReadSettings(string path)
        {
            var ser = new XmlSerializer(typeof(ScraperConfig));
            ScraperConfig settings = null;
            if (File.Exists(path))
            {
                using (var stream = File.OpenRead(path)) settings = (ScraperConfig)ser.Deserialize(stream);
            }
            else
            {
                using (var stream = File.OpenWrite(path)) ser.Serialize(stream, settings = new ScraperConfig());
            }
            return settings;
        }
        public static void WriteSettings(string path, ScraperConfig settings)
        {
            var ser = new XmlSerializer(typeof(ScraperConfig));
            var localSettings = settings;
            if (File.Exists(path))
            {
                using (var stream = new FileStream(path, FileMode.Truncate, FileAccess.ReadWrite)) ser.Serialize(stream, settings);
            }
            else
            {
                using (var stream = File.OpenWrite(path)) ser.Serialize(stream, new ScraperConfig());
            }
        }
    }

}