using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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
            try
            {

                WebClient wc = new WebClient();
                
                wc.Encoding = Encoding.UTF8;
                wc.Proxy = new WebProxy(ConstSyte.ConstSyte.ProxiIp, ConstSyte.ConstSyte.Port);
                //  wc.Headers.Add("user-agent", "Only a test!");
                var page = wc.DownloadString(ConstSyte.ConstSyte.HtmlSyte);
              //  Byte[] pageData = wc.DownloadData(ConstSyte.ConstSyte.HtmlSyte);
               // string pageHtml = Encoding.ASCII.GetString(pageData);

                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(page);

                //   HtmlWeb html = new HtmlWeb();
                //  var d = html.Load(ConstSyte.ConstSyte.HtmlSyte);

                //   < td class="koefs-col col-p2">
                //    <td class="koefs-col col-x">
                // <td class="koefs-col col-p1">
                //div[contains(@class, 'sport-title')]
                var node = doc.DocumentNode.SelectSingleNode("//div[@id='match_live']");
                //   doc.DocumentNode.SelectNodes("//td[@class='col border col-title']");
                //  var  texte = node.SelectNodes("//td[@class='col border col-title']");
                foreach (var attribute in node.SelectNodes("//div[contains(@class, 'match_live-sport sport')]"))
                {
                    foreach (var sport in attribute.SelectNodes("//table[contains(@class, 'sport-row')]/tbody/tr"))
                    {
                        var i1 = attribute.SelectSingleNode(ConstSyte.ConstOlimpikz.ConstParse.ViewGemes);
                        var i2 = sport.SelectSingleNode("//td[@class='col border col-title']/a").InnerText;
                        var i3 = sport.SelectSingleNode("//td[@class='col border col-title']/nobr").InnerText;
                        var i7 = sport.SelectSingleNode("//td[@class='col border col-title']/div").InnerText;
                        var i4 = sport.SelectSingleNode("//td[@class='koefs-col col-p1']/div/a/b").InnerText;
                        var i5 = sport.SelectSingleNode("//td[@class='koefs-col col-x']/div/a/b").InnerText;
                        var i6 = sport.SelectSingleNode("//td[@class='koefs-col col-p2']/div/a/b").InnerText;

                        // attribute.InnerText + "   
                        MessageBox.Show("Что это!!! Такое!!! : " + i1 + "\n" +
                                        "Кто играет: " + i2 + "\n" +
                                        i3 + i7 + "\n" +
                                        "Коицицент П:" + i4 + "\n" +
                                        "Коэфицент X" + i5 + "\n" +
                                        "Коэфицент П2" + i6);
                    }
                    // MessageBox.Show(attribute.InnerText);
                    //foreach (var couificent in node.SelectNodes("//td[@class='col border col-koefs']"))
                    //{
                    //    MessageBox.Show(attribute.InnerText + "  Коифиценты!!!  " + couificent.InnerText);
                    //    break;
                    //}

                }
                //foreach (var no in node)
                //{
                //    no.SelectSingleNode();
                //}
                return node.InnerHtml;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }
    }
}
