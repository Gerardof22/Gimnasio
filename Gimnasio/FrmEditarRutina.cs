using Datos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class FrmEditarRutina : Form
    {
        GimnasioContext dbGimnasio;

        Rutina rutina;
        Cardio cardio;
        Calentamiento calentamiento;
        Ejercicio ejercicio;
        Tipo_Rutina tipo_Rutina;

        public FrmEditarRutina()
        {
            InitializeComponent();
            dbGimnasio = new GimnasioContext();
            rutina = new Rutina();
        }

        public FrmEditarRutina(GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            rutina = new Rutina();
        }

        public FrmEditarRutina(int idSeleccionado, GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            rutina = new Rutina();
            cardio = new Cardio();
            calentamiento = new Calentamiento();
            ejercicio = new Ejercicio();
            tipo_Rutina = new Tipo_Rutina();
            cargarRutina(idSeleccionado);
        }

        private void cargarRutina(int idSeleccionado)
        {
            rutina = dbGimnasio.Rutinas.Find(idSeleccionado);
            dtpFechaDesde.Value              = rutina.fechaDesde;
            dtpFechaHasta.Value              = rutina.fechaHasta;
            txtSeries.Text                   = rutina.serie.ToString();
            txtRepeticiones.Text             = rutina.repeticion.ToString();
            txtTiempoDuracion.Text           = rutina.tiempoduracion;
            txtDescanso.Text                 = rutina.descanso;
            txtKg.Text                       = rutina.pesokg.ToString();
            this.ValidarCardio();
            this.ValidarCalentamiento();
            
        }


        /// <summary>
        /// Validamos si los campos son null no cargamos nada.
        /// NOTA: ? nos permite validar un objeto null y compararlo, en caso contrario la expresion siempre será true dentro del
        /// if.
        /// </summary>
        private void ValidarCardio()
        {
            if (rutina.Cardio?.idcardio != null)
            {
                rutina.Cardio = dbGimnasio.Cardios.Find(rutina.Cardio.idcardio);
            }
            if (!string.IsNullOrEmpty(rutina.Cardio?.Duracion.ToString()))
            {
                txtDuracionCardio.Text = rutina.Cardio.Duracion.ToString();
            }
            if (!string.IsNullOrEmpty(rutina.Cardio?.ritmo))
            {
                txtRitmoCardio.Text = rutina.Cardio.ritmo;
            }
        }

        /// <summary>
        /// Validamos si los campos son null no cargamos nada.
        /// 
        /// NOTA: ? nos permite validar un objeto null y compararlo, en caso contrario la expresion siempre será true dentro del
        /// if.
        /// </summary>
        private void ValidarCalentamiento()
        {
            if (rutina.Calentamiento?.idcalentamiento != null)
            {
                rutina.Calentamiento = dbGimnasio.Calentamientos.Find(rutina.Calentamiento.idcalentamiento);
            }

            if (rutina.Calentamiento?.duracion != null)
            {
                txtDuracionCalentamiento.Text = rutina.Calentamiento.duracion;
            }

            if (rutina.Calentamiento?.descripcion != null)
            {
                txtDescripcionCalentamiento.Text = rutina.Calentamiento.descripcion;
            }
        }

        private void btnAgregarCardio_Click(object sender, EventArgs e)
        {
            FrmGestionCardio frmGestionCardio = new FrmGestionCardio();
            frmGestionCardio.ShowDialog();

            if (!string.IsNullOrEmpty(FrmGestionCardio.duracion) && !string.IsNullOrEmpty(FrmGestionCardio.ritmo))
            {
                txtDuracionCardio.Text = FrmGestionCardio.duracion;
                txtRitmoCardio.Text = FrmGestionCardio.ritmo;
            }

        }

        private void btnAgregarCalentamiento_Click(object sender, EventArgs e)
        {
            FrmGestionCaletamiento frmGestionCaletamiento = new FrmGestionCaletamiento();
            frmGestionCaletamiento.ShowDialog();
            if (FrmGestionCaletamiento.duracion != "")
            {
                txtDuracionCalentamiento.Text = FrmGestionCaletamiento.duracion;
                txtDescripcionCalentamiento.Text = FrmGestionCaletamiento.descripcion;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                rutina.fechaDesde = dtpFechaDesde.Value;
                rutina.fechaHasta = dtpFechaHasta.Value;
                rutina.serie = int.Parse(txtSeries.Text);
                rutina.repeticion = int.Parse(txtRepeticiones.Text);
                rutina.tiempoduracion = txtTiempoDuracion.Text;
                rutina.descanso = txtDescanso.Text;
                rutina.pesokg = float.Parse(txtKg.Text);
                this.validarRelacionesTablas();

                if (rutina.idrutina > 0)
                {
                    dbGimnasio.Entry(rutina).State = EntityState.Modified;
                    MessageBox.Show("Se ha modificado correctamente.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dbGimnasio.SaveChanges();
                this.Close();
            }
            catch (DbEntityValidationException ex) //<-- Sí ocurre alguna excepción al guardar 
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

        private void validarRelacionesTablas()
        {
            if (dbGimnasio.Cardios.Find(FrmGestionCardio.idcardio) != null)
            {
                rutina.Cardio = dbGimnasio.Cardios.Find(FrmGestionCardio.idcardio);
            }
            if (dbGimnasio.Calentamientos.Find(FrmGestionCaletamiento.idcalentamiento) != null)
            {
                rutina.Calentamiento = dbGimnasio.Calentamientos.Find(FrmGestionCaletamiento.idcalentamiento);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
