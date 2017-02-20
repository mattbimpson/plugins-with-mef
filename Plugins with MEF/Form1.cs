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
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using System.ComponentModel.Composition.Primitives;

namespace Plugins_with_MEF
{
    public partial class Form1 : Form
    {
        [ImportMany]
        private IEnumerable<IPlugin> plugins;

        [ImportMany]
        private IEnumerable<Func<int, int, int>> importedMethods;

        [Import("SaySomething")]
        private Func<string> importedByName;

        //[ImportMany]
        private IEnumerable<Lazy<IPlugin, Dictionary<string, object>>> importsWithMetaData;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblLoadedPlugins.Text = "";
            foreach(var plugin in plugins)
            {
                lblLoadedPlugins.Text += plugin.id + Environment.NewLine;
            }

            button1.Click += new EventHandler(Add);

            button2.Click += new EventHandler(Subtract);
        }

        private void Add(object sender, EventArgs e)
        {
            int result = importedMethods.First(m => m.Method.Name == "Add")(1, 2);
            MessageBox.Show("Add method imported!");
        }

        private void Subtract(object sender, EventArgs e)
        {
            int result = importedMethods.First(m => m.Method.Name == "Subtract")(1, 2);
            MessageBox.Show("Subtract method imported!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(importedByName());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(importsWithMetaData.First(m => (string)m.Metadata["label"] == "label 3").Value.id);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string path = Assembly.GetExecutingAssembly().Location;
            DirectoryCatalog catalog = new DirectoryCatalog(Path.GetFullPath(Path.Combine(path, @"..\..\..\Plugin dropin folder")), "*.dll");
            CompositionContainer container = new CompositionContainer(catalog);

            catalog.Refresh();

            // var dll = ReflectionModelServices.GetPartType(catalog.First()).Value.Assembly;

            foreach (ComposablePartDefinition part in catalog)
            {
                string name = part.ExportDefinitions.First().Metadata["Name"].ToString();

                if (!lblLoadedPlugins.Text.Contains(name))
                {
                    lblLoadedPlugins.Text += name;
                }
            }
        }
    }
}
