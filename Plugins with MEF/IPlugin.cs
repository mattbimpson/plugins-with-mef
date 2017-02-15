using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins_with_MEF
{
    public interface IPlugin
    {
        string id { get; set; }
    }
}
