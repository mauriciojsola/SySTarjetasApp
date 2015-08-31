using System;
using System.Windows.Forms;
using SySTarjetas.Core.Infrastructure.Persistence;
using SySTarjetas.Core.Service;
using SySTarjetas.Desktop.Controls;

namespace SySTarjetas.Desktop
{
    public partial class EditarComercios : BaseForm
    {
        public IComerciosService ComerciosService { get; set; }
        public IUnitOfWorkProvider UnitOfWorkProvider { get; set; }

        private int _comercioId { get; set; }

        public EditarComercios()
            : this(-1)
        {
        }

        public EditarComercios(int comercioId)
        {
            InitializeComponent();
            _comercioId = comercioId;
        }

        private void EditarComercios_Load(object sender, EventArgs e)
        {
            Inicializar();
        }

        private void Inicializar()
        {
            if (_comercioId > 0)
            {
                PrepararComercioParaEdicion();
            }
        }

        private void PrepararComercioParaEdicion()
        {
            var comercio = ComerciosService.TraerComercioPorId(_comercioId);
            txtCuit.Text = comercio.CUIT;
            txtCuit.Enabled = false;
            txtDireccion.Text = comercio.Direccion;
            txtRazonSocial.Text = comercio.RazonSocial;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                using (var uow = UnitOfWorkProvider.BeginUnitOfWork())
                {
                    if (_comercioId > 0)
                        ComerciosService.ActualizarComercio(_comercioId, txtRazonSocial.Text, txtDireccion.Text);
                    else
                        ComerciosService.AgregarComercio(txtRazonSocial.Text, txtCuit.Text, txtDireccion.Text);

                    uow.Commit();
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
