using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gimnasio.Reportes
{
    public partial class ReporteEjercicio : Form
    {
        GimnasioContext dbGimnasio = new GimnasioContext();
        private int idejercicio;

        public ReporteEjercicio(int idenviado)
        {
            InitializeComponent();
            this.idejercicio = idenviado;
        }

        private void ReporteEjercicio_Load(object sender, EventArgs e)
        {
            var listaEjercicios = from ej in dbGimnasio.Ejercicios
                                  join r in dbGimnasio.Rutinas on ej.idejercicio equals r.Ejercicio.idejercicio
                                  where ej.idejercicio == this.idejercicio
                                  select new
                                  {
                                      idejercicio = ej.idejercicio,
                                      nombre = ej.nombre,
                                      imagen = ej.imagen,
                                      idrutina = r.idrutina,
                                      fechaDesde = r.fechaDesde,
                                      fechaHasta = r.fechaHasta,
                                      serie = r.serie,
                                      repeticion = r.repeticion,
                                      tiempoduracion = r.tiempoduracion,
                                      descanso = r.descanso,
                                      pesokg = r.pesokg,
                                      Cardio  = r.Cardio.Duracion + " " + r.Cardio.ritmo,
                                      Calentamiento = r.Calentamiento.duracion + " " + r.Calentamiento.descripcion
                                  };
            EjercicioBindingSource.DataSource = listaEjercicios.ToList();
            RutinaBindingSource.DataSource = listaEjercicios.ToList();
            this.reportViewer1.RefreshReport();
        }
    }
}
