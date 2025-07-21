using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TestingTask.Util
{
    public class FileHelper
    {
        public static async Task<string?> GetJsonFromXMLUrl(string xmlUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string xmlContent = await client.GetStringAsync(xmlUrl);

                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xmlContent);

                    string json = JsonConvert.SerializeXmlNode(xmlDoc, Newtonsoft.Json.Formatting.Indented);

                    return json;
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return null;
                }
            }
        }
    }
}
