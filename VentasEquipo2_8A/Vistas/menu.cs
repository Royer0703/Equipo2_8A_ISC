﻿using System;
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
    public partial class menu : Form
    {
        
        public menu()
        {
            InitializeComponent();
           


        }


        private const int tamañogrid = 10;
        private const int areamouse = 132;
        private const int botonizquirdo = 17;
        private Rectangle rectangulogrid;

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            var region = new Region(new Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height));
            rectangulogrid = new Rectangle(ClientRectangle.Width - tamañogrid, ClientRectangle.Height - tamañogrid, tamañogrid, tamañogrid);
            region.Exclude(rectangulogrid);
            pnprincipal.Region = region;
            Invalidate();

        }

        protected override void WndProc(ref Message sms)
        {
            switch (sms.Msg)
            {
                case areamouse:
                    base.WndProc(ref sms);

                    var RefPoint = PointToClient(new Point(sms.LParam.ToInt32() & 0xffff, sms.LParam.ToInt32() >> 16));

                    if (!rectangulogrid.Contains(RefPoint))
                    {
                        break;
                    }

                    sms.Result = new IntPtr(botonizquirdo);
                    break;
                default:
                    base.WndProc(ref sms);
                    break;
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush solidbrush = new SolidBrush(Color.FromArgb(55, 61, 69));
            e.Graphics.FillRectangle(solidbrush, rectangulogrid);
            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, rectangulogrid);
        }


        int lx, ly;

        private void btncerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estas seguro de cerrar el programa?", "¡Alerta!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnrestaurar_Click(object sender, EventArgs e)
        {
            Size = new Size(sw, sh);
            Location = new Point(lx, ly);

            btnrestaurar.Visible = false;
            btnmaximizar.Visible = true;
        }

        private void btnmaximizar_Click(object sender, EventArgs e)
        {
            lx = Location.X;
            ly = Location.Y;
            sw = Size.Width;
            sh = Size.Height;

            Size = Screen.PrimaryScreen.WorkingArea.Size;
            Location = Screen.PrimaryScreen.WorkingArea.Location;

            btnmaximizar.Visible = false;
            btnrestaurar.Visible = true;
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        int sw, sh;

        private void btnasociaciones_Click(object sender, EventArgs e)
        {
            AbrirFormularios<Asociaciones>();
        }

        private void btncultivos_Click(object sender, EventArgs e)
        {
            AbrirFormularios<Cultivos>();
        }

        private void btnmienbros_Click(object sender, EventArgs e)
        {
            AbrirFormularios<Miembros>();
        }

        private void btncliente_Click(object sender, EventArgs e)
        {
            AbrirFormularios<Clientes>();
        }

        private void btndireccionescliente_Click(object sender, EventArgs e)
        {
            AbrirFormularios<DireccionesCliente>();
        }

        private void btnparcelas_Click(object sender, EventArgs e)
        {
            AbrirFormularios<Parcelas>();
        }

        private void panelsidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txttime.Text = DateTime.Now.ToShortDateString();
            label1.Text = DateTime.Now.ToShortTimeString();
        }

        private void btncontactoscliente_Click(object sender, EventArgs e)
        {
            AbrirFormularios<ContactoCliente>();
        }

        private void btnmantenimientos_Click(object sender, EventArgs e)
        {
            AbrirFormularios<Mantenimiento>();
        }

        private void btnasesorias_Click(object sender, EventArgs e)
        {
            AbrirFormularios<Asesorias>();
        }

        private void btncerrarsesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estas seguro de cerrar la sesion?", "¡Alerta!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                Login l = new Login();
                l.Show();
            }
        }

        private void btnventas_Click(object sender, EventArgs e)
        {
            AbrirFormularios<ventasFinal>();
        }

        private void btnenvios_Click(object sender, EventArgs e)
        {
            AbrirFormularios<EnviosFinal>();
        }

        private void btncobros_Click(object sender, EventArgs e)
        {
            AbrirFormularios<Cobros>();
        }

        private void btnventasdetalles_Click(object sender, EventArgs e)
        {
            AbrirFormularios<ventasDetalle>();
        }

        private void btndetallesenvios_Click(object sender, EventArgs e)
        {
            AbrirFormularios<DetallesEnvio>();
        }

        private void btn_Tripulacion_Click(object sender, EventArgs e)
        {
            AbrirFormularios<Tripulacion>();
        }

        private void btn_Ofertas_Click(object sender, EventArgs e)
        {
            AbrirFormularios<OfertaAsociacion>();
        }

        private void btnunidadestransporte_Click(object sender, EventArgs e)
        {
            AbrirFormularios<UnidadesTransporte>();
        }

        private void AbrirFormularios<FormularioAbrir>() where FormularioAbrir : Form, new()
        {
            Form Formularios;

            Formularios = panelcontenedor.Controls.OfType<FormularioAbrir>().FirstOrDefault();

            if (Formularios == null)
            {
                Formularios = new FormularioAbrir
                {
                    TopLevel = false,
                    Dock = DockStyle.Fill
                };

                panelcontenedor.Controls.Add(Formularios);
                panelcontenedor.Tag = Formularios;
                Formularios.Show();
                Formularios.BringToFront();

            }
            else
            {
                Formularios.BringToFront();
            }

        }

    }
}
