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
    }
}
