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

        private PilhaHerdaLista<char> pilhaElementos;
        private PilhaHerdaLista<char> posFixo;
        private void btnAbre_Click(object sender, EventArgs e)
        {
            pilhaElementos = new PilhaHerdaLista<char>();

            if (Convert.ToChar((sender as Button).Text) != '=')
            {
                txtResultado.Text += Convert.ToChar((sender as Button).Text);
                pilhaElementos.Empilhar(Convert.ToChar((sender as Button).Text));
            }
            else
            {
                ConverterParaPosFixa();
            }
        }

        public void ConverterParaPosFixa()
        {
            
            switch(pilhaElementos.OTopo().ToString())
            {
                case "1":

                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                case "6":
                    break;
                case "7":
                    break;
                case "8":
                    break;
                case "9":
                    break;
                case "0":
                    break;
                case ".":
                    break;
                case "/":
                    break;
                case "*":
                    break;
                case "+":
                    break;
                case "-":
                    break;
                case "^":
                    break;

            }
        }

        private void frmCal_Load(object sender, EventArgs e)
        {

        }
    }
}
