using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamenDatos
{
    public partial class actualizarHabitacion : Form
    {
        public actualizarHabitacion()
        {
            InitializeComponent();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            txtEstatus.Text = dataGridView1[4, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            txtNuevaHabitacion.Text = dataGridView1[2, dataGridView1.CurrentCell.RowIndex].Value.ToString();
        }
    }
}
