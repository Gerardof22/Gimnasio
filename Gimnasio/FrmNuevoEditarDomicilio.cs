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
    public partial class FrmNuevoEditarDomicilio : Form
    {
        GimnasioContext dbGimnasio;
        Domicilio domicilio;

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
            CargarComboCalle(0);
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
            txtNumeroCalle.Text = domicilio.numero.ToString();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                domicilio.Calle = (Calle)cboCalle.SelectedItem;
                if (!string.IsNullOrEmpty(txtNumeroCalle.Text))
                {
                    domicilio.numero = Convert.ToInt32(txtNumeroCalle.Text);
                }


                if (domicilio.iddomicilio > 0)
                {
                    dbGimnasio.Entry(domicilio).State = EntityState.Modified;
                    dbGimnasio.SaveChanges();
                    MessageBox.Show("Se ha modificado correctamente.", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    if (cboCalle.SelectedIndex != -1)
                    {
                        dbGimnasio.Domicilios.Add(domicilio);
                        dbGimnasio.SaveChanges();
                        MessageBox.Show("Se ha guardado correctamente.", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar una Calle.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cboCalle.Focus();
                    }
                }
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

            //***********PREPARAMOS EL AUTOCOMPLETADO DEL COMBO
            AutoCompleteStringCollection autoCompletadoCbo = new AutoCompleteStringCollection();
            //recorremos el datatable y vamos llenando el autoCompletado
            foreach (Calle calle in dbGimnasio.Calles)
            {
                autoCompletadoCbo.Add(calle.nombre_calle);
            }
            //configuramos el combo para que utilice el autoCompletado
            cboCalle.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboCalle.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cboCalle.AutoCompleteCustomSource = autoCompletadoCbo;

        }
    }
}
