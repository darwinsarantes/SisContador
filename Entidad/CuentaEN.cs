﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class CuentaEN
    {
        
        public string idCuenta { set; get; }
        public string DescCuenta { set; get; }
        public decimal SaldoCuenta { set; get; }
        public int NivelCuenta { set; get; }
        public string CuentaMadre { set; get; }
        
        public int IdUsuarioDeCreacion { set; get; }
        public DateTime FechaDeCreacion { set; get; }
        public int IdUsuarioDeModificacion { set; get; }
        public DateTime FechaDeModificacion { set; get; }
        public int NoCuenta { set; get; }

        public LoginEN oLoginEN = new LoginEN();

        public CategoriaDeCuentaEN oCategoriaDeCuentaEN = new CategoriaDeCuentaEN();

        public TipoDeCuentaEN oTipoDeCuentaEN = new TipoDeCuentaEN();

        public string Where { set; get; }
        public string OrderBy { set; get; }
        public string TituloDelReporte { set; get; }

        public int EsCuentaDeBanco { set; get; }

    }
}
