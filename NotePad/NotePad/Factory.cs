using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotePad
{
    class Factory
    {
    #region Singleton
        private static readonly Factory _instance = new Factory();

        public static Factory INSTANCE { get { return _instance; } }

        private Factory()
        {
        }
    #endregion
    
        public IMyCustomCommand getKeyBoardDownCommand(object target, string key)
        {
            AlphabetKeyDown command = new AlphabetKeyDown(target, key);
            return command;
        }
    }
}
