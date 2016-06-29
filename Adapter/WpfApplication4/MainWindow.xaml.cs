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

namespace WpfApplication4
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            A a = new A();
            MessageBox.Show(a.calc(2, 2).ToString());
        }

        class Adaptee
        {
            public double calc(double a, double b)
            {
                return a + b;
            }
        }

        interface Adapter
        {
            int calc(int a, int b);
        }

        class A : Adaptee, Adapter
        {
            public int calc(int a, int b)
            {
                return (int)base.calc((double)a, (double)b);
            }
        }


    }
}
