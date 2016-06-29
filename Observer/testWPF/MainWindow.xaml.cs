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

namespace testWPF
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        flagObserver observer = new flagObserver();

        public MainWindow()
        {
            InitializeComponent();
            btn_any.Click += Btn_any_Click;

            chongGi flag_left = new chongGi(tb_chong);
            observer.attachFlag(flag_left);

            backGi flag_right = new backGi(tb_back);
            observer.attachFlag(flag_right);
        }

        private void Btn_any_Click(object sender, RoutedEventArgs e)
        {
            observer.allFlagUp();
        }

        class flagObserver
        {
            List<flag> list;

            public flagObserver()
            {
                list = new List<flag>();
            }

            public void attachFlag(flag anyFlag)
            {
                list.Add(anyFlag);
            }

            public void allFlagUp()
            {
                foreach(flag Flag in list)
                {
                    Flag.update();
                }
            }
        }
        
        interface flag
        {
            void update();
        }

        class chongGi : flag
        {
            TextBlock textbox;
            int count;

            public chongGi(TextBlock textbox)
            {
                this.textbox = textbox;
                count = 0;
            }

            public void update()
            {
                count++;
                textbox.Text = count.ToString();
            }
        }

        class backGi : flag
        {
            TextBlock textbox;
            int count;

            public backGi(TextBlock textbox)
            {
                this.textbox = textbox;
                count = 0;
            }

            public void update()
            {
                count++;
                textbox.Text = count.ToString();
            }
        }
    }
}
