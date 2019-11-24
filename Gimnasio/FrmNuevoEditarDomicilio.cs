﻿using Datos;
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
    public partial class FrmNuevoEditarDomicilio : Form
    {
        GimnasioContext dbGimnasio;
        Domicilio domicilio;
        Cliente cliente;

        public FrmNuevoEditarDomicilio()
        {
            InitializeComponent();
            dbGimnasio = new GimnasioContext();
            domicilio = new Domicilio();
        }

        public FrmNuevoEditarDomicilio(GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            domicilio = new Domicilio();
        }

        public FrmNuevoEditarDomicilio(int idSeleccionado, GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            domicilio = new Domicilio();
            this.cargarDomicilio(idSeleccionado);
        }

        private void cargarDomicilio(int idSeleccionado)
        {
            domicilio = dbGimnasio.Domicilios.Find(idSeleccionado);
            txtNombreCalle.Text = domicilio.domicilio_calle;
            txtNumeroCalle.Text = domicilio.domocilio_numero.ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            domicilio.domicilio_calle = txtNombreCalle.Text;
            domicilio.domocilio_numero = Convert.ToInt32(txtNumeroCalle.Text);

            if (domicilio.domicilio_iddomicilio > 0)
            {
                dbGimnasio.Entry(domicilio).State = EntityState.Modified;
                MessageBox.Show("Se ha modificado correctamente.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dbGimnasio.Domicilios.Add(domicilio);
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
