using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Ryr.XrmToolBox.SolutionInstaller.DefinitionClasses;

namespace Ryr.XrmToolBox.SolutionInstaller.Utility
{
    public class Helper
    {
        public static SolutionFormat CheckZip(byte[] zipContents)
        {
            var isManaged = SolutionFormat.Invalid;
            using (var archive = new ZipArchive(new MemoryStream(zipContents), 
                ZipArchiveMode.Read, true))
            {
                foreach (var entry in archive.Entries)
                {
                    if (entry.Name != "solution.xml") continue;

                    using (var reader = new StreamReader(entry.Open()))
                    {
                        var solutionFile = reader.ReadToEnd();
                        if (string.IsNullOrEmpty(solutionFile)) continue;

                        isManaged = XElement.Parse(solutionFile).Element("SolutionManifest").Element("Managed")
                                        .Value == "1" ? SolutionFormat.Managed : SolutionFormat.Unmanaged;
                    }
                }
            }
            return isManaged;
        }
    }
}
