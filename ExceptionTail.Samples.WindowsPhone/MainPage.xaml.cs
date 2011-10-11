using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace ExceptionTail.Samples.WindowsPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            ET.Initialize("YOUR_API_KEY");
        }

        private void button1_Click(object sender,RoutedEventArgs e)
        {
            try
            {
                throw null;
            }
            catch (Exception oops)
            {
                ET.Publish(oops);
            }
        }
    }
}