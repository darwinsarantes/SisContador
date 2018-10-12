﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class PrivilegioEN
    {
        //idPrivilegio, idModuloInterfaz, Nombre, IdUsuarioDeCreacion, FechaDeCreacion, IdUsuarioDeModificacion, FechaDeModificacion
        public int idPrivilegio { set; get; }   
        public string Nombre { set; get; }            
        
        public int IdUsuarioDeCreacion { set; get; }
        public DateTime FechaDeCreacion { set; get; }
        public int IdUsuarioDeModificacion { set; get; }
        public DateTime FechaDeModificacion { set; get; }

        public LoginEN oLoginEN = new LoginEN();
        public ModuloInterfazEN oModuloInterfazEN = new ModuloInterfazEN();

        public string Where { set; get; }
        public string OrderBy { set; get; }
        public string TituloDelReporte { set; get; }

    }
}
