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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuarios u = new Usuarios();
            u.Nombre = txtNombre.Text;
            u.Contrasena = txtContrasena.Text;
            try
            {
                if (u.login())
                {
                    paginaPrincipal inicio = new paginaPrincipal();
                    inicio.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Datos Incorrectos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
            
        }
    }
}
