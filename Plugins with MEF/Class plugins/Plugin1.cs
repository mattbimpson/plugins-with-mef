using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;

namespace Plugins_with_MEF
{
    [Export(typeof(IPlugin))]
    public class Plugin1 : IPlugin
    {
        public string id { get { return "Plugin 1"; } }
    }
}
