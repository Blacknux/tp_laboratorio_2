using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;
using System.Threading; 
namespace Hilo
{
    public class Descargador
    {
        
        private Uri direccion;
        private string result;
        public delegate void Progress(int progreso);
        public delegate void DownloadComplete(string html);
        public event Progress progress;
        public event DownloadComplete downloadComplete;

        /// <summary>
        /// inicializa el descargador con la url pasada por parametro 
        /// </summary>
        /// <param name="direccion">url para definir direccion</param>
        public Descargador(Uri direccion)
        {
            this.direccion = direccion;
            
        }
        /// <summary>
        /// Comienza la descarga del HTML indicado 
        /// </summary>
        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += WebClientDownloadCompleted;
                cliente.DownloadStringAsync(direccion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            
            this.progress(e.ProgressPercentage); 
                        
        }

        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            this.result = e.Result;
            this.downloadComplete(this.result);
            
        }
    }
}