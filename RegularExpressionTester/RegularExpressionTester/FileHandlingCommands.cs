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
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Microsoft.Win32;
using System.IO;
using System.Xml;

namespace RegularExpressionTester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Editing result in call to Update(). (Editing occurs due to editing in UI, new , open (And Not by save))


        enum PostSavingTask { Nothing, Exit, New, Open }

        bool IsSaved = true;                    //File is saved
        bool IsOpenDocSaved = false;            //Current file exists on system (i.e. it has been saved previously on system)
        public static string FileName = "Untitled";
        public static string FileNameWithPath = "Untitled";
        string ProgramName = "Regular Expression Tester - ";

        private void InitializeCommands()
        {
            CommandBinding cmdBindingNew = new CommandBinding(ApplicationCommands.New);
            cmdBindingNew.Executed += NewCommandHandler;
            CommandBindings.Add(cmdBindingNew);

            CommandBinding cmdBindingOpen = new CommandBinding(ApplicationCommands.Open);
            cmdBindingOpen.Executed += OpenCommandHandler;
            CommandBindings.Add(cmdBindingOpen);

            CommandBinding cmdBindingSave = new CommandBinding(ApplicationCommands.Save);
            cmdBindingSave.Executed += SaveCommandHandler;
            CommandBindings.Add(cmdBindingSave);

            CommandBinding cmdBindingSaveAs = new CommandBinding(ApplicationCommands.SaveAs);
            cmdBindingSaveAs.Executed += SaveAsCommandHandler;
            CommandBindings.Add(cmdBindingSaveAs);
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void NewCommandHandler(object sender, RoutedEventArgs e)
        {
            if (IsSaved == false)
            {
                MessageBoxResult result = MessageBox.Show(this, "Save changes to current document?", "Save Current Document", MessageBoxButton.YesNoCancel);

                if (result == MessageBoxResult.Yes)
                    Save(PostSavingTask.New);
                else if (result == MessageBoxResult.No)
                    New();
                else
                    return;
            }
            else
                New();
        }

        private void New()
        {
            tbInput.Text = "";
            tbRegex.Text = "";
            cbEcma.IsChecked = false;
            cbCulInv.IsChecked = false;
            cbExpCap.IsChecked = false;
            cbIgnCase.IsChecked = false;
            cbIgnPatWhi.IsChecked = false;
            cbML.IsChecked = false;
            cbRTL.IsChecked = false;
            cbSL.IsChecked = false;

            this.Title = "Regular Expression Tester - Untitled";
            FileName = "Untitled";
            FileNameWithPath = "Untitled";
            IsOpenDocSaved = false;
            IsSaved = true;
        }

        private void OpenCommandHandler(object sender, RoutedEventArgs e)
        {
            if (IsSaved == false)
            {
                MessageBoxResult result = MessageBox.Show(this, "Save changes to current document?", "Save Current Document", MessageBoxButton.YesNoCancel);

                if (result == MessageBoxResult.Yes)
                    Save(PostSavingTask.Open);
                else if (result == MessageBoxResult.No)
                    Open();
                else
                    return;
            }
            else
                Open();
        }

        public void Open()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = FileName; // Default file name
            dlg.DefaultExt = ".rgx"; // Default file extension
            dlg.Filter = "Regular Expression Tester XML Document (.rgx)|*.rgx"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;

                if (File.Exists(filename))
                {
                    FileName = dlg.SafeFileName;
                    FileNameWithPath = dlg.FileName;

                    OpenFile(FileNameWithPath);
                }
            }
        }

        private void OpenFile(string filename)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);

            //Validating
            if (ValidateXmlDocument(xmlDoc) == false)
            {
                //Document not available or valid
                MessageBox.Show("Invalid Document Format", "Invalid Document Format");
                if (Application.Current.Properties["FileNameWithPath"] == null)         //File is not opened using double click
                {
                    return;
                }
                else                                                                    //File opened using doubleclick
                {
                    New();
                    return;
                }
            }

            tbInput.Text = xmlDoc.ChildNodes[1].ChildNodes[0].InnerText;
            tbRegex.Text = xmlDoc.ChildNodes[1].ChildNodes[1].InnerText;

            string optionsString = xmlDoc.ChildNodes[1].ChildNodes[2].InnerText;
            if (optionsString.Contains("ECMAScript"))
            {
                cbEcma.IsChecked = true;

                cbCulInv.IsChecked = false;
                cbExpCap.IsChecked = false;
                cbIgnPatWhi.IsChecked = false;
                cbRTL.IsChecked = false;
                cbSL.IsChecked = false;
            }
            else
            {
                cbEcma.IsChecked = false;

                cbCulInv.IsChecked = optionsString.Contains("CultureInvariant");
                cbExpCap.IsChecked = optionsString.Contains("ExplicitCapture");
                cbIgnPatWhi.IsChecked = optionsString.Contains("IgnorePatternWhitespace");
                cbRTL.IsChecked = optionsString.Contains("RightToLeft");
                cbSL.IsChecked = optionsString.Contains("Singleline");
            }

            cbIgnCase.IsChecked = optionsString.Contains("IgnoreCase");
            cbML.IsChecked = optionsString.Contains("Multiline");

            this.Title = ProgramName + Path.GetFileNameWithoutExtension(filename);
            IsOpenDocSaved = true;
            IsSaved = true;
        }

        private bool ValidateXmlDocument(XmlDocument d)
        {
            if (d != null)
            {
                if (d.ChildNodes != null)
                {
                    if (d.ChildNodes.Count == 2)
                    {
                        if (d.ChildNodes[1].Name == "RegularExpressionTesterDocument")
                        {
                            if (d.ChildNodes[1].ChildNodes != null)
                            {
                                if (d.ChildNodes[1].ChildNodes.Count == 3)
                                {
                                    if (d.ChildNodes[1].ChildNodes[0].Name == "InputText" && d.ChildNodes[1].ChildNodes[1].Name == "RegexText" && d.ChildNodes[1].ChildNodes[2].Name == "RegexOptions")
                                        return true;
                                    else
                                        return
                                            false;
                                }
                                else
                                    return false;
                            }
                            else
                                return false;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }

        private void SaveCommandHandler(object sender, RoutedEventArgs e)
        {
            Save(PostSavingTask.Nothing);
        }

        private void SaveAsCommandHandler(object sender, RoutedEventArgs e)
        {
            SaveAs();
        }

        private bool Save(PostSavingTask Task)                         //Post saving task = False for nothing, true for new file, null for open file
        {
            if (IsOpenDocSaved == true)
            {
                SaveToFileNameWithPath(FileNameWithPath);
            }
            else
            {
                bool SaveAsResult = SaveAs();
                if (SaveAsResult == false)
                    return false;
            }

            switch (Task)
            {
                case PostSavingTask.New:
                    {
                        New();
                        break;
                    }
                case PostSavingTask.Open:
                    {
                        Open();
                        break;
                    }
                case PostSavingTask.Exit:
                    {
                        Application.Current.Shutdown();
                        break;
                    }
                case PostSavingTask.Nothing:
                    {
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            return true;
        }

        private bool SaveAs()                                               //Returns false if user cancels SaveAs Dialogbox
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = FileName;     // Default file name
            dlg.DefaultExt = ".rgx"; // Default file extension
            dlg.Filter = "Regular Expression Tester XML Document (.rgx)|*.rgx"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document

                FileName = dlg.SafeFileName;
                FileNameWithPath = dlg.FileName;

                SaveToFileNameWithPath(FileNameWithPath);

                IsOpenDocSaved = true;
                IsSaved = true;

                return true;
            }
            else
                return false;
        }

        private void SaveToFileNameWithPath(string NameWithPathOfFile)
        {
            XmlDocument xmlDoc = new XmlDocument();

            // Write down the XML declaration
            XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlDoc.InsertBefore(xmlDeclaration, xmlDoc.DocumentElement);

            // Create the root element
            XmlElement rootNode = xmlDoc.CreateElement("RegularExpressionTesterDocument");
            xmlDoc.AppendChild(rootNode);

            // Create the required nodes
            XmlElement InputTextNode = xmlDoc.CreateElement("InputText");
            XmlElement RegexTextNode = xmlDoc.CreateElement("RegexText");
            XmlElement RegexOptionsTextNode = xmlDoc.CreateElement("RegexOptions");

            // retrieve the text 
            XmlText InputText = xmlDoc.CreateTextNode(tbInput.Text);
            XmlText RegexText = xmlDoc.CreateTextNode(tbRegex.Text);
            XmlText RegexOptionsText = xmlDoc.CreateTextNode(options.ToString());

            // append the nodes to the parentNode without the value
            rootNode.AppendChild(InputTextNode);
            rootNode.AppendChild(RegexTextNode);
            rootNode.AppendChild(RegexOptionsTextNode);

            // save the value of the fields into the nodes
            InputTextNode.AppendChild(InputText);
            RegexTextNode.AppendChild(RegexText);
            RegexOptionsTextNode.AppendChild(RegexOptionsText);

            // Save to the XML file
            xmlDoc.Save(NameWithPathOfFile);

            this.Title = ProgramName + Path.GetFileNameWithoutExtension(NameWithPathOfFile);
            if (this.Title[this.Title.Length - 1] == '*')
                this.Title = this.Title.Remove(this.Title.Length - 1);
            IsSaved = true;
        }

        private void window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Properties.Settings.Default.SaveOnExit)
                SaveDataOnExit();

            if (IsSaved == false)
            {
                MessageBoxResult result = MessageBox.Show(this, "Save changes to current document?", "Save Current Document", MessageBoxButton.YesNoCancel);

                if (result == MessageBoxResult.Yes)
                {
                    bool SaveResult = Save(PostSavingTask.Exit);
                    if (SaveResult == false)
                        e.Cancel = true;
                }
                else if (result == MessageBoxResult.No)
                    Application.Current.Shutdown();
                else
                    e.Cancel = true;
            }
            else
                Application.Current.Shutdown();
        }
    }
}