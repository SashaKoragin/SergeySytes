﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibarySyte.ParseProxiServer
{
   public class ParseProxiServer
    {
      public static IEnumerable<WebProxy> ParseProxies()
        {
            var result = new List<WebProxy>();
            var lines = LoadPage("http://www.gatherproxy.com/").Split(Environment.NewLine.ToCharArray()).Select(s => s.Trim()).Where(s => s.StartsWith("gp.insertPrx"));
            foreach (var line in lines)
            {
                var parts = line.Split(',').Select(s => s.Trim());
                var ipPart = parts.FirstOrDefault(s => s.Contains("PROXY_IP"));
                var portPart = parts.FirstOrDefault(s => s.Contains("PROXY_PORT"));
                var ip = ipPart.Replace("\"PROXY_IP\":", "").Trim('"');
                var port = Convert.ToInt32(portPart.Replace("\"PROXY_PORT\":", "").Trim('"'), 16);
                result.Add(new WebProxy(ip, port));
            }
            return result;
        }


      private static string LoadPage(string url)
        {
            var result = "";
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var receiveStream = response.GetResponseStream();
                if (receiveStream != null)
                {
                    StreamReader readStream;
                    if (response.CharacterSet == null)
                        readStream = new StreamReader(receiveStream);
                    else
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    result = readStream.ReadToEnd();
                    readStream.Close();
                }
                response.Close();
            }
            return result;
        }
    }
}
