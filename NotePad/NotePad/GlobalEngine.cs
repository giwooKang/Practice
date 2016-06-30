using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotePad
{
    class GlobalEngine
    {
        #region Singleton
        private static readonly GlobalEngine _instance = new GlobalEngine();

        public static GlobalEngine INSTANCE { get { return _instance; } }

        private GlobalEngine()
        {
        }
        #endregion

        List<IMyCustomCommand> commandList = new List<IMyCustomCommand>();

        public void Do(IMyCustomCommand command)
        {
            command.Do();
            commandList.Add(command);
        }

        public void unDo()
        {
            int count = commandList.Count-1;

            commandList[count].UnDo();
            commandList.RemoveAt(count);
        }
        
    }
}
