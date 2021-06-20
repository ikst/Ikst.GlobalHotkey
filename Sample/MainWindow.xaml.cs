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
using Ikst.GlobalHotkey;

namespace Sample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            GlobalHotkey gh = new GlobalHotkey();

            gh.Regist((int)(ModifierKeys.Control | ModifierKeys.Shift), KeyInterop.VirtualKeyFromKey(Key.Q), () => MessageBox.Show("test1"));
            gh.Regist((int)(ModifierKeys.Control | ModifierKeys.Shift), KeyInterop.VirtualKeyFromKey(Key.W), () => MessageBox.Show("test2"));


        }
    }
}
