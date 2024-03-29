﻿using Datos;
using System;
using System.Collections;
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
    public partial class FrmNuevoEditarTelefono : Form
    {
        GimnasioContext dbGimnasio;
        Telefono telefono;

        internal static int idtelefono { get; set; }
        internal static int idtipotelefono { get; set; }
        internal static string numero { get; set; }

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
            cargarComboTipoTelefono(telefono.idtipotelefono);
            txtNumeroTelefono.Text = telefono.numero;
            cargarComboTipoTelefono(telefono.idtelefono);
        }

        private void cargarComboTipoTelefono(int idtipoTelefono)
        {
            cboTipoTelefono.DataSource = dbGimnasio.Tipos_Telefonos.ToList();

            //campo que vera el usuario
            cboTipoTelefono.DisplayMember = "tipo_telefono";

            //campo que es el valor real
            cboTipoTelefono.ValueMember = "idtipotelefono";
            cboTipoTelefono.SelectedValue = idtipoTelefono;


            //***********PREPARAMOS EL AUTOCOMPLETADO DEL COMBO
            AutoCompleteStringCollection autoCompletadoCbo = new AutoCompleteStringCollection();
            //recorremos el datatable y vamos llenando el autoCompletado
            foreach (Tipo_Telefono tipo_Telefono in dbGimnasio.Tipos_Telefonos)
            {
                autoCompletadoCbo.Add(tipo_Telefono.tipo_telefono);
            }
            //configuramos el combo para que utilice el autoCompletado
            cboTipoTelefono.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboTipoTelefono.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboTipoTelefono.AutoCompleteCustomSource = autoCompletadoCbo;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (telefono.idtelefono > 0)
            {
                try
                {
                    telefono.numero = txtNumeroTelefono.Text;

                    dbGimnasio.Entry(telefono).State = EntityState.Modified;
                    dbGimnasio.SaveChanges();

                    MessageBox.Show("Se ha modificado correctamente.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (DbEntityValidationException ex) //<-- Sí ocurre alguna excepción al guardar 
                {
                    this.ValidateCatch(ex);
                    throw;
                }
            }
            else
            {
                if (cboTipoTelefono.SelectedIndex != -1 && !string.IsNullOrEmpty(txtNumeroTelefono.Text))
                {
                    idtipotelefono = (int)cboTipoTelefono.SelectedValue;
                    numero = txtNumeroTelefono.Text;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ambos campos son requeridos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            
        }

        private void ValidateCatch(DbEntityValidationException ex)
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

        private void btnNuevoTipo_Click(object sender, EventArgs e)
        {
            FrmNuevoEditarTipoTelefono frmNuevoEditarTipoTelefono = new FrmNuevoEditarTipoTelefono();
            frmNuevoEditarTipoTelefono.ShowDialog();
            cargarComboTipoTelefono(frmNuevoEditarTipoTelefono.tipo_Telefono.idtipotelefono);
        }
    }
}
