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
            if (telefono.telefono_idtelefono > 0)
            {
                try
                {
                    telefono.telefono_numero = txtNumeroTelefono.Text;

                    dbGimnasio.Entry(telefono).State = EntityState.Modified;

                    MessageBox.Show("Se ha modificado correctamente.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dbGimnasio.SaveChanges();
                    this.Close();
                }
                catch (DbEntityValidationException ex) //<-- Sí ocurre alguna excepción al guardar 
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
                    throw;
                }
            }
            else
            {
                idtipotelefono = (int)cboTipoTelefono.SelectedValue;
                numero = txtNumeroTelefono.Text;
                this.Close();
            }

            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
