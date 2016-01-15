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
        #region CopyMenuHandlers
        private void MenuItemCopyRegularExpression_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(tbRegex.Text);
        }

        private void MenuItemCopyCCons_Click(object sender, RoutedEventArgs e)
        {
            string s = @"Regex re = new Regex(@"""");";
            Clipboard.SetText(s.Insert(23, tbRegex.Text));
        }

        private void MenuItemCopyVBCons_Click(object sender, RoutedEventArgs e)
        {
            string s = @"Dim re As Regex = new Regex("""")";
            Clipboard.SetText(s.Insert(29, tbRegex.Text));
        }

        private void MenuItemCopySelectedMatch_Click(object sender, RoutedEventArgs e)
        {
            if (lvMatches.SelectedIndex != -1)
            {
                MyCollection t = lvMatches.SelectedItem as MyCollection;
                Clipboard.SetText(t.MatchedString);
            }
            else
                MessageBox.Show("No Match Selected", "No Match Selected");
        }

        private void MenuItemCopyAllMatches_Click(object sender, RoutedEventArgs e)
        {
            if (lvMatches.Items.Count == 0)
                MessageBox.Show("No Matches Found", "No Matches Found");
            else
            {
                string s = "";
                int i;
                for (i = 0; i <= matchCollection.Count - 2; i++)
                {
                    s = String.Concat(s, matchCollection[i].MatchedString, "\n");
                }
                s = String.Concat(s, matchCollection[i].MatchedString);
                Clipboard.SetText(s);
            }
        }
        #endregion

        #region insertMenuHandlers
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\a");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\b");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\t");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\r");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\v");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\f");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\n");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\e");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_9(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\.");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_10(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\$");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_11(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\^");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_12(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\{");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_13(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\}");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_14(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\(");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_15(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\)");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_16(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\[");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_17(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\]");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_18(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\\");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_19(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\?");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_20(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\+");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_21(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\*");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_22(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"[character_group]");
            tbRegex.Select(currentCaretIndex + 1, 15);
        }

        private void MenuItem_Click_23(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"[^character_group]");
            tbRegex.Select(currentCaretIndex + 2, 15);
        }

        private void MenuItem_Click_24(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"[firstCharacter-lastCharacter]");
            tbRegex.Select(currentCaretIndex + 1, 28);
        }

        private void MenuItem_Click_25(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"[^firstCharacter-lastCharacter]");
            tbRegex.Select(currentCaretIndex + 2, 28);
        }

        private void MenuItem_Click_26(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\p{name}");
            tbRegex.Select(currentCaretIndex + 3, 4);
        }

        private void MenuItem_Click_27(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\P{name}");
            tbRegex.Select(currentCaretIndex + 3, 4);
        }

        private void MenuItem_Click_28(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @".");
            tbRegex.CaretIndex = currentCaretIndex + 1;
        }

        private void MenuItem_Click_29(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\w");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_30(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\W");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_31(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\s");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_32(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\S");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_33(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\d");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_34(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\D");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_35(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"^");
            tbRegex.CaretIndex = currentCaretIndex + 1;
        }

        private void MenuItem_Click_36(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"$");
            tbRegex.CaretIndex = currentCaretIndex + 1;
        }

        private void MenuItem_Click_37(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\A");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_38(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\Z");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_39(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\z");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_40(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\G");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_41(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\b");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_42(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\B");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_43(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"(subexpression)");
            tbRegex.Select(currentCaretIndex + 1, 13);
        }

        private void MenuItem_Click_44(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"(?<name>subexpression)");
            tbRegex.Select(currentCaretIndex + 3, 4);
        }

        private void MenuItem_Click_45(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"(?'name'subexpression)");
            tbRegex.Select(currentCaretIndex + 3, 4);
        }

        private void MenuItem_Click_46(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"(?<name>subexpression)");
            tbRegex.Select(currentCaretIndex + 3, 4);
        }

        private void MenuItem_Click_47(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"(?'name'subexpression)");
            tbRegex.Select(currentCaretIndex + 3, 4);
        }

        private void MenuItem_Click_48(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"(?:subexpression)");
            tbRegex.Select(currentCaretIndex + 3, 13);
        }

        private void MenuItem_Click_49(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"(?=subexpression)");
            tbRegex.Select(currentCaretIndex + 3, 13);
        }

        private void MenuItem_Click_50(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"(?!subexpression)");
            tbRegex.Select(currentCaretIndex + 3, 13);
        }

        private void MenuItem_Click_51(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"(?<=subexpression)");
            tbRegex.Select(currentCaretIndex + 4, 13);
        }

        private void MenuItem_Click_52(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"(?<!subexpression)");
            tbRegex.Select(currentCaretIndex + 4, 13);
        }

        private void MenuItem_Click_53(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"(?>subexpression)");
            tbRegex.Select(currentCaretIndex + 3, 13);
        }

        private void MenuItem_Click_54(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"*");
            tbRegex.CaretIndex = currentCaretIndex + 1;
        }

        private void MenuItem_Click_55(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"+");
            tbRegex.CaretIndex = currentCaretIndex + 1;
        }

        private void MenuItem_Click_56(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"?");
            tbRegex.CaretIndex = currentCaretIndex + 1;
        }

        private void MenuItem_Click_57(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"{n}");
            tbRegex.Select(currentCaretIndex + 1, 1);
        }

        private void MenuItem_Click_58(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"{n,}");
            tbRegex.Select(currentCaretIndex + 1, 1);
        }

        private void MenuItem_Click_59(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"{n,m}");
            tbRegex.Select(currentCaretIndex + 1, 3);
        }

        private void MenuItem_Click_60(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"?");
            tbRegex.CaretIndex = currentCaretIndex + 1;
        }

        private void MenuItem_Click_61(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\1");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_62(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\number");
            tbRegex.Select(currentCaretIndex + 1, 6);
        }

        private void MenuItem_Click_63(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\k<name>");
            tbRegex.Select(currentCaretIndex + 3, 4);
        }

        private void MenuItem_Click_64(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"\k'name'");
            tbRegex.Select(currentCaretIndex + 3, 4);
        }

        private void MenuItem_Click_65(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"|");
            tbRegex.CaretIndex = currentCaretIndex + 1;
        }

        private void MenuItem_Click_66(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"(?(expression)yes|no)");
            tbRegex.Select(currentCaretIndex + 3, 10);
        }

        private void MenuItem_Click_67(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"(?(name Or number)yes|no)");
            tbRegex.Select(currentCaretIndex + 3, 14);
        }

        private void MenuItem_Click_68(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"$number");
            tbRegex.Select(currentCaretIndex + 1, 6);
        }

        private void MenuItem_Click_69(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"${name}");
            tbRegex.Select(currentCaretIndex + 2, 4);
        }

        private void MenuItem_Click_70(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"$$");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_71(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"$&");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_72(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"$`");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_73(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"$'");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_74(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"$+");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Checked(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"$_");
            tbRegex.CaretIndex = currentCaretIndex + 2;
        }

        private void MenuItem_Click_75(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"(?imnsx-imnsx)");
            tbRegex.Select(currentCaretIndex + 2, 11);
        }

        private void MenuItem_Click_76(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"(?#comment)");
            tbRegex.Select(currentCaretIndex + 3, 7);
        }

        private void MenuItem_Click_77(object sender, RoutedEventArgs e)
        {
            tbRegex.Focus();
            int currentCaretIndex = tbRegex.CaretIndex;
            tbRegex.Text = tbRegex.Text.Insert(currentCaretIndex, @"#");
            tbRegex.CaretIndex = currentCaretIndex + 1;
        }
        #endregion

        private void myWin_Loaded(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Properties["FileNameWithPath"] != null)
            {
                OpenFile((string)Application.Current.Properties["FileNameWithPath"]);

                FileNameWithPath = (string)Application.Current.Properties["FileNameWithPath"];
                FileName = (string)Application.Current.Properties["FileName"];

                IsOpenDocSaved = true;
            }
            else if (Properties.Settings.Default.LoadOnStart)
                LoadLastExitData();
            else
                New();

            tbInput.Focus();
            tbInput.CaretIndex = tbInput.Text.Length;
            IsSaved = true;
        }

        private void LoadLastExitData()
        {
            tbInput.Text = Properties.Settings.Default.DynamicInputText;
            tbRegex.Text = Properties.Settings.Default.DynamicRegexText;
            options = Properties.Settings.Default.DynamicRegexOptions;

            if (Properties.Settings.Default.cbEcmaIsChecked == false)
            {
                cbEcma.IsChecked = false;

                cbCulInv.IsChecked = Properties.Settings.Default.cbCulInvIsChecked;
                cbExpCap.IsChecked = Properties.Settings.Default.cbExpCapIsChecked;
                cbIgnPatWhi.IsChecked = Properties.Settings.Default.cbIgnPatWhiIsChecked;
                cbRTL.IsChecked = Properties.Settings.Default.cbRTLIsChecked;
                cbSL.IsChecked = Properties.Settings.Default.cbSLIsChecked;
            }
            else
            {
                cbEcma.IsChecked = true;

                cbCulInv.IsChecked = false;
                cbExpCap.IsChecked = false; ;
                cbIgnPatWhi.IsChecked = false; ;
                cbRTL.IsChecked = false;
                cbSL.IsChecked = false; ;
            }

            cbIgnCase.IsChecked = Properties.Settings.Default.cbIgnCaseIsChecked;
            cbML.IsChecked = Properties.Settings.Default.cbMLIsChecked;

            this.Title = "Regular Expression Tester - Untitled";
        }

        private void SaveDataOnExit()
        {
            Properties.Settings.Default.DynamicInputText = tbInput.Text;
            Properties.Settings.Default.DynamicRegexText = tbRegex.Text;
            Properties.Settings.Default.DynamicRegexOptions = options;

            if (cbEcma.IsChecked == false)
            {
                Properties.Settings.Default.cbEcmaIsChecked = false;

                Properties.Settings.Default.cbCulInvIsChecked = (bool)cbCulInv.IsChecked;
                Properties.Settings.Default.cbExpCapIsChecked = (bool)cbExpCap.IsChecked;
                Properties.Settings.Default.cbIgnPatWhiIsChecked = (bool)cbIgnPatWhi.IsChecked;
                Properties.Settings.Default.cbRTLIsChecked = (bool)cbRTL.IsChecked;
                Properties.Settings.Default.cbSLIsChecked = (bool)cbSL.IsChecked;
            }
            else
            {
                Properties.Settings.Default.cbEcmaIsChecked = true;

                Properties.Settings.Default.cbCulInvIsChecked = false;
                Properties.Settings.Default.cbExpCapIsChecked = false;
                Properties.Settings.Default.cbIgnPatWhiIsChecked = false;
                Properties.Settings.Default.cbRTLIsChecked = false;
                Properties.Settings.Default.cbSLIsChecked = false;
            }

            Properties.Settings.Default.cbIgnCaseIsChecked = (bool)cbIgnCase.IsChecked;
            Properties.Settings.Default.cbMLIsChecked = (bool)cbML.IsChecked;

            Properties.Settings.Default.Save();
        }


        private void MenuItemSettings_Click(object sender, RoutedEventArgs e)
        {
            Settings mySettings = new Settings();
            bool? result = mySettings.ShowDialog();
            if (result == true)
            {
                Properties.Settings.Default.StartColorIndex = mySettings.cbStartColor.SelectedIndex;
                Properties.Settings.Default.EndColorIndex = mySettings.cbEndColor.SelectedIndex;
                Properties.Settings.Default.LoadOnStart = (bool)mySettings.cbLoadOnStart.IsChecked;
                Properties.Settings.Default.SaveOnExit = (bool)mySettings.cbSaveOnExit.IsChecked;
                Properties.Settings.Default.SelectMatch = (bool)mySettings.cbSelectMatch.IsChecked;

                Properties.Settings.Default.Save();
            }
            else
            {
                Application.Current.Resources["StartColor"] = bColor[Properties.Settings.Default.StartColorIndex];
                Application.Current.Resources["EndColor"] = bColor[Properties.Settings.Default.EndColorIndex];
            }
        }



        private void lvMatches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvMatches.SelectedIndex == -1)
                return;

            UpdateGroups();
            RefreshDataViews(lvGroups);

            if (Properties.Settings.Default.SelectMatch)
            {
                int CurrentSelectionIndex = (lvMatches.SelectedItem as MyCollection).CurrentCount;

                Index = matches[CurrentSelectionIndex].Index;
                tbInput.ScrollToLine(tbInput.GetLineIndexFromCharacterIndex(Index));
                tbInput.Select(Index, matches[CurrentSelectionIndex].Length);
                tbInput.Focus();
            }
        }

        private void lvGroups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvGroups.SelectedIndex == -1)
                return;

            if (Properties.Settings.Default.SelectMatch)
            {
                int CurrentMatchSelectionIndex = (lvMatches.SelectedItem as MyCollection).CurrentCount;
                int CurrentGroupSelectionIndex = (lvGroups.SelectedItem as MyCollection).CurrentCount;

                Index = matches[CurrentMatchSelectionIndex].Groups[CurrentGroupSelectionIndex + 1].Index;
                tbInput.ScrollToLine(tbInput.GetLineIndexFromCharacterIndex(Index));
                tbInput.Select(Index, matches[CurrentMatchSelectionIndex].Groups[CurrentGroupSelectionIndex + 1].Length);
                tbInput.Focus();
            }
        }

        private void cb_Checked(object sender, RoutedEventArgs e)
        {
            if (cbEcma.IsChecked == true)
            {
                cbIgnCase.IsEnabled = true;
                cbML.IsEnabled = true;

                cbCulInv.IsChecked = false;
                cbExpCap.IsChecked = false;
                cbIgnPatWhi.IsChecked = false;
                cbRTL.IsChecked = false;
                cbSL.IsChecked = false;

                cbCulInv.IsEnabled = false;
                cbExpCap.IsEnabled = false;
                cbIgnPatWhi.IsEnabled = false;
                cbRTL.IsEnabled = false;
                cbSL.IsEnabled = false;
            }

            options = RegexOptions.None;

            if (cbEcma.IsChecked == true)
                options = options | RegexOptions.ECMAScript;
            if (cbIgnCase.IsChecked == true)
                options = options | RegexOptions.IgnoreCase;
            if (cbML.IsChecked == true)
                options = options | RegexOptions.Multiline;
            if (cbSL.IsChecked == true)
                options = options | RegexOptions.Singleline;
            if (cbIgnPatWhi.IsChecked == true)
                options = options | RegexOptions.IgnorePatternWhitespace;
            if (cbRTL.IsChecked == true)
                options = options | RegexOptions.RightToLeft;
            if (cbExpCap.IsChecked == true)
                options = options | RegexOptions.ExplicitCapture;
            if (cbCulInv.IsChecked == true)
                options = options | RegexOptions.CultureInvariant;

            Update();
        }

        private void cb_Unchecked(object sender, RoutedEventArgs e)
        {
            if (cbEcma.IsChecked == true)
            {
                cbIgnCase.IsEnabled = true;
                cbML.IsEnabled = true;

                cbCulInv.IsChecked = false;
                cbExpCap.IsChecked = false;
                cbIgnPatWhi.IsChecked = false;
                cbRTL.IsChecked = false;
                cbSL.IsChecked = false;

                cbCulInv.IsEnabled = false;
                cbExpCap.IsEnabled = false;
                cbIgnPatWhi.IsEnabled = false;
                cbRTL.IsEnabled = false;
                cbSL.IsEnabled = false;
            }
            else
            {
                cbIgnCase.IsEnabled = true;
                cbML.IsEnabled = true;

                cbCulInv.IsEnabled = true;
                cbExpCap.IsEnabled = true;
                cbIgnPatWhi.IsEnabled = true;
                cbRTL.IsEnabled = true;
                cbSL.IsEnabled = true;
            }

            options = RegexOptions.None;

            if (cbEcma.IsChecked == true)
                options = options | RegexOptions.ECMAScript;
            if (cbIgnCase.IsChecked == true)
                options = options | RegexOptions.IgnoreCase;
            if (cbML.IsChecked == true)
                options = options | RegexOptions.Multiline;
            if (cbSL.IsChecked == true)
                options = options | RegexOptions.Singleline;
            if (cbIgnPatWhi.IsChecked == true)
                options = options | RegexOptions.IgnorePatternWhitespace;
            if (cbRTL.IsChecked == true)
                options = options | RegexOptions.RightToLeft;
            if (cbExpCap.IsChecked == true)
                options = options | RegexOptions.ExplicitCapture;
            if (cbCulInv.IsChecked == true)
                options = options | RegexOptions.CultureInvariant;

            Update();
        }

        private void MenuItemAbout_Click(object sender, RoutedEventArgs e)
        {
            About myAbout = new About();
            myAbout.ShowDialog();
        }
    }
}