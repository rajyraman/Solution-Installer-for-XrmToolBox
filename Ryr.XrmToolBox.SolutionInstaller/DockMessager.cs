using System.Collections.Generic;
using System.Windows.Forms;
using Ryr.XrmToolBox.SolutionInstaller.DockPanels;
using XrmToolBox.Extensibility;

namespace Ryr.XrmToolBox.SolutionInstaller
{
    public class DockMessager
    {
        public ListViewItem[] Repos => _parent.Repos;

        public List<ListViewGroup> RepoAuthorGroup => _parent.RepoAuthorGroup;

        private readonly SolutionInstallerPlugin _parent;

        public DockMessager(SolutionInstallerPlugin parent)
        {
            this._parent = parent;
        }

        public void SolutionChecked(ListView lvGitHubSolutions, ItemCheckedEventArgs itemCheckedEventArgs)
        {
            _parent.lvGitHubSolutions_ItemChecked(lvGitHubSolutions, itemCheckedEventArgs);
        }

        public  void ReleasesChecked(int checkedItems)
        {
            _parent.lvReleases_ItemChecked(checkedItems);
        }
    }
}