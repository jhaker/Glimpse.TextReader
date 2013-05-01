using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glimpse.Core.Extensibility;
using System.Web.Mvc;

namespace Glimpse.TextReader
{
    public class GlimpseTextReaderPlugin : TabBase, IDocumentation
    {
        public override object GetData(ITabContext context)
        {
            var returnCollection = new Dictionary<string, object>();
            var dateSort = ConfigurationManager.AppSettings.Get("Glimpse.TextReader.DateSort");
            var fileLimit = 1;
            var folder = ConfigurationManager.AppSettings.Get("Glimpse.TextReader.Folder");

            Int32.TryParse(ConfigurationManager.AppSettings.Get("Glimpse.TextReader.FileLimit"), out fileLimit);
            DirectoryInfo info = new DirectoryInfo(folder);

            IOrderedEnumerable<string> filepaths =  null;

            if (dateSort != null)
            {
                if(dateSort.ToLower() == "desc")
                    filepaths = Directory.GetFiles(folder).OrderByDescending(d => new FileInfo(d).CreationTime);
                else
                    filepaths = Directory.GetFiles(folder).OrderBy(d => new FileInfo(d).CreationTime);
            }

            if (filepaths == null)
                return "Glimpse.TextReader : unable to locate path or missing path in config";

            foreach (var filePath in filepaths.Take(fileLimit))
            {
                var fileName = Path.GetFileName(filePath);
                var loglines = File.ReadAllLines(filePath);
                returnCollection.Add(fileName, loglines);     
            }

            return returnCollection;
        }

        public override string Name
        {
            get { return "TextReader"; }
        }

        public string DocumentationUri { get { return ""; } }
    }
}
