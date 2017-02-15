using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Composition;

namespace Plugins_with_MEF
{
    public partial class Form1 : Form
    {
        [ImportMany]
        private Lazy<IEnumerable<IPlugin>> plugins;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach(var plugin in plugins.Value)
            {
                lblLoadedPlugins.Text += plugin.id + Environment.NewLine;
            }
        }
    }
}
