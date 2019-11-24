using Datos;
using System;
using System.Collections;
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
    public partial class FrmNuevoEditarTelefono : Form
    {
        GimnasioContext dbGimnasio;
        Telefono telefono;

        public int idtelefono { get; set; }

        public FrmNuevoEditarTelefono()
        {
            InitializeComponent();
            dbGimnasio = new GimnasioContext();
            telefono = new Telefono();
            this.cargarComboTipoTelefono(0);
        }

        public FrmNuevoEditarTelefono(GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            telefono = new Telefono();
            this.cargarComboTipoTelefono(0);
        }

        public FrmNuevoEditarTelefono(int idSeleccionado, GimnasioContext dbEnviado)
        {
            InitializeComponent();
            telefono = new Telefono();
            dbGimnasio = dbEnviado;
            cargarTelefono(idSeleccionado);
        }

        private void cargarTelefono(int idSeleccionado)
        {
            telefono = dbGimnasio.Telefonos.Find(idSeleccionado);
            cargarComboTipoTelefono(telefono.telefono_idtipotelefono);
            txtNumeroTelefono.Text = telefono.telefono_numero;
            cargarComboTipoTelefono(telefono.telefono_idtelefono);
        }

        private void cargarComboTipoTelefono(int idtipoTelefono)
        {
            cboTipoTelefono.DataSource = dbGimnasio.Tipo_Telefonos.ToList();

            //campo que vera el usuario
            cboTipoTelefono.DisplayMember = "tipo_telefono_telefono";

            //campo que es el valor real
            cboTipoTelefono.ValueMember = "tipo_telefono_idtipotelefono";
            cboTipoTelefono.SelectedValue = idtipoTelefono;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            telefono.Tipos_Telefonos = (Tipo_Telefono)cboTipoTelefono.SelectedItem;
            telefono.telefono_numero = txtNumeroTelefono.Text;

            if (telefono.telefono_idtelefono > 0)
            {
                dbGimnasio.Entry(telefono).State = EntityState.Modified;
                MessageBox.Show("Se ha modificado correctamente.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dbGimnasio.Telefonos.Add(telefono);
                
                MessageBox.Show("Se ha guardado correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dbGimnasio.SaveChanges();
            this.Close();
        }
    }
}
