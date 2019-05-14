using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculadora;
namespace Teste
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Expressao c = new Expressao();
            int indice = 0;


            //TESTE 1 E TESTE 2
            /*c[0] = new Elemento("4", 1);
            c[1] = new Elemento("-", 3);
            c[2] = new Elemento("2", 1);
            c[3] = new Elemento("*", 4);
            c[4] = new Elemento("2", 1);
            c[5] = new Elemento("^", 5);
            c[6] = new Elemento("2", 1);
            c[7] = new Elemento("+", 3);
            c[8] = new Elemento("2", 1);
            c[9] = new Elemento("/", 4);
            c[10] = new Elemento("2", 1);
            string[] es = { "1","2", "3", "4", "^", "*", "-", "5", "6", "/", "+"};
            var x = c.ConverterParaPosFixa(c.PilhaElementos, 11);
            indice = 11;
            */


            //TESTE 3
            c[0] = new Elemento("(", 2);
            c[1] = new Elemento("1", 1);
            c[2] = new Elemento("^", 5);
            c[3] = new Elemento("2", 1);
            c[4] = new Elemento("*", 4);
            c[5] = new Elemento("3", 1);
            c[6] = new Elemento("-", 3);
            c[7] = new Elemento("4", 1);
            c[8] = new Elemento("+", 3);
            c[9] = new Elemento("5", 1);
            c[10] = new Elemento("/", 4);
            c[11] = new Elemento("6", 1);
            c[12] = new Elemento("/", 4);
            c[13] = new Elemento("(", 2);
            c[14] = new Elemento("7", 1);
            c[15] = new Elemento("+", 3);
            c[16] = new Elemento("8", 1);
            c[17] = new Elemento(")", 2);
            c[18] = new Elemento(")", 2);
            string[] es = { "1","2", "^", "4", "*", "5", "-", "5", "6", "/", "7","8","+","/","+"};
            var x = c.ConverterParaPosFixa(c.PilhaElementos, 19);
            indice = 15;

            for (int i = 0; i < indice; i++)
            {
                Assert.AreEqual(es[i], x[i]);
            }
            
        }
    }
}
