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
        public static List<ListViewGroup> GetGroups(this ListView listview)
        {
            List<ListViewGroup> groups = null;
            void MiGetGroups()
            {
                groups = listview.Groups.Cast<ListViewGroup>().ToList();
            }

            if (listview.InvokeRequired)
            {
                listview.Invoke((MethodInvoker)MiGetGroups);
            }
            else
            {
                MiGetGroups();
            }

            return groups;
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

        public static ListViewItem[] GetItems(this ListView listview)
        {
            ListViewItem[] items = null;
            void MiGetItems()
            {
                items = listview.Items.Cast<ListViewItem>().ToArray();
            }
            if (listview.InvokeRequired)
            {
                listview.Invoke((MethodInvoker)MiGetItems);
            }
            else
            {
                MiGetItems();
            }
            return items;
        }

        public static void ClearCheckedItems(this ListView listview)
        {
            void MiUncheckItems()
            {
                listview.CheckedItems
                    .Cast<ListViewItem>()
                    .Where(x=>x.Checked)
                    .ToList()
                    .ForEach(x => x.Checked = false);
            }
            if (listview.InvokeRequired)
            {
                listview.Invoke((MethodInvoker)MiUncheckItems);
            }
            else
            {
                MiUncheckItems();
            }
        }

        public static void ClearItems(this ListView listview)
        {
            void MiItems()
            {
                listview.Items.Clear();
            }
            if (listview.InvokeRequired)
            {
                listview.Invoke((MethodInvoker)MiItems);
            }
            else
            {
                MiItems();
            }
        }
        public static void Sort(this ListView listview, int columnClickedIndex)
        {
            listview.SelectedItems.Clear();
            listview.Sorting = listview.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            listview.ListViewItemSorter = new ListViewItemComparer(columnClickedIndex, listview.Sorting);

        }
    }
}
