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

        private PilhaHerdaLista<Elemento> pilhaElementos;
        private PilhaHerdaLista<Elemento> posFixo;
        private void btnAbre_Click(object sender, EventArgs e)
        {
            pilhaElementos = new PilhaHerdaLista<Elemento>();

            while (Convert.ToChar((sender as Button).Text) != '=')
            {
                pilhaElementos.Empilhar(new Elemento(Convert.ToChar((sender as Button).Text)));
            }
            ConverterParaPosFixa();

        }

        public void ConverterParaPosFixa()
        {
            
            switch(pilhaElementos.OTopo().Ele)
            {
                case '1':
                    break;
                case '2':
                    break;
                case '3':
                    break;
                case '4':
                    break;
                case '5':
                    break;
                case '6':
                    break;
                case '7':
                    break;
                case '8':
                    break;
                case '9':
                    break;
                case '0':
                    break;
                case '.':
                    break;
                case '/':
                    break;
                case '*':
                    break;
                case '+':
                    break;
                case '-':
                    break;
                case '^':
                    break;

            }
        }
    }
}
