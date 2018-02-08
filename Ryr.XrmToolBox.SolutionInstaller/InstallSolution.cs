using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ryr.XrmToolBox.SolutionInstaller.DefinitionClasses;

namespace Ryr.XrmToolBox.SolutionInstaller
{
    public partial class InstallSolution : Form
    {
        private List<Asset> _assets;

        public InstallSolution()
        {
            InitializeComponent();
        }

        public InstallSolution(string[] solutions, string[] connections, List<Asset> assets)
        {
            InitializeComponent();

            this._assets = assets;
            lbSolutions.Items.AddRange(solutions);
            lbSolutions.SelectedIndex = 0;
            lbConnections.Items.AddRange(connections);
            messageLabel.Text = $@"Organizations to install: {connections}";
        }

        private void lbSolutions_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (!this._assets.Any()) return;

            txtReleaseNotes.Text = this._assets.Find(x => x.Name == lbSolutions.SelectedItem.ToString()).AssetBody;
        }
    }
}
