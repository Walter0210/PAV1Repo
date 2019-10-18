using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_PAV_3k2.Clases;
using TP_PAV_3k2.Repositorios;

namespace TP_PAV_3k2.Formularios
{
    public partial class Parcial : Form
    {
        RepositorioAlumnos repositorioAlumnos;
        RepositorioCursos repositorioCursos;
        public Parcial()
        {
            InitializeComponent();
            repositorioAlumnos= new RepositorioAlumnos();
            repositorioCursos = new RepositorioCursos();
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            var confirmacion = MessageBox.Show($"¿Esta seguro que desea salir? ",
                    "¿Desea salir?",
                    MessageBoxButtons.YesNo);
            if (confirmacion.Equals(DialogResult.No))
                return;
            this.Close();
        }

        private void Parcial_Load(object sender, EventArgs e)
        {
            dtpFecha.MaxDate = DateTime.Today;
            DataTable Cursos; 
            Cursos = repositorioCursos.ObtenerCursos();
            
            
            cmbCurso.DataSource = Cursos;

            

            cmbCurso.ValueMember = "ID";
            cmbCurso.DisplayMember = "NOMBRE";
            cmbCurso.SelectedIndex = 0;

           

            

            cargarAlumnos();
        }

        public void cargarAlumnos()
        {
            cmbAlumno.SelectedValue = -1;   
            var alumnos = new List<Alumno>();
            alumnos = repositorioAlumnos.ObtenerAlumnosconidCurso(cmbCurso.SelectedValue.ToString());
            
            cmbAlumno.ValueMember = "id";
            cmbAlumno.DisplayMember = "NombreCompleto";
            cmbAlumno.DataSource = alumnos;

        }

        private void cmbCurso_SelectedValueChanged(object sender, EventArgs e)
        {
            

        }

        private void cmbCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cargarAlumnos();
        }

        private void cmbCurso_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void cmbCurso_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbCurso_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cargarAlumnos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            cmbCurso.SelectedIndex = 0;
            txtFacturaNro.Text = "";
            txtMonto.Text = "";
            cargarAlumnos();
            txtFacturaNro.Focus();

        }

        private void txtFacturaNro_KeyUp(object sender, KeyEventArgs e)
        {
            double defaul;
            if (double.TryParse(txtFacturaNro.Text, out defaul))
            {
                txtFacturaNro.Text = txtFacturaNro.Text;
            }
            else
            {
                txtFacturaNro.Text = "";
                txtFacturaNro.Focus();
                return;
            }
        }

        private void txtMonto_KeyUp(object sender, KeyEventArgs e)
        {
            double defaul;
            if (double.TryParse(txtMonto.Text, out defaul))
            {
                if(double.Parse(txtMonto.Text)<=0)
                {
                    txtMonto.Text = "";
                    txtMonto.Focus();
                    return;
                }
                txtMonto.Text = txtMonto.Text;
            }
            else
            {
                txtMonto.Text = "";
                txtMonto.Focus();
                return;
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        
        private void btnAgregarLista_Click(object sender, EventArgs e)
        {
            string nombre;
            string apellido;
            if (txtFacturaNro.Text == "")
            {
                MessageBox.Show("ingrese factura");
                txtFacturaNro.Focus();
                return;
            }

            if(txtMonto.Text=="")
            {
                MessageBox.Show("ingrese monto");
                txtMonto.Focus();
                return;
            }
            var alumnoNombre = repositorioAlumnos.getNombre(cmbAlumno.SelectedValue.ToString()).Rows;
            var alumnoApellido = repositorioAlumnos.getApellido(cmbAlumno.SelectedValue.ToString()).Rows;

            foreach (DataRow registro in alumnoNombre)
            {
                if (registro.HasErrors)
                    continue; // no corto el ciclo
                nombre = registro.ItemArray[0].ToString();       
                

                
            }
            foreach (DataRow registro in alumnoApellido)
            {
                if (registro.HasErrors)
                    continue; // no corto el ciclo
                apellido = registro.ItemArray[0].ToString();



            }
            var alumnos = repositorioAlumnos.ObtenerAlumnosconidCurso(cmbCurso.SelectedValue.ToString());
            var fila = new string[]
            {
                cmbCurso.SelectedValue.ToString(),
                cmbAlumno.SelectedValue.ToString(),
                cmbCurso.Text,
                nombre,
                apellido,

                

            };
            dgvPagos.Rows.Clear();
            DataTable pagos;
            //var TiposCombustible = _repositorioTipoCombustible.ObtenerTiposCombustible().Rows;
            ActualizarGrilla(pagos);

        }
        private void ActualizarGrilla(DataRowCollection registros)
        {
            foreach (DataRow registro in registros)
            {
                if (registro.HasErrors)
                    continue; // no corto el ciclo
                var fila = new string[] {
                    registro.ItemArray[0].ToString(), // Codigo
                    registro.ItemArray[1].ToString(), // Nombre
                    
                };

                dgvPagos.Rows.Add(fila);
            }
        }
    }
}
