using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ryr.XrmToolBox.SolutionInstaller.Utility;

namespace Ryr.XrmToolBox.SolutionInstaller.Extensions
{
    public static class ListViewExtensions
    {
        public static void AddGroup(this ListView listview, string groupHeader, string groupName)
        {
            void MiAddGroup()
            {
                listview.Groups.Add(new ListViewGroup(groupHeader, HorizontalAlignment.Left)
                {
                    Name = groupName
                });
            }

            if (listview.InvokeRequired)
            {
                listview.Invoke((MethodInvoker)MiAddGroup);
            }
            else
            {
                MiAddGroup();
            }
        }
        public static ListViewItem[] GetCheckedItems(this ListView listview)
        {
            ListViewItem[] checkedItems = null;
            void MiGetCheckedItems()
            {
                checkedItems = listview.CheckedItems.Cast<ListViewItem>().ToArray();
            }
            if (listview.InvokeRequired)
            {
                listview.Invoke((MethodInvoker)MiGetCheckedItems);
            }
            else
            {
                MiGetCheckedItems();
            }
            return checkedItems;
        }

        public static void Sort(this ListView listview, int columnClickedIndex)
        {
            listview.SelectedItems.Clear();
            listview.Sorting = listview.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            listview.ListViewItemSorter = new ListViewItemComparer(columnClickedIndex, listview.Sorting);

        }
    }
}
