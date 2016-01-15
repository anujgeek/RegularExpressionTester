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
        private void tb_Input(object sender, TextChangedEventArgs e)
        {
            input = tbInput.Text;
            Update();
        }

        private void tb_Regex(object sender, TextChangedEventArgs e)
        {
            regex = tbRegex.Text;
            Update();
        }
        private void Update()
        {
            try
            {
                a = new Regex(regex);
            }
            catch (ArgumentException exception)
            {
                tbStatus.Text = "Error : " + exceptionPattern.Match(exception.Message).Groups["help"].Value;
                tbStatus.Background = Brushes.Tomato;
                return;
            }

            if (IsSaved == true)                                            //Append an asterisk to WindowTitle to show that file is unsaved ( You can also check for asterisk this.Title[this.Title.Length - 1] != '*' )
            {
                this.Title = this.Title.Insert(this.Title.Length, "*");
            }
            IsSaved = false;                                                //Editing results in unsaved data

            tbStatus.Text = "OK";
            tbStatus.Background = Brushes.White;

            matches = Regex.Matches(input, regex, options);

            matchCollection.Clear();
            lvMatches.ItemsSource = null;

            for (int i = 0; i <= matches.Count - 1; i++)
            {
                matchCollection.Add(new MyCollection(matches[i].Length, matches[i].Index, i, matches[i].Value, ""));
            }
            lvMatches.ItemsSource = matchCollection;

            UpdateGroups();

            RefreshDataViews(lvMatches, lvGroups);
        }

        private void UpdateGroups()
        {
            int i;
            groupCollection.Clear();
            lvGroups.ItemsSource = null;

            if (lvMatches.SelectedIndex != -1)
            {
                int CurrentMatchSelectionIndex = (lvMatches.SelectedItem as MyCollection).CurrentCount;
                groups = matches[CurrentMatchSelectionIndex].Groups;          //Gets the groupcollection for a particular match of input regex
            }
            else
            {
                lvGroups.ItemsSource = null;
                return;
            }

            GroupNames = a.GetGroupNames();

            for (i = 0; i <= groups.Count - 2; i++)
            {
                groupCollection.Add(new MyCollection(groups[i + 1].Length, groups[i + 1].Index, i, groups[i + 1].Value, GroupNames[i + 1]));
            }
            lvGroups.ItemsSource = groupCollection;
        }
    }
}