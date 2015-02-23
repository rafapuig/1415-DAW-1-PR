using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesDemo
{
    class CountDown : System.Collections.IEnumerator
    {
        int count = 11;

        public int MyProperty { get; set; }

        public object Current
        {
            get { return count; }
        }

        public bool MoveNext()
        {
            return count-- > 0;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
