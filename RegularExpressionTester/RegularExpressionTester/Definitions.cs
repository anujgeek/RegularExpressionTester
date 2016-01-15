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
        ICollectionView dataView;

        List<MyCollection> matchCollection = new List<MyCollection>();
        List<MyCollection> groupCollection = new List<MyCollection>();

        int Index;                                          //Index of current match for scrolling

        public RegexOptions options = RegexOptions.None;
        public string input = "";             //input string
        public string regex = "";             //input regex pattern
        public Regex a;                     //Regex object for above string and patttern
        public MatchCollection matches;     //Collection of a matches
        public GroupCollection groups;      //Groups in each match of above collection

        /*Groups hold a value for each match. So, we have a combobox for a particular match to be selected.
        
        Any group collection will contain groups in following order:
        1. First group is match itself
        2. Unnamed groups (if any)
        3. Named groups (if any)
        
        Problem is that we don't know how many groups are named and unnamed and what are names of these named groups
        So, we create a pattern that searches the input regex for named groups as below
        */

        /* The above matchcollection will hold all named groups found in in input regex. Each of these matches will
        hold a group called "name" which holds the name of the group in input regex.
        So, you can find the value of named group in input regex by
        groups[namedGroupMatches[i].Groups["name"].Value] 
        We will store name of each group in a list of strings groupNames for easy reference
         
        No of named groups = namedGroupMatches.Count = groupNames.Count
        Total no of groups Named + Unnamed = groups.Count -1                //As first group is the match itself
        No of unnamed groups = Totalt no of groups - no of named groups = groups.Count - 1 - groupNames.Count
        */

        string[] GroupNames;

        Regex exceptionPattern = new Regex(@"parsing "".*"" - (?<help>.*)\.");
    }
}