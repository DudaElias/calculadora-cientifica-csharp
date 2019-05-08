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
        }
        int qtd = 0;
        

        private Expressao ex = new Expressao();



        private void btnAbre_Click(object sender, EventArgs e)
        {

              

                if ((sender as Button).Text == "CE" && qtd != 0)
                {
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
                        ex[i] = null;
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
                    Elemento ele = new Elemento((sender as Button).Text, ex.DecidirPreferencia((sender as Button).Text));

                if (txtResultado.Text != "")
                {
                    if (ele.Prefe > 2)
                    {
                        btnDividir.Enabled = false;
                        btnElevado.Enabled = false;
                        btnMais.Enabled = false;
                        btnPonto.Enabled = false;

                        btnAbre.Enabled = true;
                        btnFecha.Enabled = true;
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
                    btnAbre.Enabled = true;
                    btnFecha.Enabled = true;
                }
                
                if (qtd != 0 && ex[qtd - 1].Prefe == 1 && ele.Prefe == 1)
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
                    ex[qtd] = ele;
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
                    if (ex[qtd-1] != null && ex[qtd-1].Prefe == 1)
                    {
                        btnAbre.Enabled = false;
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
            }
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            Elemento[] eles = ex.ConverterParaLetra(qtd);
            string[] a = ex.ConverterParaPosFixa(ex.PilhaElementos, qtd);
            
            // CONFERIR SE OS PARENTESES ESTÃO COMBINADOS
            for (int i = 0; i < qtd; i++)
            {
                lblIn.Text += eles[i].Ele;
                lblPos.Text += a[i];
            }
            ex.Calcular(txtResult,lblPos,txtResultado,ref qtd);
        }

        
    }
}
