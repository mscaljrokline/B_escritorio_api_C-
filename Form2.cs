using BCP_AMHCH.Modelo;
using BCP_AMHCH.Vista;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BCP_AMHCH.Vista.Borde;

namespace BCP_AMHCH
{
    public partial class Form2 : Form
    {
        RepositoryCuenta rep=new RepositoryCuenta();
        Cuenta cuenta = new Cuenta();
        public Form2()
        {
            InitializeComponent();

            // Suscribirse al evento Paint del formulario
            this.Paint += new PaintEventHandler(Form1_Paint);
            this.Shown += new System.EventHandler(this.Form2_Shown);


        }
        // Manejar el evento Paint
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Llama al método estático para dibujar el borde
            BorderUtils.DrawBorder(this, e, 5, Color.Orange);
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Fuente de datos para el ComboBox
            comboBox1.DataSource = new List<KeyValuePair<string, string>>()
    {
        new KeyValuePair<string, string>("USD", "Dolares"),
        new KeyValuePair<string, string>("BOL", "Bolivianos")
    };

            // Propiedad que muestra en la lista
            comboBox1.DisplayMember = "Value";  // Lo que ves en el ComboBox (Ej. "Dólar Estadounidense")

            // Propiedad interna que representa el valor
            comboBox1.ValueMember = "Key";
            // Establecer el valor seleccionado por defecto (Ejemplo: "EUR")

            // Asociar el modelo Cuenta a los controles de la vista
            textBox1.DataBindings.Add("Text", cuenta, "NRO_CUENTA");
            comboBox1.DataBindings.Add("SelectedValue", cuenta, "MONEDA", true, DataSourceUpdateMode.OnPropertyChanged);
            textBox2.DataBindings.Add("Text", cuenta, "NOMBRE");
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 1;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string val = "";
            if(textBox1.TextLength < 13)
            {
                val += "Falta caracteres en el NRO_CUENTA. ";
            }
            if (textBox2.TextLength==0)
            {
                val += "No lleno NOMBRE. ";
            }
            if(val.Length == 0)
            {
                rep.AgregarCuenta(cuenta);
            }
            else
            {
                MessageBox.Show(val);
            }
        }
    }
}
