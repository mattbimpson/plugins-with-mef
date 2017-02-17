using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;

namespace Plugins_with_MEF.Method_plugins
{
    public class MethodPlugins
    {
        [Export]
        public int Add(int input1, int input2)
        {
            return input1 + input2;
        }

        [Export]
        public int Subtract(int input1, int input2)
        {
            return input1 - input2;
        }

        [Export("SaySomething")]
        public string SaySomething()
        {
            return "Something";
        }
    }
}
