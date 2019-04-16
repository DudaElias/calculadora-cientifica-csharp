using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    class Elemento : IComparable<Elemento>
    {
        private char ele;
        private int prefe;

        public char Ele { get => ele; set => ele = value; }
        public int Prefe { get => prefe; set => prefe = value; }

        public Elemento(char el, int i)
        {
            Ele = el;
            Prefe = i;
        }

        public int CompareTo(Elemento outro)
        {
            return 0;
        }
    }
}
