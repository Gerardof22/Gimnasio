using Datos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gimnasio
{
    public partial class FrmNuevoEditarRutina : Form
    {
        GimnasioContext dbGimnasio;
        Rutina rutina;
        Tipo_Rutina tipo_Rutina;

        public FrmNuevoEditarRutina()
        {
            InitializeComponent();
            dbGimnasio = new GimnasioContext();
            rutina = new Rutina();
        }

        public FrmNuevoEditarRutina(GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            rutina = new Rutina();
            cargarRutina(0);
        }

        public FrmNuevoEditarRutina(int idSeleccionado, GimnasioContext dbEnviado)
        {
            InitializeComponent();
            dbGimnasio = dbEnviado;
            rutina = new Rutina();
            cargarRutina(idSeleccionado);
        }

        private void cargarRutina(int idSeleccionado)
        {
            rutina = dbGimnasio.Rutinas.Find(idSeleccionado);
            dtpFechaDesde.Value              = rutina.rutina_fechaDesde;
            dtpFechaHasta.Value              = rutina.rutina_fechaHasta;
            txtSeries.Text                   = rutina.rutina_serie.ToString();
            txtRepeticiones.Text             = rutina.rutina_repeticion.ToString();
            txtTiempoDuracion.Text           = rutina.rutina_tiempoduracion;
            txtDescanso.Text                 = rutina.rutina_descanso;
            txtKg.Text                       = rutina.rutina_pesokg.ToString();
            rutina.Cardio                    = dbGimnasio.Cardios.Find(rutina.Cardio.cardio_idcardio);
            txtDuracionCardio.Text           = rutina.Cardio.cardio_duracion.ToString();
            txtRitmoCardio.Text              = rutina.Cardio.cardio_ritmo;
            rutina.Calentamiento             = dbGimnasio.Calentamientos.Find(rutina.Calentamiento.calentamiento_idcalentamiento);
            txtDuracionCalentamiento.Text    = rutina.Calentamiento.calentamiento_duracion;
            txtDescripcionCalentamiento.Text = rutina.Calentamiento.calentamiento_descripcion;
        }

        private void btnAgregarCardio_Click(object sender, EventArgs e)
        {
            FrmGestionCardio frmGestionCardio = new FrmGestionCardio();
            frmGestionCardio.ShowDialog();

            txtDuracionCardio.Text = FrmGestionCardio.duracion.ToString();
            txtRitmoCardio.Text = FrmGestionCardio.ritmo;
        }

        private void btnAgregarCalentamiento_Click(object sender, EventArgs e)
        {
            FrmGestionCaletamiento frmGestionCaletamiento = new FrmGestionCaletamiento();
            frmGestionCaletamiento.ShowDialog();

            txtDuracionCalentamiento.Text = FrmGestionCaletamiento.duracion;
            txtDescripcionCalentamiento.Text = FrmGestionCaletamiento.descripcion;
        }

        private void btnAgregarTipoRutina_Click(object sender, EventArgs e)
        {
            FrmNuevoEditarTipoRutina frmNuevoEditarTipoRutina = new FrmNuevoEditarTipoRutina();
            frmNuevoEditarTipoRutina.ShowDialog();
            llenarGrillaTipoRutina();
            cargarGrillaTipoRutina();
        }

        private void llenarGrillaTipoRutina()
        {
            tipo_Rutina = new Tipo_Rutina();
            tipo_Rutina.tipo_rutina_nombre = FrmNuevoEditarTipoRutina.tipo_rutina_nombre;

            if (rutina.Tipos_Rutinas == null)
            {
                rutina.Tipos_Rutinas = new ObservableCollection<Tipo_Rutina>();
            }

            rutina.Tipos_Rutinas.Add(tipo_Rutina);
        }

        private void cargarGrillaTipoRutina()
        {
            if (rutina.Tipos_Rutinas != null)
            {
                var listaTipoRutina = from tipo in rutina.Tipos_Rutinas
                                      select new
                                      {
                                          idtiporutina = tipo.tipo_rutina_idtiporutina,
                                          rutina = tipo.tipo_rutina_nombre,
                                          isDelected = tipo.tipo_rutina_delete
                                      };

                gridTipoRutina.DataSource = listaTipoRutina.Where(tr => tr.isDelected == false).ToList();
            }

            
        }

        private void btnQuitarTipoRutina_Click(object sender, EventArgs e)
        {

        }
    }
}
