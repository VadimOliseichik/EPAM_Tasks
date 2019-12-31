using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Task_1_XML
{
    /// <summary>
    /// Reader from file class.
    /// </summary>
    public static class ReadFromFileTXT
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">Path of file.</param>
        /// <returns>List of strings from file.</returns>
        public static List<string> Read(string path)
        {
            if (File.Exists(path))
            {
                return File.ReadAllLines(path).ToList();
            }

            throw new ArgumentException("False path.");
        }
    }
}
