using PrefinalProgramacionPunto3D.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrefinalProgramacionPunto3D.Windows
{
    public partial class frmPunto3DAe : Form
    {
        private Punto3D? puntos3d;
        public frmPunto3DAe()
        {
            InitializeComponent();
        }

        public Punto3D? GetPunto3D()
        {
            return puntos3d;
        }

       



        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (!int.TryParse(txtZ.Text, out int z) || z <= 0)
            {
                valido = false;
                errorProvider1.SetError(txtZ, "Z mal ingresado");
            }
            if (!int.TryParse(txtY.Text, out int y) || y <= 0)
            {
                valido = false;
                errorProvider1.SetError(txtY, "Y mal ingresad");
            }
            if (!int.TryParse(txtY.Text, out int x) || x <= 0)
            {
                valido = false;
                errorProvider1.SetError(txtX, "X mal ingresada");
            }
            return valido;
        }

        private void btnOK_Click_1(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (puntos3d is null)
                {
                    puntos3d = new Punto3D();
                }
                puntos3d.DatoZ = int.Parse(txtZ.Text);
                puntos3d.DatoX = int.Parse(txtX.Text);
                puntos3d.DatoY = int.Parse(txtY.Text);
                puntos3d.Color = (txtColor.Text);
                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
