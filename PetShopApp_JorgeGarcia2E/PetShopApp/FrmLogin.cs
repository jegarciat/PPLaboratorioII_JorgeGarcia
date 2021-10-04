using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using System.Media;

namespace PetShopApp
{
    public partial class FrmLogin : Form
    {
        SoundPlayer sonido;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (PetShop.Loguearse(this.txtUser.Text, this.txtClave.Text))
            {
                FrmMenuPrincipal home = new FrmMenuPrincipal(PetShop.BuscarUsuario(this.txtUser.Text));
                sonido = new SoundPlayer(@"C:\Users\jorge\source\1erParcial\PetShopApp_JorgeGarcia2E\Sonidos\InicioExitoso.wav");
                sonido.Play();

                this.Hide();

                if (home.ShowDialog() == DialogResult.Yes)
                {
                    this.Show();
                }
            }
            else
            {
                this.txtUser.Clear();
                this.txtClave.Clear();
                this.txtUser.PlaceholderText = "Usuario o contraseña incorrecta";
                this.txtClave.PlaceholderText = "Vuelva a intentarlo";
            }
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            this.txtUser.Text = "admin";
            this.txtClave.Text = "admin1";
        }

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            this.txtUser.Text = "maria";
            this.txtClave.Text = "tomate34";
        }
    }
}
