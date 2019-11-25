using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gimnasio
{
    public partial class FrmNuevoEditarTipoRutina : Form
    {
        GimnasioContext dbGimnasio;
        Tipo_Rutina tipo_rutina;

        internal static string tipo_rutina_nombre { get; set; }

        public FrmNuevoEditarTipoRutina()
        {
            InitializeComponent();
            dbGimnasio = new GimnasioContext();
            tipo_rutina = new Tipo_Rutina();
        }

        public FrmNuevoEditarTipoRutina(GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            tipo_rutina = new Tipo_Rutina();
        }

        public FrmNuevoEditarTipoRutina(int idSeleccionado, GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            tipo_rutina = new Tipo_Rutina();
            cargarTipoRutina(idSeleccionado);
        }

        private void cargarTipoRutina(int idSeleccionado)
        {
            tipo_rutina = dbGimnasio.Tipo_Rutinas.Find(idSeleccionado);
            txtTipoRutina.Text = tipo_rutina.tipo_rutina_nombre;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //tipo_rutina.tipo_rutina_nombre = txtTipoRutina.Text;

            if (tipo_rutina.tipo_rutina_idtiporutina > 0)
            {
                tipo_rutina.tipo_rutina_nombre = txtTipoRutina.Text;

                dbGimnasio.Entry(tipo_rutina).State = EntityState.Modified;
                MessageBox.Show("Se ha modificado correctamente.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dbGimnasio.SaveChanges();
                this.Close();
            }
            else
            {
                tipo_rutina_nombre = txtTipoRutina.Text;
                this.Close();
            }
            
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
