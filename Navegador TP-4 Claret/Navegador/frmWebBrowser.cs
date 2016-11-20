using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using Hilo;

namespace Navegador
{
    public partial class frmWebBrowser : Form
    {
        private const string ESCRIBA_AQUI = "Escriba aquí...";
        Archivos.Texto archivos;

        public frmWebBrowser()
        {
            InitializeComponent();
        }

        private void frmWebBrowser_Load(object sender, EventArgs e)
        {
            this.txtUrl.SelectionStart = 0;  //This keeps the text
            this.txtUrl.SelectionLength = 0; //from being highlighted
            this.txtUrl.ForeColor = Color.Gray;
            this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;

            archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);
        }

        #region "Escriba aquí..."
        private void txtUrl_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.IBeam; //Without this the mouse pointer shows busy
        }

        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(frmWebBrowser.ESCRIBA_AQUI) == true)
            {
                this.txtUrl.Text = "";
                this.txtUrl.ForeColor = Color.Black;
            }
        }

        private void txtUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(null) == true || this.txtUrl.Text.Equals("") == true)
            {
                this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;
                this.txtUrl.ForeColor = Color.Gray;
            }
        }

        private void txtUrl_MouseDown(object sender, MouseEventArgs e)
        {
            this.txtUrl.SelectAll();
        }
        #endregion

        delegate void ProgresoDescargaCallback(int progreso);
        
        private void ProgresoDescarga(int progreso)
        {
            if (statusStrip.InvokeRequired)
            {
                ProgresoDescargaCallback d = new ProgresoDescargaCallback(ProgresoDescarga);
                this.Invoke(d, new object[] { progreso });
            }
            else
            {
                tspbProgreso.Value = progreso;
            }
        }
        delegate void FinDescargaCallback(string html);
        
        /// <summary>
        /// al finalizar la descarga muestra el codigo HTML en rtxtHtmlCode.Text
        /// </summary>
        /// <param name="html"></param>
        private void FinDescarga(string html)
        {
            if (rtxtHtmlCode.InvokeRequired)
            {
                FinDescargaCallback d = new FinDescargaCallback(FinDescarga);
                this.Invoke(d, new object[] { html });
            }
            else
            {
                rtxtHtmlCode.Text = html;
            }
        }


        /// <summary>
        /// Al presionar el boton se valida la direccion y se la completa, a su vez se 
        /// inicializa la descarga del codigo html lanzando un nuevo hilo 
        /// </summary>
        /// <param name="sender">objeto enviado </param>
        /// <param name="e">parametro de evento</param>
        private void btnIr_Click(object sender, EventArgs e)
        {
            Uri direccion;

            if (!this.txtUrl.Text.StartsWith("http://"))
            {
                this.txtUrl.Text = "http://" + this.txtUrl.Text;
            }

            
                direccion = new Uri(this.txtUrl.Text);
            
            
            
            if (direccion != null )
            {
                Descargador descargador = new Descargador(direccion);
                
                descargador.progress += new Descargador.Progress(this.ProgresoDescarga);
                
               
                descargador.downloadComplete += new Descargador.DownloadComplete(this.FinDescarga);
                Thread thread = new Thread(descargador.IniciarDescarga);
                thread.Start();
                //thread.Abort(); 
                this.archivos.guardar(this.txtUrl.Text);
                
            }
        }
        /// <summary>
        /// Este metodo instancia el formulario de historial 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarTodoElHistorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmHistorial().ShowDialog();
        }

        private void txtUrl_TextChanged(object sender, EventArgs e)
        {
             
        }

        

       



    }
}