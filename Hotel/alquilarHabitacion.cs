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
    public partial class alquilarHabitacion : Form
    {
        public alquilarHabitacion()
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
            Clientes c = new Clientes();
            if (txtAM.Text != "" && txtAP.Text != "" && txtNombre.Text != "" && txtTelefono.Text != "" && txtDiasAlquiler.Text != "" )
            {
                DateTime diaDeHoy = DateTime.Today;
                movimientoHabitacion.Estatus = "Alquilada";
                movimientoHabitacion.FechaEnt = diaDeHoy.ToString("d");
                movimientoHabitacion.FechaSal = "20/02/2020";
                movimientoHabitacion.NumHabitacion = int.Parse(lblIdHabitacion.Text);
                movimientoHabitacion.Tipo = "Alquiler";

                c.Nombre = txtNombre.Text;
                c.Apemat = txtAM.Text;
                c.Apepat = txtAP.Text;
                c.Telefono = txtTelefono.Text;
                if (movimientoHabitacion.Agregar() && c.Agregar())
                {
                    MessageBox.Show("Habitación alquilada con exito");
                }
                else
                {
                    MessageBox.Show("Error al alquilar la habitación");
                }
            }
            else
            {
                MessageBox.Show("Verifique sus datos");
            }

        }
    }
}
