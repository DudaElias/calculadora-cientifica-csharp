using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora
{
    class Elemento : IComparable<Elemento>
    {
        private string ele;
        private int prefe;

        public string Ele { get => ele; set => ele = value; }
        public int Prefe { get => prefe; set => prefe = value; }

        public Elemento(string el, int i)
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
