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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;

namespace Stegano
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OpenFileDialog load1 = new OpenFileDialog();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Load1Button_Click(object sender, RoutedEventArgs e)
        {
            load1.ShowDialog();
            load1.Filter = "All files (*.*)|*.*";
            LoadBox1.Text = load1.FileName;
        }

        private void Load2Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog load2 = new OpenFileDialog();
            load2.Filter = "All files (*.*)|*.*";
            load2.ShowDialog();
            LoadBox2.Text = load2.FileName;
        }

        private void Load3Button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "All files (*.*)|*.*";
            save.ShowDialog();
            SaveBox3.Text = save.FileName;
            String s = String.Format(@"copy /b {0}+{1} {2}", LoadBox1.Text, LoadBox2.Text, SaveBox3.Text);
            s = "/C " + s;
            Process.Start("cmd.exe", s);

           /* Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = "cmd.exe";
           // string s = String.Format("copy /b {0}+{1} {2}", LoadBox1.Text, LoadBox2.Text, SaveBox3.Text);
            p.StartInfo.Arguments = s;
          //  p.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            p.Start();*/
        }
    }
}
