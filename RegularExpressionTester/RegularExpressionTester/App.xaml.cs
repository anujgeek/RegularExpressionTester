using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows;
using System.IO;

namespace RegularExpressionTester
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            this.Properties.Add("FileNameWithPath", null);
            this.Properties.Add("FileName", null);

            if (e.Args.Length != 0)
            {
                this.Properties["FileNameWithPath"] = e.Args[0];
                this.Properties["FileName"] = Path.GetFileName(e.Args[0]);
            }

            base.OnStartup(e);
        }
    }
}
