using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace RegularExpressionTester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GridViewColumnHeader lvMatchesLastHeaderClicked = null;
        ListSortDirection lvMatchesLastDirection = ListSortDirection.Ascending;

        GridViewColumnHeader lvGroupsLastHeaderClicked = null;
        ListSortDirection lvGroupsLastDirection = ListSortDirection.Ascending;

        private void GridViewColumnHeaderClickedHandler(object sender, RoutedEventArgs e)
        {
            ListView v = sender as ListView;
            GridViewColumnHeader LastHeaderClicked;
            ListSortDirection LastDirection;

            if (v == lvMatches)
            {
                LastHeaderClicked = lvMatchesLastHeaderClicked;
                LastDirection = lvMatchesLastDirection;
            }
            else
            {
                LastHeaderClicked = lvGroupsLastHeaderClicked;
                LastDirection = lvGroupsLastDirection;
            }

            GridViewColumnHeader headerClicked = e.OriginalSource as GridViewColumnHeader;
            ListSortDirection direction;

            if (headerClicked != null)
            {
                if (headerClicked.Role != GridViewColumnHeaderRole.Padding)
                {
                    if (headerClicked != LastHeaderClicked)
                    {
                        direction = ListSortDirection.Ascending;
                    }
                    else
                    {
                        if (LastDirection == ListSortDirection.Ascending)
                        {
                            direction = ListSortDirection.Descending;
                        }
                        else
                        {
                            direction = ListSortDirection.Ascending;
                        }
                    }

                    Sort((headerClicked.Column.DisplayMemberBinding as Binding).Path.Path, direction, v);

                    if (direction == ListSortDirection.Ascending)
                    {
                        headerClicked.Column.HeaderTemplate = Resources["HeaderTemplateArrowUp"] as DataTemplate;
                    }
                    else
                    {
                        headerClicked.Column.HeaderTemplate = Resources["HeaderTemplateArrowDown"] as DataTemplate;
                    }

                    // Remove arrow from previously sorted header
                    if (LastHeaderClicked != null && LastHeaderClicked != headerClicked)
                    {
                        LastHeaderClicked.Column.HeaderTemplate = null;
                    }

                    if (v == lvMatches)
                    {
                        lvMatchesLastHeaderClicked = headerClicked;
                        lvMatchesLastDirection = direction;
                    }
                    else
                    {
                        lvGroupsLastHeaderClicked = headerClicked;
                        lvGroupsLastDirection = direction;
                    }
                }
            }
        }

        private void Sort(string sortBy, ListSortDirection direction, ListView v)
        {
            if (v.Items.Count != 0)
            {
                dataView = CollectionViewSource.GetDefaultView(v.ItemsSource);
                dataView.SortDescriptions.Clear();
                SortDescription sd = new SortDescription(sortBy, direction);
                dataView.SortDescriptions.Add(sd);
                dataView.Refresh();
            }
        }

        private void RefreshDataViews(params ListView[] v)
        {
            for (int i = 0; i <= v.Length - 1; i++)
            {
                dataView = CollectionViewSource.GetDefaultView(v[i].ItemsSource);
                if (dataView != null)
                    dataView.Refresh();
            }
        }
    }
}