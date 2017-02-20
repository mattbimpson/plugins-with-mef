using System.ComponentModel.Composition;

using Plugins_with_MEF;

namespace PluginDll
{
    [Export(typeof(IPlugin))]
    public class MyPluginDll : IPlugin
    {
        public string id
        {
            get { return "My plugin dll"; }
        }
    }
}
