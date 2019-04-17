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
            posFixo = new PilhaHerdaLista<char>();
            elementosAEspera = new PilhaHerdaLista<char>();
        }

        private Elemento[] pilhaElementos;
        private PilhaHerdaLista<char> posFixo;
        private PilhaHerdaLista<char> elementosAEspera;
        private int qtd = 0;
        private void btnAbre_Click(object sender, EventArgs e)
        {

            if (Convert.ToChar((sender as Button).Text) != '=')
            {
                if (Convert.ToChar((sender as Button).Text) == 'C')
                {
                    txtResultado.Text = txtResultado.Text.Remove(txtResultado.TextLength - 1);
                    pilhaElementos[qtd] = null;
                }
                else
                {
                    txtResultado.Text += Convert.ToChar((sender as Button).Text);
                    Elemento ele = new Elemento(Convert.ToChar((sender as Button).Text), DecidirPreferencia((sender as Button).Text));
                    pilhaElementos[qtd] = ele;
                    qtd++;
                }

            }
            else
            {
                ConverterParaPosFixa();
            }
        }

        public int DecidirPreferencia(string e)
        {

            switch (e)
            {
                case "1":
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
                    return 1;
                case "/":
                    return 3;
                case "*":
                    return 3;
                case "+":
                    return 2;
                case "-":
                    return 2;
                case "^":
                    return 4;

            }
            return 0;
        }

        public void ConverterParaPosFixa()
        {

        }

        private void frmCal_Load(object sender, EventArgs e)
        {

        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            int operandos = 0;
            for(int i = 0; i < qtd; i++)
            {
                if(pilhaElementos[i].Prefe == 1)
                {
                    posFixo.Empilhar(pilhaElementos[i].Ele);
                    pilhaElementos[i] = null;
                    operandos++;
                }
                else if(operandos == 2)
                {
                    // adiciona operação
                    if(pilhaElementos[i].Prefe < DecidirPreferencia(Convert.ToString(elementosAEspera.OTopo())))
                    {
                        posFixo.Empilhar(elementosAEspera.OTopo());
                        elementosAEspera.Desempilhar();
                        elementosAEspera.Empilhar(pilhaElementos[i].Ele);
                        operandos = 0;
                    }
                    else
                    {
                        elementosAEspera.Empilhar(pilhaElementos[i].Ele);
                        operandos = 0;
                    }
                }
                else
                {
                    if (!elementosAEspera.EstaVazia() && pilhaElementos[i].Prefe < DecidirPreferencia(Convert.ToString(elementosAEspera.OTopo())))
                    {
                        char x = elementosAEspera.OTopo();
                        elementosAEspera.Desempilhar();
                        elementosAEspera.Empilhar(pilhaElementos[i].Ele);
                        elementosAEspera.Empilhar(x);
                    }
                    else
                        elementosAEspera.Empilhar(pilhaElementos[i].Ele);
                    // coloca operação em espera
                }

            }
            if (!elementosAEspera.EstaVazia())
            {
                while (!elementosAEspera.EstaVazia())
                {
                    posFixo.Empilhar(elementosAEspera.OTopo());
                    elementosAEspera.Desempilhar();
                }
            }
            posFixo.Inverter();
            posFixo.Atual = posFixo.Primeiro;
            for (int i = 1; i <= posFixo.Tamanho(); i++)
            {
                lblPos.Text += posFixo.Atual.Info;
                posFixo.Atual = posFixo.Atual.Prox;
            }

        }
    }
}
