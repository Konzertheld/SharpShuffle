using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SharpShuffle
{
    /// <summary>
    /// Interaktionslogik für AddPool.xaml
    /// </summary>
    public partial class wAddPool : Window
    {
        public wAddPool()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (System.IO.Directory.Exists(txtPath.Text))
            {
                if (txtPoolname.Text.Trim() != "" && txtPoolname.Text.Trim().Substring(0, 2) != "__")
                    Filemanagement.ProcessFolder(txtPath.Text, true, txtPoolname.Text);
                else
                    MessageBox.Show("Ungültiger Poolname. Der Poolname darf nicht leer sein und nicht mit zwei Unterstrichen beginnen.");
            }
            else
                MessageBox.Show("Der ausgewählte Pfad existiert nicht.");
            this.Close();
        }
    }
}
