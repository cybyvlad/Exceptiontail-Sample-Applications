﻿using System;
using System.Windows.Forms;

using ExceptionTail;

using log4net.Config;

namespace BuggyApp
{
    internal static class Program
    {
        /// <summary>
        ///    The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            ET.Initialize("YOUR_API_KEY");
            ETSettings.SendMode = ESendMode.OnDemand;
            XmlConfigurator.Configure();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ExceptionGeneratorForm());
        }
    }
}