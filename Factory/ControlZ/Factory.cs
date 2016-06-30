using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlZ
{
    class Factory
    {
        private static readonly Factory _instance = new Factory();

        public static Factory INSTANCE
        {
            get
            {
                return _instance;
            }
        }

        private Factory()
        {

        }

        public enum NeedClassType
        {
            A,
            B,
            C
        }

        public NeedClass getNeedClass(NeedClassType type)
        {
            switch (type)
            {
                case NeedClassType.A:
                    return new A();
                case NeedClassType.B:
                    return new B();
                case NeedClassType.C:
                    return new C();
                default:
                    return null;
            }
        }

        class A : NeedClass
        {
            public string getstring()
            {
                return "I'm A";
            }
        }
        class B : NeedClass
        {
            public string getstring()
            {
                return "I'm B";
            }
        }
        class C : NeedClass
        {
            public string getstring()
            {
                return "I'm C";
            }
        }
    }
}
