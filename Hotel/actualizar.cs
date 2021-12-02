using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dllHotel;
namespace ExamenDatos
{
    public partial class actualizar : Form
    {
        public actualizar()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void actualizar_Load(object sender, EventArgs e)
        {
            Habitacion h = new Habitacion();
            dataGridView1.DataSource = h.Consultar();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MovimientoPrecio movimientoPrecio = new MovimientoPrecio();
            movimientoPrecio.Id = byte.Parse(lblIdHabitacion.Text);
            movimientoPrecio.Costo = int.Parse(txtCostoAc.Text);
            movimientoPrecio.CostoActualizado = int.Parse(txtCostoNew.Text);
            Habitacion habitacion = new Habitacion();
            if (movimientoPrecio.Agregar())
            {
                MessageBox.Show("Cambios efectuados con exito");
            }
            else
            {
                MessageBox.Show("Error al aplicar los cambios");
            }
        }
    }
}
