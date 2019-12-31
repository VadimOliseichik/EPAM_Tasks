using System;
using System.Collections.Generic;
using System.Text;

namespace Task_1_XML
{
    /// <summary>
    /// Class URL.
    /// </summary>
    public class ClassURL
    {
        /// <summary>
        /// URI.
        /// </summary>
        public List<string> URILink { get; set; }

        /// <summary>
        /// Host.
        /// </summary>
        public string HostLink { get; set; }

        /// <summary>
        /// Parameters.
        /// </summary>
        public Dictionary<string, string> ParametersLink { get; set; }
    }
}
