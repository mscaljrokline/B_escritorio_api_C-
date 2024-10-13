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

namespace BCP_AMHCH
{
    public partial class Form1 : Form
    {
        private Form anterior = null;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(); // Instancia de Formulario1
            LoadFormInPanel(form2); // Llama al método para cargarlo
        }


        private void LoadFormInPanel(Form form)
        {
            // Cierra el formulario actual, si existe
            if (anterior != null)
            {
                anterior.Close();
            }

            // Configura el nuevo formulario a cargar
            anterior = form; // Guarda el nuevo formulario en la variable
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panel1.Controls.Add(form);
            form.Show();

        }



        private void adicionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(); // Instancia de Formulario1
            LoadFormInPanel(form2); // Llama al método para cargarlo
        }

        private void abonoRetiroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(); // Instancia de Formulario1
            LoadFormInPanel(form3); // Llama al método para cargarlo
        }

        private void transferenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6(); // Instancia de Formulario1
            LoadFormInPanel(form6); // Llama al método para cargarlo
        }

        private void saldosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7(); // Instancia de Formulario1
            LoadFormInPanel(form7); // Llama al método para cargarlo
        }
    }
}
