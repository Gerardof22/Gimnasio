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
    public partial class FrmNuevoEditarTipoTelefono : Form
    {
        GimnasioContext dbGimnasio;
        Tipo_Telefono tipo_Telefono;

        public FrmNuevoEditarTipoTelefono()
        {
            InitializeComponent();
            dbGimnasio = new GimnasioContext();
            tipo_Telefono = new Tipo_Telefono();
        }

        public FrmNuevoEditarTipoTelefono(GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            tipo_Telefono = new Tipo_Telefono();
        }

        public FrmNuevoEditarTipoTelefono(int idSeleccionado, GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            tipo_Telefono = new Tipo_Telefono();
            this.cargarTipoTelefono(idSeleccionado);
        }

        private void cargarTipoTelefono(int idSeleccionado)
        {
            tipo_Telefono = dbGimnasio.Tipo_Telefonos.Find(idSeleccionado);
            txtTipoTelefono.Text = tipo_Telefono.tipo_telefono_telefono;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            tipo_Telefono.tipo_telefono_telefono = txtTipoTelefono.Text;

            if (tipo_Telefono.tipo_telefono_idtipotelefono > 0)
            {
                dbGimnasio.Entry(tipo_Telefono).State = EntityState.Modified;
                MessageBox.Show("Se ha modificado correctamente.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dbGimnasio.Tipo_Telefonos.Add(tipo_Telefono);
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
