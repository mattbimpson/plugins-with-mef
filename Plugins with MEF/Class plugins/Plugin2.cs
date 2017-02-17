using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins_with_MEF
{
    [Export(typeof(IPlugin))]
    public class Plugin2 : IPlugin
    {
        public string id { get { return "Plugin 2"; } }
    }
}
