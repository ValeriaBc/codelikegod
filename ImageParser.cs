using System.IO;
using System;
using Newtonsoft.Json;

using System.Drawing;

namespace ImageParser
{

    public class ImageInfo
    {
        public int Height { get; set; }
        public int HeightFromDrawing { get; set; }
        public int Width { get; set; }
        public int WidthFromDrawing { get; set; }
        public string Format { get; set; }
        public int Size { get; set; }
        public int SizeFromDrawing { get; set; }
    }

    public class ImageParser : IImageParser
    {
        public string GetImageInfo(Stream stream)
        {
            StreamReader reader = new StreamReader(stream);
            string text = reader.ReadToEnd();

            string[] lines = text.Split(new char[] { '\n' },
                                       StringSplitOptions.RemoveEmptyEntries);
            foreach (var e in lines)
                Console.WriteLine(e.Length);
            Console.WriteLine(lines[0].Substring(1));
            var elem = new ImageInfo();
            elem.Format = lines[0].Substring(1,3);
            elem.Height = 5;
            elem.Width = 4;
            elem.Size = 2;
            // elem.Size = GetSize(ReadFully(stream));
            elem.Size = text.Length;

            /*
            System.Drawing.Image image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(byteArrayHere));
            elem.HeightFromDarawing = image.Height.ToString();
            elem.WidthFromDarawing = image.Width.ToString();
            elem.SizeFromDarawing = image.Size();
            */


            string json = JsonConvert.SerializeObject(elem, Formatting.Indented);

            return json;
            //throw new System.NotImplementedException();
        }

        public static byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}