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

namespace Decorator
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Beverage var;

            var = new Espresso();

            IEspressoDecorator dec;

            dec = new Whip(new Whip2(var));

            MessageBox.Show(dec.getDescription() + " = " + dec.cost().ToString());
         }

        public interface Beverage
        {
            double cost();
            string getDescription();
        }

        public class Espresso : Beverage
        {
            string discription;

            public Espresso()
            {
                discription = "에스프레소";
            }

            public double cost()
            {
                return 1.99;
            }

            public string getDescription()
            {
                return discription;
            }
        }

        interface IEspressoDecorator : Beverage
        {

        }

        public class Whip : IEspressoDecorator
        {
            Beverage beverage;

            public Whip(Beverage b)
            {
                beverage = b;
            }

            public double cost()
            {
                return this.beverage.cost() + 4;
            }

            public string getDescription()
            {
                return beverage.getDescription() + ", 휩1";
            }
        }

        public class Whip2 : IEspressoDecorator
        {
            Beverage beverage;

            public Whip2(Beverage b)
            {
                beverage = b;
            }

            public double cost()
            {
                return this.beverage.cost() + 4;
            }

            public string getDescription()
            {
                return beverage.getDescription() + ", 휩2";
            }
        }

    }
}
