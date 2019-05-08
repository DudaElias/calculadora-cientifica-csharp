using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    class Expressao
    {
        private Elemento[] pilhaElementos;
        private string[] numeros;
        private string[] posFixo;
        private PilhaHerdaLista<string> elementosAEspera;

        public Elemento[] PilhaElementos { get => pilhaElementos; set => pilhaElementos = value; }

        public Elemento this[int i]
        {
            get
            {
                if (pilhaElementos[i] != null)
                {
                    return pilhaElementos[i];
                }
                else
                    return null;
            }
            set
            {
                pilhaElementos[i] = value;
            }
        }

        public string[] Numeros { get => numeros; set => numeros = value; }
        public string[] PosFixo { get => posFixo; set => posFixo = value; }
        public PilhaHerdaLista<string> ElementosAEspera { get => elementosAEspera; set => elementosAEspera = value; }

        public Expressao()
        {
            pilhaElementos = new Elemento[20];
            posFixo = new string[20];
            elementosAEspera = new PilhaHerdaLista<string>();
        }
        public int DecidirPreferencia(string e)
        {

            switch (e)
            {
                case "/":
                    return 4;
                case "*":
                    return 4;
                case "+":
                    return 3;
                case "-":
                    return 3;
                case "^":
                    return 5;
                case "(":
                    return 2;
                case ")":
                    return 2;

            }

            try
            {
                //double eDouble = Convert.ToDouble(e);
                return 1;
            }
            catch
            {
                return 0;
            }


        }

        public Elemento[] ConverterParaLetra(int qtdInfos)
        {
            numeros = new string[20];
            const int indice = 65;
            int letra = 0;
            for (int i = 0; i < qtdInfos; i++)
            {
                if (pilhaElementos[i].Prefe == 1)
                {
                    numeros[letra] = pilhaElementos[i].Ele;
                    pilhaElementos[i].Ele = ((char)(indice + letra)).ToString();
                    letra++;
                }

            }
            return pilhaElementos;
        }

        public string[] ConverterParaPosFixa(Elemento[] e, int qtdInfos)
        {
            int i;
            int j = 0;
            for (i = 0; i < qtdInfos; i++)
            {

                if (e[i].Prefe == 1)
                {
                    posFixo[j] = e[i].Ele;
                    j++;
                }

                else if (!elementosAEspera.EstaVazia() && e[i].Prefe <= DecidirPreferencia(Convert.ToString(elementosAEspera.OTopo())))
                {
                    while (!elementosAEspera.EstaVazia() && e[i].Prefe <= DecidirPreferencia(Convert.ToString(elementosAEspera.OTopo())))
                    {
                        if (e[i].Prefe != 2)
                        {
                            posFixo[j] = elementosAEspera.Desempilhar();
                            j++;
                        }
                        else if (e[i].Ele == "(")
                        {
                            elementosAEspera.Empilhar(e[i].Ele);
                            break;
                        }
                        else
                        {
                            while (elementosAEspera.OTopo() != "(")
                            {
                                posFixo[j] = elementosAEspera.Desempilhar();
                                j++;
                            }
                            break;
                        }
                    }
                    if (e[i].Prefe != 2)
                        elementosAEspera.Empilhar(e[i].Ele);
                }
                else
                    elementosAEspera.Empilhar(e[i].Ele);
            }
            if (!elementosAEspera.EstaVazia())
            {
                while (!elementosAEspera.EstaVazia())
                {
                    if (elementosAEspera.OTopo() != "(" && elementosAEspera.OTopo() != ")")
                    {
                        posFixo[j] = elementosAEspera.OTopo();
                        j++;
                    }
                    elementosAEspera.Desempilhar();
                }
            }
            return posFixo;
        }

        public void Calcular(TextBox txtResult, Label lblPos, TextBox txtResultado, ref int qtdInfos)
        {
            PilhaHerdaLista<string> result = new PilhaHerdaLista<string>();
            double resultado = 0;
            int k = 0;
            for (int i = 0; i < qtdInfos; i++)
            {
                if (DecidirPreferencia(posFixo[i]) == 1)
                {
                    result.Empilhar(numeros[k]);
                    k++;
                }
                else
                {
                    double operando2 = double.Parse(result.OTopo());
                    result.Desempilhar();
                    double operando1 = double.Parse(result.OTopo());
                    result.Desempilhar();
                    char operador = Convert.ToChar(posFixo[i]);
                    if (operando2 == 0 && operador == '/')
                    {
                        txtResult.Text = "";
                        lblPos.Text = "";
                        txtResultado.Text = "";
                        for (int j = 0; j <= qtdInfos; j++)
                        {
                            pilhaElementos[j] = null;
                            posFixo[j] = null;
                            numeros[j] = "";
                        }
                        qtdInfos = 0;
                        MessageBox.Show("Divisão por 0 não pode ser realizada", "Divisão inválida", MessageBoxButtons.OK);
                        return;
                    }
                    else
                    {
                        switch (operador)
                        {
                            case '+':
                                resultado = operando1 + operando2;
                                break;
                            case '-':
                                resultado = operando1 - operando2;
                                break;
                            case '*':
                                resultado = operando1 * operando2;
                                break;
                            case '/':
                                resultado = operando1 / operando2;
                                break;
                            case '^':
                                resultado = Math.Pow(operando1, operando2);
                                break;
                        }
                        result.Empilhar(Convert.ToString(resultado));
                    }
                }
            }

            txtResult.Text = Convert.ToString(result.Ultimo.Info);

        }


    }
}
