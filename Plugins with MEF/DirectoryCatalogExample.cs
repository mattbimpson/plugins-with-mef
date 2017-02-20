using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using System.Linq;

namespace Plugins_with_MEF
{
    public class DirectoryCatalogExample
    {
        [ImportMany]
        private IEnumerable<IPlugin> plugins;

        public string LoadPluginsFromFolder()
        {
            string path = Assembly.GetExecutingAssembly().Location;
            DirectoryCatalog catalog = new DirectoryCatalog(Path.GetFullPath(Path.Combine(path, @"..\..\..\Plugin dropin folder")), "*.dll");
            CompositionContainer container = new CompositionContainer(catalog);

            container.ComposeParts(this);

            return plugins.First().id;
        }
    }
}
