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
    public partial class FrmNuevoEditarCardio : Form
    {
        GimnasioContext dbGimnasio;
        public Cardio cardio;

        public FrmNuevoEditarCardio()
        {
            InitializeComponent();
            dbGimnasio = new GimnasioContext();
            cardio = new Cardio();
        }

        public FrmNuevoEditarCardio(GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            cardio = new Cardio();
            cargarCardio(0);
        }
        public FrmNuevoEditarCardio(int idSeleccionado, GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            cardio = new Cardio();
            this.cargarCardio(idSeleccionado);
        }

        private void cargarCardio(int idSeleccionado)
        {
            cardio = dbGimnasio.Cardios.Find(idSeleccionado);
            txtDuracion.Text = cardio.cardio_duracion.ToString();
            txtRitmo.Text = cardio.cardio_ritmo;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            cardio.cardio_duracion = float.Parse(txtDuracion.Text);
            cardio.cardio_ritmo = txtRitmo.Text;

            if (cardio.cardio_idcardio > 0)
            {
                dbGimnasio.Entry(cardio).State = EntityState.Modified;
                MessageBox.Show("Se ha modificado correctamente.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dbGimnasio.Cardios.Add(cardio);
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
