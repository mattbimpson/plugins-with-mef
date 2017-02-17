using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;

namespace Plugins_with_MEF.Class_plugins
{
    [Export]
    [ExportMetadata("label", "label 3")]
    public class Plugin3 : IPlugin
    {
        public string id { get { return "Plugin 3"; } }
    }
}
