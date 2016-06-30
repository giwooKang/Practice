using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlZ
{
    class GlobelEngine
    {
        private static readonly GlobelEngine _instance = new GlobelEngine();

        public static GlobelEngine INSTANCE{ get { return _instance; } }

        private GlobelEngine()
        {

        }

        public Factory.NeedClassType getSystemType()
        {
            return Factory.NeedClassType.A;
        }
    }
}
