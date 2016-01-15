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
        public static Color[] bColor = { Colors.AliceBlue, Colors.AntiqueWhite, Colors.Azure, Colors.Beige, Colors.BlueViolet, Colors.Brown, Colors.BurlyWood, Colors.CadetBlue, Colors.Chocolate, Colors.Coral, Colors.CornflowerBlue, Colors.Cornsilk, Colors.DarkSalmon, Colors.DarkSeaGreen, Colors.DarkSlateBlue, Colors.DarkTurquoise, Colors.DeepSkyBlue, Colors.DimGray, Colors.DodgerBlue, Colors.Firebrick, Colors.ForestGreen, Colors.Gainsboro, Colors.Gold, Colors.Goldenrod, Colors.Gray, Colors.Green, Colors.GreenYellow, Colors.Honeydew, Colors.HotPink, Colors.IndianRed, Colors.Ivory, Colors.Khaki, Colors.Lavender, Colors.LemonChiffon, Colors.LightBlue, Colors.LightCoral, Colors.LightGray, Colors.LightGreen, Colors.LightPink, Colors.LightSalmon, Colors.LightSkyBlue, Colors.LightSlateGray, Colors.LightSteelBlue, Colors.Lime, Colors.MediumPurple, Colors.MediumSlateBlue, Colors.MediumVioletRed, Colors.Moccasin, Colors.NavajoWhite, Colors.Orchid, Colors.PaleVioletRed, Colors.PeachPuff, Colors.Pink, Colors.Plum, Colors.PowderBlue, Colors.RosyBrown, Colors.RoyalBlue, Colors.SaddleBrown, Colors.Salmon, Colors.SandyBrown, Colors.Sienna, Colors.Silver, Colors.SkyBlue, Colors.SlateBlue, Colors.SlateGray, Colors.SteelBlue, Colors.Tan, Colors.Thistle, Colors.Tomato, Colors.Wheat, Colors.White, Colors.WhiteSmoke, Colors.Yellow, Colors.YellowGreen };
        public static Brush[] bBrush = { Brushes.AliceBlue, Brushes.AntiqueWhite, Brushes.Azure, Brushes.Beige, Brushes.BlueViolet, Brushes.Brown, Brushes.BurlyWood, Brushes.CadetBlue, Brushes.Chocolate, Brushes.Coral, Brushes.CornflowerBlue, Brushes.Cornsilk, Brushes.DarkSalmon, Brushes.DarkSeaGreen, Brushes.DarkSlateBlue, Brushes.DarkTurquoise, Brushes.DeepSkyBlue, Brushes.DimGray, Brushes.DodgerBlue, Brushes.Firebrick, Brushes.ForestGreen, Brushes.Gainsboro, Brushes.Gold, Brushes.Goldenrod, Brushes.Gray, Brushes.Green, Brushes.GreenYellow, Brushes.Honeydew, Brushes.HotPink, Brushes.IndianRed, Brushes.Ivory, Brushes.Khaki, Brushes.Lavender, Brushes.LemonChiffon, Brushes.LightBlue, Brushes.LightCoral, Brushes.LightGray, Brushes.LightGreen, Brushes.LightPink, Brushes.LightSalmon, Brushes.LightSkyBlue, Brushes.LightSlateGray, Brushes.LightSteelBlue, Brushes.Lime, Brushes.MediumPurple, Brushes.MediumSlateBlue, Brushes.MediumVioletRed, Brushes.Moccasin, Brushes.NavajoWhite, Brushes.Orchid, Brushes.PaleVioletRed, Brushes.PeachPuff, Brushes.Pink, Brushes.Plum, Brushes.PowderBlue, Brushes.RosyBrown, Brushes.RoyalBlue, Brushes.SaddleBrown, Brushes.Salmon, Brushes.SandyBrown, Brushes.Sienna, Brushes.Silver, Brushes.SkyBlue, Brushes.SlateBlue, Brushes.SlateGray, Brushes.SteelBlue, Brushes.Tan, Brushes.Thistle, Brushes.Tomato, Brushes.Wheat, Brushes.White, Brushes.WhiteSmoke, Brushes.Yellow, Brushes.YellowGreen };

        public MainWindow()
        {
            InitializeComponent();

            InitializeCommands();

            //Set Current Theme
            Application.Current.Resources["StartColor"] = bColor[Properties.Settings.Default.StartColorIndex];
            Application.Current.Resources["EndColor"] = bColor[Properties.Settings.Default.EndColorIndex];
        }

        class MyCollection
        {
            public MyCollection(int Length, int Index, int CurrentCount, string MatchedString, string GroupName)
            {
                this.length = Length;
                this.index = Index;
                this.currentCount = CurrentCount;
                this.matchedString = MatchedString;
                this.groupName = GroupName;
            }

            private int length;

            public int Length
            {
                get { return length; }
                set { length = value; }
            }
            private int index;

            public int Index
            {
                get { return index; }
                set { index = value; }
            }
            private int currentCount;

            public int CurrentCount
            {
                get { return currentCount; }
                set { currentCount = value; }
            }
            private string matchedString;

            public string MatchedString
            {
                get { return matchedString; }
                set { matchedString = value; }
            }
            private string groupName;

            public string GroupName
            {
                get { return groupName; }
                set { groupName = value; }
            }
        }


    }
}
