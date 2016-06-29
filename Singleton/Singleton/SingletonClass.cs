using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class SingletonClass
    {
        #region Singleton
        private static SingletonClass _instance = new SingletonClass();

        public static SingletonClass INSTANCE
        {
            get
            {
                return _instance;
            }
        }

        private SingletonClass()
        {
        }

        #endregion
        
        public int getCount()
        {
            return 4;
        }

    }
}
