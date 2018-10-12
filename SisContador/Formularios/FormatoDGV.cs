using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisContador.Formularios
{
    class FormatoDGV
    {
        public string Columna { set; get; }
        public string Descripcion { set; get; }
        public int Tamano { set; get; }
        public bool SoloLectura { set; get; }
        public DataGridViewContentAlignment Alineacion { set; get; }
        public DataGridViewContentAlignment AlineacionDelEncabezado { set; get; }
        
        public bool ValorEncontrado { set; get; }

        public FormatoDGV(string NombreDelaColumna)
        {

            this.Columna = NombreDelaColumna.Trim();

            this.ValorEncontrado = true;
            
            switch (Columna)
            {

                case "Obsevaciones":
                    this.Descripcion = "Obsevaciones";
                    this.Tamano = 300;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "Hasta":
                    this.Descripcion = "Hasta";
                    this.Tamano = 130;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "Desde":
                    this.Descripcion = "Desde";
                    this.Tamano = 130;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "Codigo":
                    this.Descripcion = "Código";
                    this.Tamano = 100;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "RefBanco":
                    this.Descripcion = "Referencia";
                    this.Tamano = 130;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "ConceptoDeBanco":
                    this.Descripcion = "Concepto de Emisión de CK";
                    this.Tamano = 300;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "idTransaccionDetalle":
                    this.Descripcion = "ID";
                    this.Tamano = 50;
                    this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "Valor":
                    this.Descripcion = "Valor";
                    this.Tamano = 100;
                    this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "Concepto":
                    this.Descripcion = "Concepto de la Transacción";
                    this.Tamano = 300;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;


                case "idTransacciones":
                    this.Descripcion = "ID";
                    this.Tamano = 50;
                    this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;
                    
                case "NumeroDeTransaccion":
                    this.Descripcion = "No. Transacción";
                    this.Tamano = 100;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break; 

                case "Fecha":
                    this.Descripcion = "Fecha de la Transaccion";
                    this.Tamano = 160;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "DesTipoDeTransaccion":
                    this.Descripcion = "Tipo de Transacción";
                    this.Tamano = 160;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "idTipoDeTransaccion":
                    this.Descripcion = "ID";
                    this.Tamano = 50;
                    this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "Descripcion":
                    this.Descripcion = "Descripción";
                    this.Tamano = 350;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "idRol":
                    this.Descripcion = "ID";
                    this.Tamano = 50;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "DescTipoDeCuenta":
                    this.Descripcion = "Descripción del tipo de cuenta";
                    this.Tamano = 300;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "CuentaMadre":
                    this.Descripcion = "Cuenta madre";
                    this.Tamano = 80;
                    this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "NivelCuenta":
                    this.Descripcion = "Nivel de cuenta";
                    this.Tamano = 100;
                    this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "SaldoCuenta":
                    this.Descripcion = "Saldo";
                    this.Tamano = 100;
                    this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;
          
                case "DescCuenta":
                    this.Descripcion = "Descripción de la cuenta";
                    this.Tamano = 300;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "idCuenta":
                    this.Descripcion = "Cuenta";
                    this.Tamano = 160;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "NoCuenta":
                    this.Descripcion = "No";
                    this.Tamano = 50;
                    this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "Eliminar":
                    this.Descripcion = "Eliminar";
                    this.Tamano = 50;
                    this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = false;
                    break;

                case "Interfaz":
                    this.Descripcion = "Interfaz";
                    this.Tamano = 160;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "Modulo":
                    this.Descripcion = "Modulo";
                    this.Tamano = 160;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "NombreAMostrar":
                    this.Descripcion = "Descripción del privilegio";
                    this.Tamano = 160;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "Privilegio":
                    this.Descripcion = "Privilegio";
                    this.Tamano = 160;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "idModuloInterfazUsuario":
                    this.Descripcion = "ID";
                    this.Tamano = 50;
                    this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "Marcar":
                    this.Descripcion = "";
                    this.Tamano = 50;
                    this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = false;
                    break;

                case "Estado":
                    this.Descripcion = "Estado";
                    this.Tamano = 130;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "TipoDeCuenta":
                    this.Descripcion = "Tipo de cuenta";
                    this.Tamano = 200;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "Email":
                    this.Descripcion = "Correo electronico";
                    this.Tamano = 200;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "Login":
                    this.Descripcion = "Nombre de Sesión";
                    this.Tamano = 200;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "Usuario":
                    this.Descripcion = "Usuario";
                    this.Tamano = 300;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;
                    
                case "idUsuario":
                    this.Descripcion = "ID";
                    this.Tamano = 50;
                    this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "DescCategoriaDeCuenta":
                    this.Descripcion = "Descripción de la Categoria de la cuenta";
                    this.Tamano = 400;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "idCategoriaDeCuenta":
                    this.Descripcion = "ID";
                    this.Tamano = 50;
                    this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "Creditos":
                    this.Descripcion = "Creditos";
                    this.Tamano = 100;
                    this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;                    
                    break;

                case "Debitos":
                    this.Descripcion = "Debitos";
                    this.Tamano = 100;
                    this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "DescGrupoDeCuentas":
                    this.Descripcion = "Descripción del grupo de cuentas";
                    this.Tamano = 350;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "idGrupoDeCuentas":
                    this.Descripcion = "ID";
                    this.Tamano = 50;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "FechaDeCreacion":
                    this.Descripcion = "Crado el";
                    this.Tamano = 130;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;                    
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;
                
                case "FechaDeModificacion":
                    this.Descripcion = "Modificado el";
                    this.Tamano = 130;
                    this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = true;
                    break;

                case "Seleccionar":
                    this.Descripcion = " ";
                    this.Tamano = 50;
                    this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                    this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                    this.SoloLectura = false;
                    break;

                default: this.ValorEncontrado = false; break;

            }

        }

        public FormatoDGV(string NombreDelaColumna, string Tabla)
        {

            this.Columna = NombreDelaColumna;
            
            switch (Tabla)
            {//idTransaccionDetalle, NoCuenta, c.idCuenta,c.DescCuenta, Debe, Haber,
                case "TransaccionesDetalle":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {
                        case "idTransaccionDetalle":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;

                            break;

                        case "NoCuenta":
                            this.Descripcion = "No. Cuenta";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;

                            break;

                        case "idCuenta":
                            this.Descripcion = "No. Cuenta";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;
                                                  

                        case "Debe":
                            this.Descripcion = "Debe";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = false;
                            break;

                        case "Haber":
                            this.Descripcion = "Haber";
                            this.Tamano = 130;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleRight;
                            this.SoloLectura = false;

                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "Rol":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {
                        case "idRol":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;

                            break;

                        case "Nombre":
                            this.Descripcion = "Tipo de cuenta";
                            this.Tamano = 350;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        case "Descripcion":
                            this.Descripcion = "Descripción de la cuenta";
                            this.Tamano = 300;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;


                case "GrupoDeCuentas":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {
                        case "Creditos":
                            this.Descripcion = "Creditos";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;

                            break;

                        case "Debitos":
                            this.Descripcion = "Debitos";
                            this.Tamano = 100;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;

                            break;

                        case "idGrupoDeCuentas":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;
                            
                            break;
                            
                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "Periodo":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {

                        case "Nombre":
                            this.Descripcion = "Período";
                            this.Tamano = 300;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;

                            break;

                        case "idPeriodo":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "CategoriaDeCuentas":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {
                        
                        case "DescCategoriaDeCuenta":
                            this.Descripcion = "Descripción de la Categoria de la Cuenta";
                            this.Tamano = 300;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;

                            break;

                        case "idCategoriaDeCuenta":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;

                case "Usuario":

                    this.ValorEncontrado = true;

                    switch (Columna)
                    {
                        case "Estado":
                            this.Descripcion = "Estado";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;

                            break;

                        case "TipoDeCuenta":
                            this.Descripcion = "Tipo de cuenta";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;

                            break;

                        case "Email":
                            this.Descripcion = "Correo electronico";
                            this.Tamano = 160;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;

                            break;

                        case "Login":
                            this.Descripcion = "Nombre de sesión";
                            this.Tamano = 300;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;

                            break;

                        case "Usuario":
                            this.Descripcion = "Nombre del Usuario";
                            this.Tamano = 300;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleCenter;
                            this.SoloLectura = true;

                            break;

                        case "idUsuario":
                            this.Descripcion = "ID";
                            this.Tamano = 50;
                            this.AlineacionDelEncabezado = DataGridViewContentAlignment.MiddleCenter;
                            this.Alineacion = DataGridViewContentAlignment.MiddleLeft;
                            this.SoloLectura = true;

                            break;

                        default: this.ValorEncontrado = false; break;
                    }

                    break;
                
                default: this.ValorEncontrado = false; break;

            }

        }
    }
}
