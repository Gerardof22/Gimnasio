﻿using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
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
            this.CargarComboCalle(domicilio.Calle.idcalle);
            txtNumeroCalle.Text = domicilio.domocilio_numero.ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                domicilio.Calle = (Calle)cboCalle.SelectedItem;
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
            catch (DbEntityValidationException ex) //<-- Sí ocurre alguna excepción al guardar porque la consola debbug no muestra el error real.
            {
                this.ValidarCatch(ex);
                throw;
            }
        }

        private void ValidarCatch(DbEntityValidationException ex)
        {
            foreach (var dbEntityValidation in ex.EntityValidationErrors)
            {
                Console.WriteLine("El tipo de entidad \"{0}\" en el estado \"{1}\" tiene los siguientes errores de validación:",
                    dbEntityValidation.Entry.Entity.GetType().Name, dbEntityValidation.Entry.State);
                foreach (var ve in dbEntityValidation.ValidationErrors)
                {
                    Console.WriteLine("- Propiedad: \"{0}\", Error: \"{1}\"",
                        ve.PropertyName, ve.ErrorMessage);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarCalle_Click(object sender, EventArgs e)
        {
            FrmNuevoEditarCalle frmNuevoEditarCalle = new FrmNuevoEditarCalle();
            frmNuevoEditarCalle.ShowDialog();
            this.CargarComboCalle(frmNuevoEditarCalle.calle.idcalle);
        }

        private void CargarComboCalle(int id)
        {
            cboCalle.DataSource = dbGimnasio.Calles.ToList();
            //campo que vera el usuario
            cboCalle.DisplayMember = "nombre_calle";

            //campo que es el valor real
            cboCalle.ValueMember = "idcalle";
            cboCalle.SelectedValue = id;
        }
    }
}
