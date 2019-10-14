using System;
using System.IO;
using Newtonsoft.Json;

namespace ImageParser
{

    internal class Program
    {
        public static void Main(string[] args)
        {
            var parser = new ImageParser();
            string imageInfoJson;

            using (var file = new FileStream("image.png", FileMode.Open, FileAccess.Read))
            {
                imageInfoJson = parser.GetImageInfo(file);
            }

            Console.WriteLine(imageInfoJson);
            /*
                string[] lines = imageInfoJson.Split(new char[] { '\n' },
                                       StringSplitOptions.RemoveEmptyEntries);
            foreach (var e in lines)
                Console.WriteLine(e.Length);
            Console.WriteLine(lines[0].Substring(1));*/
            Console.ReadLine();
        }
    }
}