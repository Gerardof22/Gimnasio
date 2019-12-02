using System;
using Datos;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity.Validation;
using System.Data.Entity;

namespace Gimnasio
{
    public partial class FrmNuevoTipoCalentamiento : Form
    {
        GimnasioContext dbGimnasio;
        Tipo_Calentamiento tipo_Calentamiento;

        internal static string nombre_tipo_calentamiento;

        public FrmNuevoTipoCalentamiento()
        {
            InitializeComponent();
            dbGimnasio = new GimnasioContext();
            tipo_Calentamiento = new Tipo_Calentamiento();
        }

        public FrmNuevoTipoCalentamiento(GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            tipo_Calentamiento = new Tipo_Calentamiento();
        }

        public FrmNuevoTipoCalentamiento(int idSeleccionado, GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            tipo_Calentamiento = new Tipo_Calentamiento();
            this.CargarTipoCalentamiento(idSeleccionado);
        }

        private void CargarTipoCalentamiento(int idSeleccionado)
        {
            tipo_Calentamiento = dbGimnasio.Tipos_Calentamientos.Find(idSeleccionado);
            txtTipoCalentamiento.Text = tipo_Calentamiento.nombre;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                

                if (tipo_Calentamiento.idtipocalentamiento > 0)
                {
                    tipo_Calentamiento.nombre = txtTipoCalentamiento.Text;

                    dbGimnasio.Entry(tipo_Calentamiento).State = EntityState.Modified;

                    MessageBox.Show("Se ha modificado correctamente.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dbGimnasio.SaveChanges();
                    this.Close();
                }
                else
                {
                    nombre_tipo_calentamiento = txtTipoCalentamiento.Text;

                    dbGimnasio.Tipos_Calentamientos.Add(tipo_Calentamiento);
                    this.Close();
                }

                
            }
            catch (DbEntityValidationException ex)
            {
                this.ValidateCatch(ex);
                throw;
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
    }
}
