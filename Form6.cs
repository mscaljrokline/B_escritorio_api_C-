using BCP_AMHCH.Controlador;
using BCP_AMHCH.Modelo;
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
    public partial class Form6 : Form
    {
        RepositoryCuenta rep = new RepositoryCuenta();
        public Form6()
        {
            InitializeComponent();
            // Suscribirse al evento Paint del formulario
            this.Paint += new PaintEventHandler(Form1_Paint);
            var list = rep.ObtenerCuentas<Cuenta>();
            asignar(comboBox1, list);
            asignar(comboBox2, list);
            //comboBox1.SelectedIndex = 1;
            comboBox1.SelectedIndex = 1;
            comboBox1.SelectedIndex = 0;
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Llama al método estático para dibujar el borde
            BorderUtils.DrawBorder(this, e, 5, Color.Orange);
            BorderUtils.DrawLine(this, e, Color.Black, 20, 40, 41);
            BorderUtils.DrawLine(this, e, Color.Black, 20, 40, 123);
        }
        public void asignar(ComboBox comb, IEnumerable<Cuenta> list)
        {
            comb.DataSource = list.ToList(); // Convertir a lista si es necesario
            // Configura qué propiedad del objeto 'Cuenta' se mostrará y cuál será el valor
            comb.DisplayMember = "NRO_CUENTA2";  // Nombre de la cuenta a mostrar
            comb.ValueMember = "NRO_CUENTA";
        }
        /*
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        */
       
        
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string combo = comboBox1.SelectedValue.ToString();
            //MessageBox.Show(combo);
            //if (!combo.StartsWith("BCP"))
            //{
                //MessageBox.Show(combo);
                textBox1.Text=RepositoryCuenta.obtener_saldo(combo);
            //}
            
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(comboBox2.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CuentaController.dep_ret(comboBox1.SelectedValue.ToString(), textBox2.Text, 2))
            {
                if (CuentaController.dep_ret(comboBox2.SelectedValue.ToString(), textBox2.Text, 1))
                {

                    textBox1.Text = (Convert.ToDouble(textBox1.Text)- Convert.ToDouble(textBox2.Text)).ToString();
                    textBox2.Text = "";
                    MessageBox.Show("Transferencia procesada correctamente");

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }
    }
}
