using System;
using System.Windows;

using ExceptionTail;

namespace BuggyApp.Wp
{
    public partial class MainPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void RandomException()
        {
            Thrower.Throw();
        }

        private void BtnSendGazillionClick(object sender, RoutedEventArgs e)
        {
            Exception exception = null;
            try
            {
                RandomException();
            }
            catch (Exception oops)
            {
                exception = oops;
            }

            ET.Publish(exception);

            var etStats = ET.GetStats();

            textBlock1.Text = etStats.NumberOfExceptionsInQueue + " " + etStats.NumberOfExceptionsInSendQueue + " " +
                              etStats.NumberOfExceptionsSent;

            var etExceptions = ET.GetExceptions();
            ET.SendExceptions(etExceptions);
        }
    }
}