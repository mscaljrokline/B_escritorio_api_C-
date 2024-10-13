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

namespace BCP_AMHCH
{
    public partial class Form7 : Form
    {
        Form8 fm;
        RepositoryCuenta rep = new RepositoryCuenta();
        CuentaController cc = new CuentaController();
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            //CuentaController.listar_cuenta(dataGridView1);
            // Obtener la lista de cuentas utilizando tu método
            //dataGridView1.ColumnCount = 5;


            var cuentas = rep.ObtenerCuentas<CuentaList>();// Convertir a lista si es necesario

            // Asignar la lista directamente al DataGridView mediante Data Binding
            dataGridView1.DataSource = cuentas;

            dataGridView1.Columns[0].Name = "Tipo";
            dataGridView1.Columns[1].Name = "Moneda";
            dataGridView1.Columns[2].Name = "Cuenta";

            dataGridView1.Columns[3].Name = "Titular";


            dataGridView1.Columns[4].Name = "Saldo";

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Movimientos";

            btn.Name = "bot_";
            btn.Text = "ver";
            btn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btn);
            //DGVDisenio.Formato(dataGridView1, 1);

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.Columns[e.ColumnIndex].Name == "bot_")
            {

                Cuenta dc = new Cuenta();
                dc.NRO_CUENTA = dataGridView1.CurrentRow.Cells["Cuenta"].Value.ToString();
                dc.TIPO = dataGridView1.CurrentRow.Cells["Tipo"].Value.ToString();
                dc.NOMBRE = dataGridView1.CurrentRow.Cells["Titular"].Value.ToString();
                dc.MONEDA = dataGridView1.CurrentRow.Cells["Moneda"].Value.ToString();
                dc.SALDO = (double)Convert.ToDecimal(dataGridView1.CurrentRow.Cells["Saldo"].Value);



                //fm = new Form8(dc);
                fm.Show();

            }
        }

    }
}
