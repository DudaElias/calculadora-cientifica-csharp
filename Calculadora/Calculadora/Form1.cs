using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class frmCal : Form
    {
        public frmCal()
        {
            InitializeComponent();
            pilhaElementos = new Elemento[20];
            posFixo = new PilhaHerdaLista<string>();
            elementosAEspera = new PilhaHerdaLista<string>();
        }

        private Elemento[] pilhaElementos;
        private PilhaHerdaLista<string> posFixo;
        private PilhaHerdaLista<string> elementosAEspera;
        private int qtd = 0;

        private void btnAbre_Click(object sender, EventArgs e)
        {
                if ((sender as Button).Text == "CE" && qtd != 0)
                {
                    txtResultado.Text = txtResultado.Text.Remove(txtResultado.TextLength - 1);
                    pilhaElementos[qtd] = null;
                    qtd--;
                }
                else if((sender as Button).Text == "C")
                {
                    txtResultado.Text = "";
                lblPos.Text = "";
                    for(int i = 0; i <= qtd; i++)
                    {
                        pilhaElementos[i] = null;
                    }
                    qtd = 0;
                }
                else if((sender as Button).Text != "CE")
                {
                    txtResultado.Text += (sender as Button).Text;
                    Elemento ele = new Elemento((sender as Button).Text, DecidirPreferencia((sender as Button).Text));

                    
                    
                    if (qtd != 0 && pilhaElementos[qtd - 1].Prefe == 1 && ele.Prefe == 1)
                    {

                        if (pilhaElementos[qtd - 1].Prefe == 1 || pilhaElementos[qtd - 1].Ele == "-")
                            pilhaElementos[qtd - 1].Ele += ele.Ele;
                    }
                    else if(qtd == 0 || pilhaElementos[qtd - 1].Prefe != 1)
                    {
                        if(ele.Prefe == 3)
                            ele.Prefe = 1;
                        pilhaElementos[qtd] = ele;
                        qtd++;
                    }
                    else
                    {
                        pilhaElementos[qtd] = ele;
                        qtd++;
                    }

                }
        }

        public int DecidirPreferencia(string e)
        {

            switch (e)
            {
                /*case "1":
                    return 1;
                case "2":
                    return 1;
                case "3":
                    return 1;
                case "4":
                    return 1;
                case "5":
                    return 1;
                case "6":
                    return 1;
                case "7":
                    return 1;
                case "8":
                    return 1;
                case "9":
                    return 1;
                case "0":
                    return 1;*/
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

        private PilhaHerdaLista<string> ConverterParaPosFixa(Elemento[] e, int qtdInfos)
        {
            for(int i = 0; i < qtdInfos; i++)
            {
                
                if (e[i].Prefe == 1)
                {
                    posFixo.Empilhar(e[i].Ele);
                }

                else if(!elementosAEspera.EstaVazia() && e[i].Prefe <= DecidirPreferencia(Convert.ToString(elementosAEspera.OTopo())))
                {
                    if (e[i].Prefe != 2)
                    {
                        posFixo.Empilhar(elementosAEspera.Desempilhar());
                        elementosAEspera.Empilhar(e[i].Ele);
                    }
                    else if (e[i].Ele == "(")
                        elementosAEspera.Empilhar(e[i].Ele);
                    else
                        while (elementosAEspera.OTopo() != "(")
                            posFixo.Empilhar(elementosAEspera.Desempilhar());
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
                        posFixo.Empilhar(elementosAEspera.OTopo());
                    }
                    elementosAEspera.Desempilhar();
                }
            }
            return posFixo;
            

        }

        private void frmCal_Load(object sender, EventArgs e)
        {

        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            PilhaHerdaLista<string> p =  ConverterParaPosFixa(pilhaElementos, qtd);
            p.Inverter();
            p.Atual = p.Primeiro;
            for (int i = 1; i <= p.Tamanho(); i++)
            {
                lblPos.Text += p.Atual.Info + " ";
                p.Atual = p.Atual.Prox;
            }
            Calcular();
        }

        public void Calcular()
        {
            PilhaHerdaLista<string> result = new PilhaHerdaLista<string>();
            double resultado = 0;
            for(int i = 0; !posFixo.EstaVazia(); i++)
            {
                if (DecidirPreferencia(posFixo.OTopo()) == 1)
                {
                    result.Empilhar(posFixo.OTopo());
                    posFixo.Desempilhar();
                }
                else
                {
                    double operando2 = Convert.ToDouble(result.OTopo());
                    result.Desempilhar();
                    double operando1 = Convert.ToDouble(result.OTopo());
                    result.Desempilhar();
                    char operador = Convert.ToChar(posFixo.OTopo());
                    posFixo.Desempilhar();
                    if (operando2 == 0 && operador == '/')
                    {
                        txtResult.Text = "";
                        lblPos.Text = "";
                        txtResultado.Text = "";
                        for (int j = 0; j <= qtd; j++)
                        {
                            pilhaElementos[j] = null;
                            if(!posFixo.EstaVazia())
                                posFixo.Desempilhar();
                        }
                        qtd = 0;
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

            txtResult.Text = Convert.ToString(result.OTopo());
        }
    }
}
