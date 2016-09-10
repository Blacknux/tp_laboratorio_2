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
        /// <summary>
        /// Al dibujar el Form, setea el color de fondo en gris agrega un titulo a la ventana con el nombre de usuario
        /// 
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.DarkGray;
            this.Text = "Calculadora de: " + Environment.UserName;
           
        }


        /// <summary>
        /// En este evento se realiza el calculo a traves de la funcion operar de la clase calculadora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            
            Numero numero1 = new Numero(this.txtNumero1.Text);
            Numero numero2 = new Numero(this.txtNumero2.Text);
            
            lblResultado.Text = Calculadora.Operar(numero1, numero2, this.cmbOperacion.Text).ToString();
        }

        /// <summary>
        /// Al ejecutar este metodo se limpian todos los textos que se ven en pantalla:
        /// Cuadros de texto
        /// combo box
        /// label resultado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.lblResultado.Text = "";
            this.cmbOperacion.Text = "";
            
        }

        /// <summary>
        /// Al presionar el boton cerrar, pregunta si estamos seguros a traves de un messageBox en caso que pongan si Sale
        /// caso contrario anula el proceso de cerrado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           DialogResult rta= MessageBox.Show("Seguro quiere salir??", "Atencion Saliendo", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

           if (rta == DialogResult.No)
           {
               e.Cancel = true;
               this.BackColor = Color.AliceBlue;
           }
            
        }

        /// <summary>
        /// Al hacer click al labelLink, se abrira un browser con el profile de Github del creador. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnklblGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/blacknux");
        }

        
    

    }
}
