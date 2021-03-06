﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Maria Eduarda Elias Rocha - 18190
//Guilherme Salim de Barros - 18188
namespace Calculadora
{
    public partial class frmCal : Form
    {
        public frmCal()
        {
            InitializeComponent();
        }

        // INSTANCIA DE UM OBJETO EXPRESSÃO E OBJESTOS PARA O CONTROLE DE QUANTIDADE DE PARÊNTESES E DADOS

        int qtd = 0;
        private Expressao ex = new Expressao();
        int qtdParenteses1 = 0;
        int qtdParenteses2 = 0;


        private void btnAbre_Click(object sender, EventArgs e)
        {

              

                if ((sender as Button).Text == "CE" && qtd != 0) // CASO O USUÁRIO DECIDA APAGAR O ÚLTIMO DADO DIGITADO
                {

                    if (txtResultado.Text.Substring(txtResultado.TextLength - 1, 1) == "(") // caso seja abre parentenses diminui um na variavel que controla o número de abre
                        qtdParenteses1--;
                    if (txtResultado.Text.Substring(txtResultado.TextLength - 1, 1) == ")") // caso seja fecha parenteses diminui um na variavel que controla o número de fecha
                        qtdParenteses2--;
                    txtResultado.Text = txtResultado.Text.Remove(txtResultado.TextLength - 1);
                    ex[qtd] = null;
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
                    btnFecha.Enabled = false;
                    btnDividir.Enabled = true;
                    btnElevado.Enabled = true;
                    btnMais.Enabled = true;
                    btnMenos.Enabled = true;
                    btnPonto.Enabled = true;
                }
                else if((sender as Button).Text == "C") // APAGAR TODA A EXPRESSÃO E RESETAR AS VARIÁVEIS DA INTÂNCIA EXPRESSÃO
                {
                    txtResultado.Text = "";
                    lblPos.Text = "Pósfixa: ";
                    for(int i = 0; i <= qtd; i++)
                    {
                        ex[i] = null;
                    }
                    qtdParenteses1 = 0;
                    qtdParenteses2 = 0;
                    txtResult.Text = "";
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
                    Elemento ele = new Elemento((sender as Button).Text, ex.DecidirPreferencia((sender as Button).Text)); // Um novo elemento para adicionar a expressão

                    if (txtResultado.Text != "")
                    {
                        if (ele.Prefe > 2) // caso seja um operador, os outros operadores seram desabilitados
                        {
                            btnDividir.Enabled = false;
                            btnElevado.Enabled = false;
                            btnMais.Enabled = false;
                            btnPonto.Enabled = false;
                            btnAbre.Enabled = true;
                            btnFecha.Enabled = false;
                            btnVezes.Enabled = false;

                        }
                        else
                        {
                            if (ele.Ele != "(") // caso seja um abre todos os operadores com excessão do - e + serão desabilitados
                            {
                                btnDividir.Enabled = true;
                                btnElevado.Enabled = true;
                                btnMais.Enabled = true;
                                btnPonto.Enabled = true;
                                btnVezes.Enabled = true;
                                btnFecha.Enabled = true;
                            }
                            else
                            {
                                btnDividir.Enabled = false;
                                btnElevado.Enabled = false;
                                btnMais.Enabled = false;
                                btnPonto.Enabled = false;
                                btnFecha.Enabled = true;
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
                        btnAbre.Enabled = true;
                        btnFecha.Enabled = true;
                    }
                    if (ele.Ele == ")") // adiciona um no controle de abre parenteses
                        qtdParenteses2++;
                    else if (ele.Ele == "(") // adiciona um no controle de fecha parenteses
                        qtdParenteses1++;


                    if (qtd != 0 && ex[qtd - 1].Prefe == 1 && ele.Prefe == 1) // espera um sinal para decidir o fim do elemento, fazendo com que possa ter mais de um dígito no número
                    {
                        if (ex[qtd - 1].Prefe == 1 || ex[qtd - 1].Ele == "-")
                            ex[qtd - 1].Ele += ele.Ele;
                    }
                    else if(qtd == 0 || ex[qtd - 1].Prefe != 1)
                    {
                        if(ele.Prefe == 3)
                            ele.Prefe = 1;
                        ex[qtd] = ele;
                        qtd++;
                    }
                    else
                    {
                        if(ex[qtd - 1].Ele == "-"&&ex[qtd - 1].Prefe == 1 && ele.Ele == "(")
                        {
                            ex[qtd - 1].Prefe = 3;
                        }
                        ex[qtd] = ele;
                        qtd++;
                    }
                    if(qtd == 20) // tamanho máximo de valores que pode se adicionar
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
                    if (ex[qtd-1] != null && ex[qtd-1].Prefe == 1 && ex[qtd - 1].Ele != "-")
                    {
                        btnAbre.Enabled = false;
                    }
                    else
                    {
                    btnAbre.Enabled = true;
                    }

                }
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
                btnFecha.Enabled = false;
            }
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {

            if (qtdParenteses1 != qtdParenteses2)
                MessageBox.Show("Quantidade de abre e fecha parênteses não correspondentes");
            else
            {
                Elemento[] eles = ex.ConverterParaLetra(qtd);
                string[] a = ex.ConverterParaPosFixa(ex.PilhaElementos, qtd);
                for (int i = 0; i < qtd; i++)
                {                   lblPos.Text += a[i];
                }
                ex.Calcular(txtResult, lblPos, txtResultado, ref qtd);
            }
        }

        
    }
}
