using System;
using System.IO;
using U8Xml;

namespace XMLFixer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("XML Fixer");
            using (Stream stream = File.OpenRead("C:/test/x.xml"))
            using (XmlObject xml = XmlParser.Parse(stream))
            {
                XmlNode root = xml.Root;
                string rootName = root.Name.ToString();         // "SomeData"
                foreach (var child in root.Children)
                {
                    XmlNode kid = child;
                    XmlAttribute attr = kid.Attributes.First();
                    string attrName = attr.Value.ToString();
                    Console.WriteLine("Do you want to keep: "+attrName+" ?");
                    var response = Console.ReadLine();
                    if (response == "x")
                    {
                        Console.WriteLine("copy to new file");
                    }
                }
                // node
                //XmlNode child = root.Children.First();
                //string childName = child.Name.ToString();       // "Data"
                //Console.WriteLine(childName);
                //string innerText = child.InnerText.ToString();  // "bbb"

                //// attribute
                //XmlAttribute attr = child.Attributes.First();
                //string attrName = attr.Name.ToString();         // "aa"
                //int attrValue = attr.Value.ToInt32();           // 20


            }
            // *** DO NOT use any object from the parser. ***
            // XmlObject, XmlNode, RawString, etc... are no longer accessible here.
            // Their all memories are released when XmlObject.Dispose() called !!
            // They must be evaluated and converted to string, int, and so on.
            Console.ReadLine();
        }
    }
}
