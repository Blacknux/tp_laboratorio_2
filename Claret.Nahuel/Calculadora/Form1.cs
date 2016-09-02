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
    public partial class Form1 : Form
    {
        //bool flagFirstTime = true;
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.DarkGray;
            this.Text = "Bienvenido " + Environment.UserName;//System.Security.Principal.WindowsIdentity.GetCurrent().;
           
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            
            Numero numero1 = new Numero(this.txtNumero1.Text);
            Numero numero2 = new Numero(this.txtNumero2.Text);
            
            lblResultado.Text = Calculadora.Operar(numero1, numero2, this.cmbOperacion.Text).ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.lblResultado.Text = "";
            this.cmbOperacion.Text = "";
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           DialogResult rta= MessageBox.Show("Seguro quiere salir??", "Atencion Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

           if (rta == DialogResult.No)
           {
               e.Cancel = true;
               this.BackColor = Color.AliceBlue;
           }
            
        }

        private void lnklblGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/blacknux");
        }

        
    

    }
}
