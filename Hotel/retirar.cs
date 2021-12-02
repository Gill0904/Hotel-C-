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
    public partial class retirar : Form
    {
        public retirar()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MovimientoHabitacion movimientoHabitacion = new MovimientoHabitacion();
            movimientoHabitacion.Estatus = "Disponible";
            movimientoHabitacion.FechaEnt = "2020/02/18";
            movimientoHabitacion.FechaSal = "2020/02/20";
            movimientoHabitacion.NumHabitacion = int.Parse(lblIdHabitacion.Text);
            movimientoHabitacion.Tipo = "Alquiler";

            if (movimientoHabitacion.Agregar())
            {
                MessageBox.Show("Habitación entregada con exito");
            }
            else
            {
                MessageBox.Show("Error al desocupar la habitación");
            }
        }
    }
}
