using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHelper
{
    internal class FileWrapper : IFileWrapper
    {
        public string GetContent(string filename)
        {
            if(filename == null)
            {
                throw new ArgumentNullException("filename");
            }
            using var streamReader = new StreamReader(filename);
            var contents = streamReader.ReadToEnd().ToLower();
            return contents;
        }
    }
}
