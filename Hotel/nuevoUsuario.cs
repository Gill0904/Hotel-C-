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
    public partial class nuevoUsuario : Form
    {
        public nuevoUsuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuarios usuarios = new Usuarios();
            if (txtContrasena.Text != "" && txtNombre.Text != "" && txtRol.Text != "" )
            {
                usuarios.Nombre = txtNombre.Text;
                usuarios.Contrasena = txtContrasena.Text;
                usuarios.Rol = txtRol.Text;
                if (usuarios.Agregar())
                {
                    MessageBox.Show("Usuario agregado con exito");
                }
                else
                {
                    MessageBox.Show("Error al agregar el usuario");
                }
            }
            else
            {
                MessageBox.Show("Verifique sus datos");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
