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
            posFixo = new string[20];
            elementosAEspera = new PilhaHerdaLista<string>();
        }

        private Elemento[] pilhaElementos;
        private string[] numeros;
        private string[] posFixo;
        private PilhaHerdaLista<string> elementosAEspera;
        private int qtd = 0;



        private void btnAbre_Click(object sender, EventArgs e)
        {

              

                if ((sender as Button).Text == "CE" && qtd != 0)
                {
                    txtResultado.Text = txtResultado.Text.Remove(txtResultado.TextLength - 1);
                    pilhaElementos[qtd] = null;
                    qtd--;
                    btn0.Enabled = true;
                    btn1.Enabled = true;
                    btn2.Enabled = true;
                    btn3.Enabled = true;
                    btn4.Enabled = true;
                    btn5.Enabled = true;
                    btn6.Enabled = true;
                    btn7.Enabled = true;
                    btn8.Enabled = true;
                    btn9.Enabled = true;
                    btnAbre.Enabled = true;
                    btnFecha.Enabled = true;
                    btnDividir.Enabled = true;
                    btnElevado.Enabled = true;
                    btnMais.Enabled = true;
                    btnMenos.Enabled = true;
                    btnPonto.Enabled = true;
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
                    btn0.Enabled = true;
                    btn1.Enabled = true;
                    btn2.Enabled = true;
                    btn3.Enabled = true;
                    btn4.Enabled = true;
                    btn5.Enabled = true;
                    btn6.Enabled = true;
                    btn7.Enabled = true;
                    btn8.Enabled = true;
                    btn9.Enabled = true;
                    btnAbre.Enabled = true;
                    btnFecha.Enabled = true;
                    btnDividir.Enabled = true;
                    btnElevado.Enabled = true;
                    btnMais.Enabled = true;
                    btnMenos.Enabled = true;
                    btnPonto.Enabled = true;
                }
                else if((sender as Button).Text != "CE")
                {
                    txtResultado.Text += (sender as Button).Text;
                    Elemento ele = new Elemento((sender as Button).Text, DecidirPreferencia((sender as Button).Text));

                if (txtResultado.Text != "")
                {
                    if (ele.Prefe > 2)
                    {
                        btnDividir.Enabled = false;
                        btnElevado.Enabled = false;
                        btnMais.Enabled = false;
                        btnPonto.Enabled = false;
                        btnVezes.Enabled = false;
                    }
                    else
                    {
                        if (ele.Ele != "(")
                        {
                            btnDividir.Enabled = true;
                            btnElevado.Enabled = true;
                            btnMais.Enabled = true;
                            btnPonto.Enabled = true;
                            btnVezes.Enabled = true;
                        }
                        else
                        {
                            btnDividir.Enabled = false;
                            btnElevado.Enabled = false;
                            btnMais.Enabled = false;
                            btnPonto.Enabled = false;
                            btnVezes.Enabled = false;
                        }
                    }
                }
                else
                {
                    btnDividir.Enabled = false;
                    btnElevado.Enabled = false;
                    btnMais.Enabled = false;
                    btnPonto.Enabled = false;
                    btnVezes.Enabled = false;
                }

                

            


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
                    if(qtd == 20)
                    {
                        MessageBox.Show("O máximo de dados da calculadora foi alcançado", "Máximo alcançado", MessageBoxButtons.OK);
                        btn0.Enabled = false;
                        btn1.Enabled = false;
                        btn2.Enabled = false;
                        btn3.Enabled = false;
                        btn4.Enabled = false;
                        btn5.Enabled = false;
                        btn6.Enabled = false;
                        btn7.Enabled = false;
                        btn8.Enabled = false;
                        btn9.Enabled = false;
                        btnAbre.Enabled = false;
                        btnFecha.Enabled = false;
                        btnDividir.Enabled = true;
                        btnElevado.Enabled = false;
                        btnMais.Enabled = false;
                        btnMenos.Enabled = false;
                        btnPonto.Enabled = false;
                        qtd--;
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

        public void ConverterParaLetra()
        {
            numeros = new string[20];
            const int indice = 65;
            int letra = 0;
            for(int i = 0; i < qtd; i++)
            {
                if (pilhaElementos[i].Prefe == 1)
                {
                    numeros[letra] = pilhaElementos[i].Ele;
                    pilhaElementos[i].Ele = ((char)(indice + letra)).ToString();
                    letra++;
                }

            }
        }

        private string[] ConverterParaPosFixa(Elemento[] e, int qtdInfos)
        {
            int i;
            int j = 0;
            for(i = 0; i < qtdInfos; i++)
            {

                if (e[i].Prefe == 1)
                {
                    posFixo[j] = e[i].Ele;
                    j++;
                }

                else if (!elementosAEspera.EstaVazia() && e[i].Prefe <= DecidirPreferencia(Convert.ToString(elementosAEspera.OTopo())))
                {
                    if (e[i].Prefe != 2)
                    {
                        posFixo[j] = elementosAEspera.Desempilhar();
                        j++;
                        elementosAEspera.Empilhar(e[i].Ele);
                    }
                    else if (e[i].Ele == "(")
                        elementosAEspera.Empilhar(e[i].Ele);
                    else
                        while (elementosAEspera.OTopo() != "(")
                        {
                            posFixo[j] = elementosAEspera.Desempilhar();
                            j++;
                        }
                }
                else
                {
                    elementosAEspera.Empilhar(e[i].Ele);
                }
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

        private void frmCal_Load(object sender, EventArgs e)
        {
            if (txtResultado.Text == "")
            {
                btnElevado.Enabled = false;
                btnDividir.Enabled = false;
                btnMais.Enabled = false;
                btnVezes.Enabled = false;
                btnPonto.Enabled = false;
            }
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            ConverterParaLetra();
            string[] a = ConverterParaPosFixa(pilhaElementos, qtd);
            // CONFERIR SE OS PARENTESES ESTÃO COMBINADOS
            for(int i = 0; i < qtd; i++)
                lblPos.Text += a[i];
            Calcular();
        }

        public void Calcular()
        {
            PilhaHerdaLista<string> result = new PilhaHerdaLista<string>();
            double resultado = 0;
            int k = 0;
            for(int i = 0; i < qtd; i++)
            {
                if (DecidirPreferencia(posFixo[i]) == 1)
                {
                    result.Empilhar(numeros[k]);
                    k++;
                }
                else
                {
                    double operando2 = Convert.ToDouble(result.OTopo());
                    result.Desempilhar();
                    double operando1 = Convert.ToDouble(result.OTopo());
                    result.Desempilhar();
                    char operador = Convert.ToChar(posFixo[i]);
                    if (operando2 == 0 && operador == '/')
                    {
                        txtResult.Text = "";
                        lblPos.Text = "";
                        txtResultado.Text = "";
                        for (int j = 0; j <= qtd; j++)
                        {
                            pilhaElementos[j] = null;
                            posFixo[j] = null;
                            numeros[j] = "";
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

            txtResult.Text = Convert.ToString(result.Ultimo.Info);
            
        }
    }
}
