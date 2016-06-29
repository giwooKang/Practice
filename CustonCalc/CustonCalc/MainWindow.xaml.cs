using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace CustonCalc
{
    public partial class MainWindow : Window
    {
        public enum DATATYPE
        {
            INT,
            STRING,
            NOTHING
        }

        class calcToken
        { 
            DATATYPE tokenType = DATATYPE.NOTHING;

            public DATATYPE getType()
            {
                return tokenType;
            }

            int _num;
            string _operator;

            public int Num { get { return _num; } set { _num = value; } }
            public string Oper { get { return _operator; } set { _operator = value; } }

            public calcToken(int num)
            {
                _num = num;
                tokenType = DATATYPE.INT;
            }

            public calcToken(string op)
            {
                _operator = op;
                tokenType = DATATYPE.STRING;
            }
        }

        enum STATUS
        {
            INIT,
            DOING
        }

        List<calcToken> calcList = new List<calcToken>();

        private void CalcParser()
        {
            string str = tb_main.Text;
            string[] str_list = str.Split(' ');
            foreach(string s in str_list)
            {
                if(isOperator(s[0]))
                {
                    calcList.Add(new calcToken(s));
                }
                else
                {
                    calcList.Add(new calcToken(int.Parse(s)));
                }
            }
        }

        private bool isOperator(char c)
        {
            if (c != '+' && c != '-' && c != '*' && c != '/')
                return false;
            else
                return true;
        }

        STATUS calcStatus = STATUS.INIT;

        public MainWindow()
        {
            InitializeComponent();

            initView();
        }

        private void initView()
        {
            btn_0.Click += num_Click;
            btn_1.Click += num_Click;
            btn_2.Click += num_Click;
            btn_3.Click += num_Click;
            btn_4.Click += num_Click;
            btn_5.Click += num_Click;
            btn_6.Click += num_Click;
            btn_7.Click += num_Click;
            btn_8.Click += num_Click;
            btn_9.Click += num_Click;

            btn_mul.Click += num_Click;
            btn_plus.Click += num_Click;
            btn_minus.Click += num_Click;
            btn_div.Click += num_Click;

            btn_equal.Click += Btn_equal_Click;

            btn_c.Click += Btn_c_Click;
        }

        private void Btn_c_Click(object sender, RoutedEventArgs e)
        {
            calcStatus = STATUS.INIT;
            tb_main.Text = "0";
        }

        private void Btn_equal_Click(object sender, RoutedEventArgs e)
        {
            CalcParser();
            Calc();
        }

        private void Calc()
        {
            if(calcList.Count==0)
            {
                tb_main.Text = "0";
                return;
            }

            for(int i=0;i<calcList.Count;i++)
            {
                switch (calcList[i].getType())
                {
                    case DATATYPE.STRING:
                        {
                            if (calcList[i].Oper == "/")
                            {
                                int result = calcList[i - 1].Num / calcList[i + 1].Num;

                                calcList[i - 1].Num = result;
                                calcList.RemoveAt(i);
                                calcList.RemoveAt(i);
                                i--;
                            }
                            else if (calcList[i].Oper == "*")
                            {
                                int result = calcList[i - 1].Num * calcList[i + 1].Num;

                                calcList[i - 1].Num = result;
                                calcList.RemoveAt(i);
                                calcList.RemoveAt(i);
                                i--;
                            }
                        }
                        break;
                    default:
                        {

                        }
                        break;
                }
            }

            for (int i = 0; i < calcList.Count; i++)
            {
                switch (calcList[i].getType())
                {
                    case DATATYPE.STRING:
                        {
                            if (calcList[i].Oper == "+")
                            {
                                int result = calcList[i - 1].Num + calcList[i + 1].Num;

                                calcList[i - 1].Num = result;
                                calcList.RemoveAt(i);
                                calcList.RemoveAt(i);
                                i--;
                            }
                            else if (calcList[i].Oper == "-")
                            {
                                int result = calcList[i - 1].Num - calcList[i + 1].Num;

                                calcList[i - 1].Num = result;
                                calcList.RemoveAt(i);
                                calcList.RemoveAt(i);
                                i--;
                            }
                        }
                        break;
                    default:
                        {

                        }
                        break;
                }
            }

            tb_main.Text = calcList[0].Num.ToString();
            calcList.RemoveAt(0);
            calcStatus = STATUS.INIT;
        }

        private void num_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Button)
            {
                Button btn = (Button)sender;
                string s = btn.Content.ToString();

                switch (calcStatus)
                {
                    case STATUS.INIT:
                        {
                            tb_main.Text = s;
                            if(s!="0")                            
                                calcStatus = STATUS.DOING;
                        }
                        break;
                    case STATUS.DOING:
                        {
                            if (isOperator(s[0]))
                            {
                                tb_main.Text += " " + s + " ";
                            }
                            else
                            {
                                tb_main.Text += s;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
