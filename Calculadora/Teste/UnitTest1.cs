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
            c[0] = new Elemento("(", 2);
            c[1] = new Elemento("4", 1);
            c[2] = new Elemento("^", 5);
            c[3] = new Elemento("2", 1);
            c[4] = new Elemento("*", 4);
            c[5] = new Elemento("3", 1);
            c[6] = new Elemento("-", 3);
            c[7] = new Elemento("1", 1);
            c[8] = new Elemento("+", 3);
            c[9] = new Elemento("3", 1);
            c[10] = new Elemento("/", 4);
            c[11] = new Elemento("1", 1);
            c[12] = new Elemento("/", 4);
            c[13] = new Elemento("(", 2);
            c[14] = new Elemento("2", 1);
            c[15] = new Elemento("+", 3);
            c[16] = new Elemento("1", 1);
            c[17] = new Elemento(")", 2);
            c[18] = new Elemento(")", 2);
            c[19] = new Elemento("/", 4);
            string[] es = { "(","4", "^", "2", "*", "3", "-", "1", "+", "3", "/", "1", "/", "(","2", "+", "1",")",")" };
            //Classe Assert possui métodos para comparação de valores
            var x = c.ConverterParaPosFixa(c.PilhaElementos, 11);

            for (int i = 0; i < 20; i++)
            {
                Assert.AreEqual(es[i], x[i]);
            }
            
        }

        public bool Certo(Expressao c)
        {
            /*for (int i = 0; i < 3; i++)
            {
                if (esperado[i] != resultado[i])
                    return false;
                if(i == 2)
                    return true;
            }
            return false;*/
            return true;
        }
    }
}
