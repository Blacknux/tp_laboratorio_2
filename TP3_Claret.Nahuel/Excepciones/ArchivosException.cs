﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException:Exception
    {
        public ArchivosException(Exception innerExeption):base("Error al procesar el archivo", innerExeption)
        { 
            
        }
    }
}
