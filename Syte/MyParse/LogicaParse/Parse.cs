using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services.Description;
using HtmlAgilityPack;

namespace Syte.MyParse.LogicaParse
{
    public class Parse
    {
        public string HtmlParse()
        {

            HtmlWeb web = new HtmlWeb();
            var doc = web.Load(ParseConstant.Const.HtmlSyte);
           // var node = doc.DocumentNode.SelectSingleNode("//div[@class='navbar navbar-inverse navbar-fixed-top']").InnerText;
            var node = doc.DocumentNode.SelectSingleNode("//div[@id='gridBets']").InnerText;

            return node;
        }

    }
}