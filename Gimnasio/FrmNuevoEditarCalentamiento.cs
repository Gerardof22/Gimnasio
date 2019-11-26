using Datos;
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
    public partial class FrmNuevoEditarCalentamiento : Form
    {
        GimnasioContext dbGimnasio;
        public Calentamiento calentamiento;

        public FrmNuevoEditarCalentamiento()
        {
            InitializeComponent();
            dbGimnasio = new GimnasioContext();
            calentamiento = new Calentamiento();
        }

        public FrmNuevoEditarCalentamiento(GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            calentamiento = new Calentamiento();
            cargarCalentamiento(0);
        }

        public FrmNuevoEditarCalentamiento(int idSeleccionado, GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            calentamiento = new Calentamiento();
            cargarCalentamiento(idSeleccionado);
        }

        private void cargarCalentamiento(int idSeleccionado)
        {
            calentamiento = dbGimnasio.Calentamientos.Find(idSeleccionado);
            txtDuracion.Text = calentamiento.calentamiento_duracion;
            txtDescripcion.Text = calentamiento.calentamiento_descripcion;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                calentamiento.calentamiento_duracion = txtDuracion.Text;
                calentamiento.calentamiento_descripcion = txtDescripcion.Text;

                if (calentamiento.calentamiento_idcalentamiento > 0)
                {
                    dbGimnasio.Entry(calentamiento).State = EntityState.Modified;
                    MessageBox.Show("Se ha modificado correctamente.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dbGimnasio.Calentamientos.Add(calentamiento);
                    MessageBox.Show("Se ha guardado correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
