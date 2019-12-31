using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task_1_XML
{
    /// <summary>
    /// Class get data.
    /// </summary>
    public class GetData
    {
        /// <summary>
        /// Get URL.
        /// </summary>
        /// <param name="listUrl">List of string from file TXT.</param>
        /// <returns>List of object of ClassURL.</returns>
        public static List<ClassURL> GetUrl(List<string> listUrl)
        {
            List<ClassURL> outListURL = new List<ClassURL>();

            foreach (string strURL in listUrl)
            {
                if (Uri.TryCreate(strURL, UriKind.Absolute, out Uri uri) &&
                    (uri.Scheme == Uri.UriSchemeHttp ||
                    uri.Scheme == Uri.UriSchemeHttps))
                {
                    outListURL.Add(GetObjectClassURL(strURL));
                }
            }

            return outListURL;
        }

        /// <summary>
        /// Get object of URL.
        /// </summary>
        /// <param name="url">One string from file TXT.</param>
        /// <returns>Object of ClassURL.</returns>
        private static ClassURL GetObjectClassURL(string url)
        {
            Uri uri = new Uri(url);

            ClassURL urlObject = new ClassURL
            {
                HostLink = uri.Host,
                URILink = GetPath(uri.Segments),
                ParametersLink = GetParameter(uri.Query)
            };

            return urlObject;
        }

        /// <summary>
        /// Get path.
        /// </summary>
        /// <param name="segmets">Array of segment.</param>
        /// <returns>List of path.</returns>
        private static List<string> GetPath(string[] segmets)
        {
            if (segmets.Length > 1)
            {
                return segmets.Select(c => c.Trim('/')).ToList();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Get parameter.
        /// </summary>
        /// <param name="str">Query.</param>
        /// <returns>Dictionary.</returns>
        private static Dictionary<string, string> GetParameter(string str)
        {
            if (str == null || str.Length == 0)
            {
                return null;
            }

            return str.Trim('?').Split('&').Select(c => c.Split('=')).ToDictionary(c => c[0], c => c[1]);
        }
    }
}
