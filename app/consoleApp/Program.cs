using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using HTMLSpitterLib.Tags;

namespace consoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
             GenerateHTML1();

            // PrintCSSProperties();

            // PrintInterfaceCssProperties();
        }

        private static void PrintInterfaceCssProperties()
        {
            Console.WriteLine("interface ICssProperties {");
            var sr = new StreamReader(@"D:\Sources\VS13onlineRepos\HTML spitter\HTMLSpitterSolution\Data\AllCSSProperties.txt");
            var line = "";
            while ((line = sr.ReadLine()) != null)
            {
                Console.Write("string ");
                var frags = line.Trim().Split('-');
                foreach (var str in frags)
                {
                    var chars = str.ToCharArray();
                    chars[0] = char.Parse(chars[0].ToString(CultureInfo.InvariantCulture).ToUpper());
                    foreach (var c in chars)
                    {
                        Console.Write(c);
                    }
                }
                Console.WriteLine(" { get; set; }");
            }
            Console.WriteLine("}");
        }

        private static void GenerateHTML1()
        {
            var html = new ContentTag("html");
            var head = new ContentTag("head");
            var body = new ContentTag("body");
            html.AddChild(head);
            html.AddChild(body);
            var meta = new EmptyTag("meta");
            head.AddChild(meta);
            meta.AddAttribute("charset", "utf-8");
            Console.WriteLine(html.Spit());
        }

        private static void PrintCSSProperties()
        {
            var sr = new StreamReader(@"D:\Sources\VS13onlineRepos\HTML spitter\HTMLSpitterSolution\Data\CSS Properties.txt");
            var line = "";
            var properties = new List<string>();
            while ((line = sr.ReadLine()) != null)
            {
                properties.Add(line.Split(new char[] { ' ', '\t' })[0].Replace('\'', ' ').Trim());
            }

            foreach (var str in properties)
            {
                Console.WriteLine(str);
            }
        }
    }
}


/*
var hr = new EmptyTag("hr");
            Console.WriteLine(hr.Spit());
            var a = new ContentTag("a", ElementContentType.ContainsText);
            Console.WriteLine(a.Spit());

            a.AddAttribute("href", "http://google.com");
            Console.WriteLine(a.Spit());

            hr.AddAttribute("class", "dawn");
            Console.WriteLine(hr.Spit());

            var div = new ContentTag("div");
            var p = new ContentTag("p");
            div.AddChild(p);
            div.AddChild(hr);
            a.AddText("google");
            div.AddChild(a);
            Console.WriteLine(div.Spit());
*/

