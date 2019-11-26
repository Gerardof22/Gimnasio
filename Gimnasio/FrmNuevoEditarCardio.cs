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
            numDuracion.Value = (decimal)cardio.cardio_duracion;
            txtRitmo.Text = cardio.cardio_ritmo;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                cardio.cardio_duracion = (float)numDuracion.Value;
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
