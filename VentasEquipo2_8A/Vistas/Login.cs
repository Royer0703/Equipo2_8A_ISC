using Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vistas
{
    public partial class Login : Form
    {

        ConexionSQLN cn = new ConexionSQLN();
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator2_Load(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void botonIngresar_Click(object sender, EventArgs e)
        {
            if (cn.conSQL(textUsuario.Text, textContra.Text) == 1)
            {
                MessageBox.Show("Usuario encontrado", "Informacion!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();

                menu v = new menu();
                v.Show();
            }
            else
            {
                MessageBox.Show("Usiario no encontrdao", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
