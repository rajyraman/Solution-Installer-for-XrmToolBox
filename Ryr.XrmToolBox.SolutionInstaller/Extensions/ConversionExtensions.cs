using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryr.XrmToolBox.SolutionInstaller.Extensions
{
    public static class ConversionExtensions
    {
        public static string ToYesNo(this bool input)
        {
            return input ? "Yes" : "No";
        }

        public static string NormaliseUrl(this string url)
        {
            return url.EndsWith("/") ? url : $"{url}/";
        }
    }
}
