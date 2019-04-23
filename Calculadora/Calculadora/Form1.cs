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

        public void ConverterParaPosFixa()
        {
            bool primeiraVez = true;
            int operandos = 0;
            int qtdInfos = qtd;
            for (int i = 0; i < qtdInfos; i++)
            {
                if (pilhaElementos[i].Prefe == 2 && pilhaElementos[i].Ele == "(")
                {
                    int j = i;
                    while (pilhaElementos[j] != null && pilhaElementos[j].Ele != ")")
                    {
                        if (pilhaElementos[j].Prefe == 1)
                        {
                            posFixo.Empilhar(pilhaElementos[j].Ele);
                            pilhaElementos[j] = null;
                            operandos++;
                            if (operandos == 2)
                                primeiraVez = false;
                        }
                        else if (!primeiraVez)
                        {
                            // adiciona operação

                            if (pilhaElementos[j].Ele != "(" && pilhaElementos[j].Ele != ")")
                            {
                                if (pilhaElementos[j].Prefe <= DecidirPreferencia(Convert.ToString(elementosAEspera.OTopo())))
                                {
                                    while (!elementosAEspera.EstaVazia())
                                    {
                                        if(elementosAEspera.OTopo() != "(")
                                            posFixo.Empilhar(elementosAEspera.OTopo());
                                        elementosAEspera.Desempilhar();
                                    }
                                    elementosAEspera.Empilhar(pilhaElementos[j].Ele);
                                }
                                else
                                {
                                    elementosAEspera.Empilhar(pilhaElementos[j].Ele);
                                }
                            }
                        }
                        else
                        {
                            // coloca operação em espera
                            if (!elementosAEspera.EstaVazia() && pilhaElementos[j].Prefe < DecidirPreferencia(Convert.ToString(elementosAEspera.OTopo())))
                            {
                                string x = elementosAEspera.OTopo();
                                elementosAEspera.Desempilhar();
                                elementosAEspera.Empilhar(pilhaElementos[j].Ele);
                                elementosAEspera.Empilhar(x);
                            }
                            else
                                elementosAEspera.Empilhar(pilhaElementos[j].Ele);
                        }


                        j++;
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
                    i = j;
                }
                if (pilhaElementos[i].Prefe == 1)
                {
                    posFixo.Empilhar(pilhaElementos[i].Ele);
                    pilhaElementos[i] = null;
                    operandos++;
                    if (operandos == 2)
                        primeiraVez = false;
                }
                else if (!primeiraVez)
                {
                    // adiciona operação

                    if (pilhaElementos[i].Ele != "(" && pilhaElementos[i].Ele != ")")
                    {
                        if (!elementosAEspera.EstaVazia() && pilhaElementos[i].Prefe <= DecidirPreferencia(Convert.ToString(elementosAEspera.OTopo())))
                        {
                            while (!elementosAEspera.EstaVazia())
                            {
                                posFixo.Empilhar(elementosAEspera.OTopo());
                                elementosAEspera.Desempilhar();
                            }
                            elementosAEspera.Empilhar(pilhaElementos[i].Ele);
                        }
                        else
                        {
                            elementosAEspera.Empilhar(pilhaElementos[i].Ele);
                            pilhaElementos[i] = null;
                        }
                    }
                }
                else
                {
                    // coloca operação em espera
                    if (!elementosAEspera.EstaVazia() && pilhaElementos[i].Prefe < DecidirPreferencia(Convert.ToString(elementosAEspera.OTopo())))
                    {
                        string x = elementosAEspera.OTopo();
                        elementosAEspera.Desempilhar();
                        elementosAEspera.Empilhar(pilhaElementos[i].Ele);
                        elementosAEspera.Empilhar(x);
                    }
                    else
                    {
                        elementosAEspera.Empilhar(pilhaElementos[i].Ele);
                        pilhaElementos[i] = null;
                    }
                }

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
            posFixo.Inverter();
            posFixo.Atual = posFixo.Primeiro;
            for (int i = 1; i <= posFixo.Tamanho(); i++)
            {
                lblPos.Text += posFixo.Atual.Info + " ";
                posFixo.Atual = posFixo.Atual.Prox;
            }

        }

        private void frmCal_Load(object sender, EventArgs e)
        {

        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            ConverterParaPosFixa();
            //Calcular();
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
