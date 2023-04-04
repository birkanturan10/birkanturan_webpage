using Microsoft.AspNetCore.Mvc;
using System.Xml;
using System.Xml.Linq;

namespace birkanturan_webpage.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //Kur
            string url = "https://www.tcmb.gov.tr/kurlar/today.xml";

            var xmlDoc = new XmlDocument();

            xmlDoc.Load(url);

            string usd = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            usd = usd.Substring(0, 5);
            ViewBag.dolarkuru = usd;

            string euro = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            euro = euro.Substring(0, 5);
            ViewBag.eurokuru = euro;

            //Hava Durumu
            string city = "İzmir";

            string key = "52b72dad903d5a0244a91d029fce3686";

            string urll = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "&mode=xml&lang=tr&units=metric&appid=" + key + "";

            XDocument hava = XDocument.Load(urll);

            var sicaklik = hava.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            var durum = hava.Descendants("weather").ElementAt(0).Attribute("value").Value;

            var icon = hava.Descendants("weather").ElementAt(0).Attribute("icon").Value;

            var iconurl = "https://api.openweathermap.org/img/w/" + icon + ".png";

            ViewBag.sicaklik = sicaklik;

            ViewBag.durum = durum;

            ViewBag.iconurl = iconurl;

            ViewBag.city = city;

            return View();
        }
    }
}
