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

namespace interfaceTest
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
            btn_button.Click += Btn_button_Click;
        }

        private void Btn_button_Click(object sender, RoutedEventArgs e)
        {
            player a = new rabbit();
            a.attack();
        }

        interface player
        {
            void attack();
        }

        class rabbit : player
        {
            public rabbit()
            {

            }

            public void attack()
            {
                MessageBox.Show("토끼");
            }
        }

        class human : player
        {
            public human()
            {

            }
            public void attack()
            {
                MessageBox.Show("사람");
            }
        }
    }
}
