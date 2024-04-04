using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ParcialAngelOvalle
{
    public partial class Form1 : Form
    {
        Inscripciones inscripcion = new Inscripciones();
        List<Alumnos> alumnos = new List<Alumnos>();
        List<Talleres> talleres = new List<Talleres>();
        List<Inscripciones> inscripciones = new List<Inscripciones>();
        List<Reporte> reportes = new List<Reporte>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string fileName = "Alumnos.txt";
            string fileName2 = "Talleres.txt";

            FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Alumnos alumno = new Alumnos();
                alumno.Dpi = Convert.ToInt16(reader.ReadLine());
                alumno.Nombre = reader.ReadLine();
                alumno.Direccion = reader.ReadLine();

                alumnos.Add(alumno);
            }

            reader.Close();

            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Dpi";
            comboBox1.DataSource = alumnos;
            comboBox1.Refresh();

            

            FileStream stream2 = new FileStream(fileName2, FileMode.Open, FileAccess.Read);
            StreamReader reader2 = new StreamReader(stream2);

            while (reader2.Peek() > -1)
            {
                Talleres taller = new Talleres();
                taller.Codigo = Convert.ToInt16(reader2.ReadLine());
                taller.NombreTaller = reader2.ReadLine();
                taller.Costo = Convert.ToDecimal(reader2.ReadLine());

                talleres.Add(taller);
            }

            reader2.Close();

            comboBox2.DisplayMember = "NombreTaller";
            comboBox2.ValueMember = "Codigo";
            comboBox2.DataSource = talleres;
            comboBox2.Refresh();
        }
        private void GuardarInscripciones()
        {

            FileStream stream = new FileStream("Inscripciones.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            foreach (var inscripcion in inscripciones)
            {
                writer.WriteLine(inscripcion.Dni);
                writer.WriteLine(inscripcion.Code);
                writer.WriteLine(inscripcion.Fecha);
            }

            writer.Close();
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            inscripcion.Dni = Convert.ToInt32(comboBox1.SelectedValue);
            inscripcion.Code = Convert.ToInt16(comboBox2.SelectedValue);
            inscripcion.Fecha = DateTime.UtcNow;

            inscripciones.Add(inscripcion);


            GuardarInscripciones();
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            foreach (var alumno in alumnos)
            {
                foreach (var taller in talleres)
                {


                    foreach (var inscripcion in inscripciones)
                    {
                        if (alumno.Dpi == inscripcion.Dni)
                        {
                            Reporte reporte = new Reporte();
                            reporte.Name = alumno.Nombre;
                            reporte.Workshop = taller.NombreTaller;
                            reporte.Date = inscripcion.Fecha;

                            reportes.Add(reporte);

                        }
                    }
                }

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = reportes;
                dataGridView1.Refresh();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            reportes = reportes.OrderBy(p => p.Workshop).ToList();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = reportes;
            dataGridView1.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int Cuenta = reportes.Count();
            label2.Text = Cuenta.ToString();
            label1.Visible = true;
            label2.Visible = true;
            
        }
    }
}
