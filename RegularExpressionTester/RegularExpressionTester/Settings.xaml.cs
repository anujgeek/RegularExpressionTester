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
using System.Windows.Shapes;

namespace RegularExpressionTester
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();

            InitializeThemeColorComboBox();
            cbStartColor.SelectedIndex = Properties.Settings.Default.StartColorIndex;
            cbEndColor.SelectedIndex = Properties.Settings.Default.EndColorIndex;
            cbLoadOnStart.IsChecked = Properties.Settings.Default.LoadOnStart;
            cbSaveOnExit.IsChecked = Properties.Settings.Default.SaveOnExit;
            cbSelectMatch.IsChecked = Properties.Settings.Default.SelectMatch;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Reset();

            cbStartColor.SelectedIndex = Properties.Settings.Default.StartColorIndex;
            cbEndColor.SelectedIndex = Properties.Settings.Default.EndColorIndex;
            cbLoadOnStart.IsChecked = Properties.Settings.Default.LoadOnStart;
            cbSaveOnExit.IsChecked = Properties.Settings.Default.SaveOnExit;
            cbSelectMatch.IsChecked = Properties.Settings.Default.SelectMatch;
        }

        private void InitializeThemeColorComboBox()
        {
            Rectangle[] rStartColor = new Rectangle[MainWindow.bColor.Length];
            for (int i = 0; i <= MainWindow.bColor.Length - 1; i++)
            {
                rStartColor[i] = new Rectangle();
                rStartColor[i].Height = 25;
                rStartColor[i].Width = 50;
                rStartColor[i].Stroke = Brushes.White;
                rStartColor[i].StrokeThickness = 2;
                rStartColor[i].Fill = MainWindow.bBrush[i];
            }

            Rectangle[] rEndColor = new Rectangle[MainWindow.bColor.Length];
            for (int i = 0; i <= MainWindow.bColor.Length - 1; i++)
            {
                rEndColor[i] = new Rectangle();
                rEndColor[i].Height = 25;
                rEndColor[i].Width = 50;
                rEndColor[i].Stroke = Brushes.White;
                rEndColor[i].StrokeThickness = 2;
                rEndColor[i].Fill = MainWindow.bBrush[i];
            }
            cbStartColor.ItemsSource = rStartColor;
            cbEndColor.ItemsSource = rEndColor;
        }

        private void cbStartColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Application.Current.Resources["StartColor"] = MainWindow.bColor[cbStartColor.SelectedIndex];
        }

        private void cbEndColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Application.Current.Resources["EndColor"] = MainWindow.bColor[cbEndColor.SelectedIndex];
        }
    }
}
