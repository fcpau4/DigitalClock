using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DigitalClock
{
    /// <summary>
    /// Interaction logic for Dialog.xaml
    /// </summary>
    public partial class Dialog : Window
    {


        public Dialog(string defaultCountry = "", string defaultDiff="")
        {
            InitializeComponent();
            txtCountry.Text = defaultCountry;
            txtTimeDiff.Text = defaultDiff;
            
        }



        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            
        }



        private void Window_ContentRendered(object sender, EventArgs e)
        {
            txtCountry.SelectAll();
            txtCountry.Focus();
        }



        public string countryAnswer
        {
            get { return txtCountry.Text; }
        }




        public string timeDiffAnswer
        {
            get { return txtTimeDiff.Text; }
        }
    }
}
