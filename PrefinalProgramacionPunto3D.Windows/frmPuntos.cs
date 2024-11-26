using PrefinalProgramacionPunto3D.Datos;
using PrefinalProgramacionPunto3D.Entidades;
using System.Drawing;

namespace PrefinalProgramacionPunto3D.Windows
{
    public partial class frmPuntos : Form
    {
        public frmPuntos()
        {
            InitializeComponent();
            repo = new RepositorioPunto3D();
        }

        private RepositorioPunto3D repo;
        private List<Punto3D>? lista;
        private int cantidad;
        private void QuitarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Remove(r);
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
        }
        private void MostrarCantidad()
        {
            txtCantidad.Text = cantidad.ToString();
        }

        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var punto in lista!)
            {
                var r = ConstruirFila();
                SetearFila(r, punto);
                AgregarFila(r);
            }
        }

        private void AgregarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Punto3D Punto3d)
        {
            r.Cells[colX.Index].Value = Punto3d.DatoX;
            r.Cells[colZ.Index].Value = Punto3d.DatoZ;
            r.Cells[colY.Index].Value = Punto3d.DatoY;
            r.Cells[colColor.Index].Value = Punto3d.Color.ToString();
            r.Cells[colDistancia.Index].Value = Punto3d.GetDistancia().ToString("N2");

            r.Tag = Punto3d;
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbNuevo_Click_1(object sender, EventArgs e)
        {
            frmPunto3DAe frm = new frmPunto3DAe() { Text = "Agregar Punto3D" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            Punto3D? puntos3d = frm.GetPunto3D();
            if (puntos3d is null)
            {
                return;
            }
            if (!repo.Existe(puntos3d))
            {
                repo.Agregar(puntos3d);
                var r = ConstruirFila();
                SetearFila(r, puntos3d);
                AgregarFila(r);
                MostrarCantidad();
                MessageBox.Show($"Punto3D {puntos3d.ToString()} agregado", "Mensaje", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show($"Punto3D {puntos3d.ToString()} existente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void tsbBorrar_Click_1(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var rSeleccionada = dgvDatos.SelectedRows[0];
            Punto3D puntos3d = (Punto3D)rSeleccionada.Tag!;
            DialogResult dr = MessageBox.Show($"¿Desea borrar el rombo {puntos3d.ToString()}?",
                "Confirmar", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.No) return;
            repo.Borrar(puntos3d);
            QuitarFila(rSeleccionada);
            MostrarCantidad();
            MessageBox.Show($"Punto3D {puntos3d.ToString()} borrado", "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void tsbEditar_Click_1(object sender, EventArgs e)
        {

        }

        private void tsbSalir_Click_1(object sender, EventArgs e)
        {
            repo.GuardarDatos();
            MessageBox.Show("Fin del programa", "Mensaje", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            Application.Exit();
        }

        private void tsbActualizar_Click_1(object sender, EventArgs e)
        {
            lista = repo.GetPunto3D();
            MostrarCantidad();
            MostrarDatosEnGrilla();
        }

        private void lado09ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            lista = repo.GetListaOrdenada(Orden.Asc);
            MostrarDatosEnGrilla();
        }

        private void lado90ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            lista = repo.GetListaOrdenada(Orden.Desc);
            MostrarDatosEnGrilla();
        }
    }
}
