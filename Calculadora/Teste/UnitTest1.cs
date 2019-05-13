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
            c[0]=new Elemento("(",2);
            c[1] = new Elemento("1",1);
            c[2] = new Elemento("+",3);
            c[3] = new Elemento("2",1);
            c[4] = new Elemento(")",2);
            /*c[5] = new Elemento("",);
            c[6] = new Elemento("",);
            c[7] = new Elemento("",);
            c[8] = new Elemento("",);
            c[9] = new Elemento("",);
            c[10] = new Elemento("",);
            c[11] = new Elemento("",);*/
            
            //Classe Assert possui métodos para comparação de valores
            Assert.IsTrue(Certo(c));

        }

        public bool Certo(Expressao c)
        {
            string[] esperado = { "1", "2", "+" };
            string[] resultado = c.ConverterParaPosFixa(c.PilhaElementos, 5);
            for (int i = 0; i < 3; i++)
            {
                if (esperado[i] != resultado[i])
                    return false;
                if(i == 2)
                    return true;
            }
            return false;
        }
    }
}
