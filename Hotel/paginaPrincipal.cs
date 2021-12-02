using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using dllHotel;

namespace ExamenDatos
{
    public partial class paginaPrincipal : Form
    {
        public paginaPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nuevoUsuario nuevoUser = new nuevoUsuario();
            nuevoUser.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            alquilarHabitacion alquilar = new alquilarHabitacion();
            alquilar.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            actualizar actualizar = new actualizar();
            actualizar.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            retirar retirar = new retirar();
            retirar.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            graficas graficas = new graficas();
            graficas.Show();
        }

        private void paginaPrincipal_Load(object sender, EventArgs e)
        {
            Habitacion h = new Habitacion();
            dataGridView1.DataSource = h.Consultar();
            Thread thread = new Thread(tablas);
            thread.Start();
        }
        public void tablas()
        {
            Habitacion h = new Habitacion();
            Clientes c = new Clientes();
            MovimientoHabitacion mH = new MovimientoHabitacion();
            MovimientoPrecio mp = new MovimientoPrecio();
            while (true)
            {
                dataGridView2.DataSource = h.Consultar();
                Thread.Sleep(1000);
                dataGridView2.DataSource = c.Consultar();
                Thread.Sleep(1000);
                dataGridView2.DataSource = mH.Consultar();
                Thread.Sleep(1000);
                dataGridView2.DataSource = mp.Consultar();
                Thread.Sleep(1000);
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            txtEstatus.Text = dataGridView1[4, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            txtTipo.Text = dataGridView1[3, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            txtPrecio.Text = dataGridView1[5, dataGridView1.CurrentCell.RowIndex].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            actualizarHabitacion actualizarHabitacion = new actualizarHabitacion();
            actualizarHabitacion.ShowDialog();
        }
    }
}
