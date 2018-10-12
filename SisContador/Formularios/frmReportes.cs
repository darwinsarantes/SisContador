using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SisContador.Formularios
{
    public partial class frmReportes : Form
    {
        public frmReportes()
        {
            InitializeComponent();
        }

        public string TituloVentana { set; get; }
        public Boolean VariosRegistros { set; get; }//Indica si se va a seleccionar uno o mas registros. true= varios, false=solo 1

        //DataTable DT;
        DataTable ListaImpresiones = new DataTable();
        BindingSource BD = new BindingSource();

        //frmVisor ofrmVisor = null;

        private void IniciarLaListaDeImpresiones()
        {
            ListaImpresiones.Columns.Add("No", typeof(Int32));
            ListaImpresiones.Columns.Add("Reporte", typeof(String));

            ListaImpresiones.Rows.Add(1, "Estado de cuenta bancaria");
            ListaImpresiones.Rows.Add(2, "Auxiliar del Mayor");

            BD.DataSource = ListaImpresiones;

        }

        private void EstablecerTituloDeVentana()
        {
            this.Text = "Reportes - " + this.TituloVentana;           
        }

        private void ListadoDeReportes()
        {
            IniciarLaListaDeImpresiones();

            dgvListadoDeReportes.DataSource = BD;
            FormatoDGVListaDeReportes();

        }

        private void FormatoDGVListaDeReportes()
        {
            try
            {
                this.dgvListadoDeReportes.AllowUserToResizeRows = false;
                this.dgvListadoDeReportes.AllowUserToAddRows = false;
                this.dgvListadoDeReportes.AllowUserToDeleteRows = false;
                this.dgvListadoDeReportes.DefaultCellStyle.BackColor = Color.White;
                this.dgvListadoDeReportes.MultiSelect = false;
                this.dgvListadoDeReportes.RowHeadersVisible = false;
                this.dgvListadoDeReportes.DefaultCellStyle.Font = new Font("Segoe UI", 8);
                this.dgvListadoDeReportes.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8);
                this.dgvListadoDeReportes.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
                this.dgvListadoDeReportes.BackgroundColor = System.Drawing.SystemColors.Window;
                this.dgvListadoDeReportes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

                this.dgvListadoDeReportes.Columns["No"].HeaderText = " ";
                this.dgvListadoDeReportes.Columns["Reporte"].HeaderText = "Reporte";

                this.dgvListadoDeReportes.Columns["No"].Width = 50;
                this.dgvListadoDeReportes.Columns["Reporte"].Width = 300;

                this.dgvListadoDeReportes.RowHeadersWidth = 25;

                this.dgvListadoDeReportes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvListadoDeReportes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.dgvListadoDeReportes.StandardTab = true;
                this.dgvListadoDeReportes.ReadOnly = true;
                this.dgvListadoDeReportes.CellBorderStyle = DataGridViewCellBorderStyle.Raised;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "FormatoDGVListado de reporte", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmReportes_Shown(object sender, EventArgs e)
        {
            this.TituloVentana = "Reportes generales";
            
            EstablecerTituloDeVentana();

            ListadoDeReportes();

        }

        private void txtListadoDeReportes_TextChanged(object sender, EventArgs e)
        {
            BD.Filter = string.Format(" Reporte like '%{0}%' ", txtListadoDeReportes.Text);
        }

        private void dgvListadoDeReportes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string Reporte = dgvListadoDeReportes.Rows[dgvListadoDeReportes.CurrentRow.Index].Cells["Reporte"].Value.ToString();           
        }
    }
}
