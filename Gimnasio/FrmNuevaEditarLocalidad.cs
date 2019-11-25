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
    public partial class FrmNuevaEditarLocalidad : Form
    {
        GimnasioContext dbGimnasio;
        public Localidad localidad;

        public FrmNuevaEditarLocalidad()
        {
            InitializeComponent();
            dbGimnasio = new GimnasioContext();
            localidad = new Localidad();
        }

        public FrmNuevaEditarLocalidad(GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            localidad = new Localidad();
            cargarLocalidad(0);
        }

        public FrmNuevaEditarLocalidad(int idSeleccionado, GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            localidad = new Localidad();
            cargarLocalidad(idSeleccionado);
        }

        private void cargarLocalidad(int idSeleccionado)
        {
            localidad = dbGimnasio.Localidads.Find(idSeleccionado);
            txtLocalidadNombre.Text = localidad.localidad_localidad;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            localidad.localidad_localidad = txtLocalidadNombre.Text;

            if (localidad.localidad_idlocalidad > 0)
            {
                dbGimnasio.Entry(localidad).State = EntityState.Modified;
                MessageBox.Show("Se ha modificado correctamente.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dbGimnasio.Localidads.Add(localidad);
                MessageBox.Show("Se ha guardado correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dbGimnasio.SaveChanges();
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
