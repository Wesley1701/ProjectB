using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AppBios.Controllers
{
    internal class JsonToClass
    {
        public JsonToClass() { }
        public string CreatePath(string FileName)
        {
            string path = Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string EndPath = projectPath + @"Data\" + FileName;
            return EndPath;
        }
    }
}
