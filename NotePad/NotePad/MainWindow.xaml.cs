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

namespace NotePad
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool IsControlDown = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            // ctrl+z 키 입력을 위한 처리

            if (e.Key == Key.LeftCtrl)
            {
                IsControlDown = false;
                return;
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            // ctrl+z 키 입력을 위한 처리

            if(e.Key == Key.LeftCtrl)
            {
                IsControlDown = true;
                return;
            }

            if (e.Key == Key.Z && IsControlDown)
            {
                GlobalEngine.INSTANCE.unDo();
                return;
            }

            // 알파벳, 공백 키 입력 시를 위한 처리

            if (e.Key >= Key.A && e.Key <= Key.Z)
            {
                GlobalEngine.INSTANCE.Do(Factory.INSTANCE.getKeyBoardDownCommand(tb_mainText, e.Key.ToString()));
            }

            if(e.Key == Key.Space)
            {
                GlobalEngine.INSTANCE.Do(Factory.INSTANCE.getKeyBoardDownCommand(tb_mainText, " "));
            }
        }
    }
}
