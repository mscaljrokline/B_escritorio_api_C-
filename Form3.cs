using BCP_AMHCH.Controlador;
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
    public partial class Form3 : Form
    {
        RepositoryCuenta rep = new RepositoryCuenta();
        public Form3()
        {
            InitializeComponent();

            // Suscribirse al evento Paint del formulario
            this.Paint += new PaintEventHandler(Form1_Paint);
        }

        // Manejar el evento Paint
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Llama al método estático para dibujar el borde
            BorderUtils.DrawBorder(this, e, 5, Color.Orange);
            BorderUtils.DrawLine(this, e, Color.Black, 20,40,45);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CuentaController.dep_ret(comboBox1.SelectedValue.ToString(), textBox1.Text, 1))
            {
                MessageBox.Show("Deposito correcto");
                textBox1.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (CuentaController.dep_ret(comboBox1.SelectedValue.ToString(), textBox1.Text, 2))
            {
                MessageBox.Show("Retiro correcto");
                textBox1.Text = "";
            }
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            var list = rep.ObtenerCuentas<Cuenta>();
            comboBox1.DataSource = list.ToList(); // Convertir a lista si es necesario
            // Configura qué propiedad del objeto 'Cuenta' se mostrará y cuál será el valor
            comboBox1.DisplayMember = "NRO_CUENTA2";  // Nombre de la cuenta a mostrar
            comboBox1.ValueMember = "NRO_CUENTA";
            
        }

    }
}
