using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace Task_1_XML
{
    /// <summary>
    /// Main class.
    /// Convert to XML.
    /// </summary>
    public class ConvertToXML
    {
        /// <summary>
        /// Path start file.
        /// </summary>
        private static string nameStartFileTXT = "startFile.txt";

        /// <summary>
        /// Path end file.
        /// </summary>
        private static string nameFinishFileXML = "endFile.xml";

        /// <summary>
        /// Main.
        /// </summary>
        /// <param name="args">Parameters from console.</param>
        private static void Main(string[] args)
        {
            List<ClassURL> urlList = GetData.GetUrl(ReadFromFileTXT.Read(nameStartFileTXT));

            XElement root = new XElement("Links");

            foreach (ClassURL url in urlList)
            {
                XElement node = new XElement("Link");

                node.Add(new XElement("Host", new XAttribute("Name", url.HostLink)));

                if (url.URILink != null)
                {
                    node.Add(new XElement("Uri",
                        url.URILink.Where(item => !string.IsNullOrEmpty(item.ToString(new CultureInfo("en-US"))))
                                   .Select(item => new XElement("Segment", item))));
                }

                if (url.ParametersLink != null)
                {
                    node.Add(new XElement("Parameters",
                        url.ParametersLink.Select(item => new XElement("Parameter", new XAttribute("Value", item.Value), new XAttribute("Key", item.Key)))));
                }

                root.Add(node);
            }

            XDocument doc = new XDocument(root);

            doc.Save(nameFinishFileXML);

            Console.ReadKey();
        }
    }
}
