using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Elemento : IComparable<Elemento>
{
    private char ele;

    public char Ele { get => ele; set => ele = value; }

    public Elemento(char valor)
    {
        ele = valor;
    }

    public int CompareTo(Elemento outro)
    {
        return 0;
    }
        
}
