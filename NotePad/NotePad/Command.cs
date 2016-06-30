using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NotePad
{
    interface IMyCustomCommand
    {
        void Do();
        void UnDo();
    }

    class AlphabetKeyDown : IMyCustomCommand
    {
        object target;
        string unDoString;
        string key;

        public AlphabetKeyDown(object target, string key)
        {
            this.target = target;
            this.key = key;
        }

        public void Do()
        {
            if(target is TextBlock)
            {
                TextBlock tb = (TextBlock)target;
                unDoString = tb.Text;

                tb.Text += key;       
            }
        }

        public void UnDo()
        {
            if (target is TextBlock)
            {
                TextBlock tb = (TextBlock)target;
                tb.Text = unDoString;
            }
        }
    }

}
