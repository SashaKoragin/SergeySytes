using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace LibarySyte.ParseSyte.Olimpikz.Parse
{
   public class ParseOlimp
    {
        public string HtmlParse()
        {
            string text;
            HtmlWeb html = new HtmlWeb();
          //  WebClient wc = new WebClient();
          //  wc.Proxy = new WebProxy("173.12.28.41",80);
          //  var page = wc.DownloadString(ConstSyte.ConstSyte.HtmlSyte);
         //   HtmlDocument doc = new HtmlDocument();
       //  , "173.12.28.41", 80, "", ""
           var doc =    html.Load(ConstSyte.ConstSyte.HtmlSyte);
          //  doc.LoadHtml();
            var node = doc.DocumentNode.SelectSingleNode("//div[@class='sport-rows open']");
        //  var  texte = node.SelectNodes("//td[@class='col border col-title']");
            foreach (var attribute in node.SelectNodes("//td[@class='col border col-title']"))
            {
                foreach (var couificent in node.SelectNodes("//td[@class='col border col-koefs']"))
                {
                    MessageBox.Show(attribute.InnerText + "  Коифиценты!!!  " + couificent.InnerText);
                    break;
                }
              
            }
            //foreach (var no in node)
            //{
            //    no.SelectSingleNode();
            //}
            return node.InnerHtml;
        }
    }
}
