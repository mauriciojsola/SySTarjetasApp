using System;
using System.Linq;
using System.Windows.Forms;
using Autofac;
using Autofac.Core;
using SySTarjetas.Core.Infrastructure.Persistence;
using SySTarjetas.Core.Repository;
using SySTarjetas.Core.Service;
using SySTarjetas.Desktop.Controls;

using Telerik.WinControls.UI;

namespace SySTarjetas.Desktop
{
    public partial class ListarComercios : BaseForm
    {
        public IComerciosService ComerciosService { get; set; }
        public IComercioRepository ComercioRepository { get; set; }
        public IUnitOfWorkProvider UnitOfWorkProvider { get; set; }

        public ListarComercios()
        {
            InitializeComponent();
        }

        private void ListarComercios_Load(object sender, EventArgs e)
        {
            CargarComercios();
        }

        private void gridComercios_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            EditarComercio();
        }

        private void EditarComercio()
        {
            var formEdit = IoCContainer.Resolve<EditarComercios>(new Parameter[] { new NamedParameter("comercioId", ComercioSeleccionado) });  //new EditarComercios(ComercioSeleccionado);
            formEdit.ShowDialog();
            CargarComercios();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = IoCContainer.Resolve<EditarComercios>();
            form.ShowDialog();
            CargarComercios();
        }

        public void CargarComercios()
        {
            using (var uow = UnitOfWorkProvider.BeginUnitOfWork())
            {
                var comercios = ComercioRepository.GetAll();
                gridComercios.DataSource = comercios.Select(x => new { x.Id, x.RazonSocial, x.CUIT, x.Direccion }).OrderBy(y => y.RazonSocial).ToList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ComercioSeleccionado == -1)
            {
                MessageBox.Show("Seleccione un Comercio a eliminar", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }
            var comercio = gridComercios.CurrentRow.Cells[1].Value;
            var result = MessageBox.Show("Confirma eliminar el comercio " + comercio + "?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                             MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                using (var uow = UnitOfWorkProvider.BeginUnitOfWork())
                {
                    ComerciosService.EliminarComercio(ComercioSeleccionado);
                    uow.Commit();
                }
                CargarComercios();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (ComercioSeleccionado == -1)
            {
                MessageBox.Show("Seleccione un Comercio a editar", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }
            EditarComercio();
        }

        private int ComercioSeleccionado
        {
            get
            {
                var id = gridComercios.CurrentRow.Cells[0].Value;
                if (id != null) return Convert.ToInt32(id);
                return -1;
            }
        }

    }
}
