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
    public partial class PaginaPrincipal : Form
    {
        public PaginaPrincipal()
        {
            InitializeComponent();
        }


        

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnrestaurar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnmaximizar_Click(object sender, EventArgs e)
        {

        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estas seguro de cerrar el programa?", "¡Alerta!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void AbrirFormularios<FormularioAbrir>() where FormularioAbrir:Form, new()
        {
            Form Formularios;

            Formularios = pncontenedor.Controls.OfType<FormularioAbrir>().FirstOrDefault();

            if (Formularios == null)
            {
                Formularios = new FormularioAbrir
                {
                    TopLevel = false,
                    Dock = DockStyle.Fill
                };

                pncontenedor.Controls.Add(Formularios);
                pncontenedor.Tag = Formularios;
                Formularios.Show();
                Formularios.BringToFront();

            }
            else
            {
                Formularios.BringToFront();
            }

        }

        private void btnunidadestransporte_Click(object sender, EventArgs e)
        {
            AbrirFormularios<UnidadesTransporte>();
        }

        private void btnmienbros_Click(object sender, EventArgs e)
        {
            
        }

        private void btncultivos_Click(object sender, EventArgs e)
        {
            AbrirFormularios<Cultivos>();
        }
    }
}
