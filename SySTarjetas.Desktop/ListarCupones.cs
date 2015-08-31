using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Autofac;
using Autofac.Core;
using SySTarjetas.Desktop.Controls;
using SySTarjetas.Core.Common;
using SySTarjetas.Core.Infrastructure.Persistence;
using SySTarjetas.Core.Repository;
using SySTarjetas.Core.Service;
using Telerik.WinControls.UI;

namespace SySTarjetas.Desktop
{
    public partial class ListarCupones : BaseForm
    {
        public IUnitOfWorkProvider UnitOfWorkProvider { get; set; }
        public ISySTarjetasService SySTarjetasService { get; set; }

        public ITarjetaRepository TarjetaRepository { get; set; }
        public IComercioRepository ComercioRepository { get; set; }
        public ITitularRepository TitularRepository { get; set; }

        private void ListarCupones_Load(object sender, EventArgs e)
        {
            chkTodosLosCupones.CheckState = CheckState.Unchecked;
            CargarComboTitulares();
            CargarComboTarjetas();
            CargarComboAños();
            CargarComboMeses();
            CargarCupones();
        }

        public ListarCupones()
        {
            InitializeComponent();
        }

        private void gridCupones_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            EditarCupon();
        }

        private void EditarCupon()
        {
            var cuponSeleccionado = CuponSeleccionado;
            var formEdit = IoCContainer.Resolve<EditarCupones>(new Parameter[] { new NamedParameter("cuponId", CuponSeleccionado) });
            formEdit.ShowDialog();
            CargarCupones();
            SeleccionarFilaSegunCuponId(cuponSeleccionado);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = IoCContainer.Resolve<EditarCupones>();
            form.ShowDialog();
            CargarCupones();
        }

        private void SeleccionarFilaSegunCuponId(int cuponId)
        {
            var filaId = 0;
            foreach (var fila in gridCupones.Rows)
            {
                var id = (int)fila.Cells[0].Value;
                if (id == cuponId)
                {
                    break;
                }
                filaId++;
            }
            gridCupones.Rows[filaId].IsSelected = true;
            gridCupones.Rows[filaId].IsCurrent = true;
        }

        public void CargarCupones()
        {
            if (TarjetaSeleccionada > -1)
            {
                var cupones = chkTodosLosCupones.CheckState == CheckState.Checked
                                  ? SySTarjetasService.TraerCuponesPorTarjeta(TarjetaSeleccionada)
                                  : SySTarjetasService.TraerCuponesPorTarjetaAnioYMes(TarjetaSeleccionada,
                                                                                      AñoSeleccionado, MesSeleccionado);

                var listadoCupones = cupones.Select(
                        x =>
                        new
                            {
                                Id = x.Id,
                                RazonSocial = x.Comercio.RazonSocial,
                                FechaCompra = x.FechaCompra.ToShortDateString(),
                                FechaCompraParaOrdenar = x.FechaCompra,
                                NumeroCupon = x.NumeroCupon,
                                Importe = x.Importe,
                                ImporteFormateado = x.Importe.ToString("N"),
                                Cuotas = x.CantidadCuotas
                            }).ToList();

                gridCupones.DataSource = listadoCupones.OrderBy(x => x.FechaCompraParaOrdenar);
                gridCupones.Refresh();
                lblTotal.Text = listadoCupones.Sum(x => x.Importe).ToString("N");
            }
        }

        private void CargarComboTitulares()
        {
            var titulares = TitularRepository.GetAll().OrderBy(x => x.Apellido).ThenBy(x => x.Nombre)
                .Select(x => new ComboBoxItem { Text = x.Apellido + ", " + x.Nombre, Value = x.Id }).ToList();

            cboTitulares.Items.Clear();
            var list = new List<ComboBoxItem> { new ComboBoxItem { Text = "- Seleccione un Titular -", Value = -1 } };
            list.AddRange(titulares);

            cboTitulares.DataSource = list;
            cboTitulares.ValueMember = "Value";
            cboTitulares.DisplayMember = "Text";
        }

        private void CargarComboTarjetas()
        {
            if (TitularSeleccionado > -1)
            {
                var titular = (ComboBoxItem)cboTitulares.SelectedItem;

                var tarjetasTitular =
                    TarjetaRepository.PorTitular(titular.Value).OrderBy(x => x.Banco.RazonSocial).ThenBy(
                        x => x.TipoTarjeta.Descripcion)
                        .Select(x => new ComboBoxItem
                        {
                            Text = x.Banco.RazonSocial + " - " + x.TipoTarjeta.Descripcion + " -   [" + x.NumeroTarjeta + "]",
                            Value = x.Id
                        });
                var list = new List<ComboBoxItem> { new ComboBoxItem { Text = "--- Seleccione una Tarjeta ---", Value = -1 } };
                list.AddRange(tarjetasTitular);

                cboTarjetas.DataSource = list;
                cboTarjetas.ValueMember = "Value";
                cboTarjetas.DisplayMember = "Text";
            }
        }

        private void CargarComboAños()
        {
            cboAnios.Items.Clear();
            var list = new List<ComboBoxItem>();

            for (int i = DateTime.Now.Year - 3; i < DateTime.Now.Year + 3; i++)
            {
                list.Add(new ComboBoxItem { Text = i.ToString(), Value = i });
            }

            cboAnios.DataSource = list;
            cboAnios.ValueMember = "Value";
            cboAnios.DisplayMember = "Text";
            cboAnios.SelectedValue = DateTime.Now.Year;
        }

        private void CargarComboMeses()
        {
            cboMeses.Items.Clear();
            var list = new List<ComboBoxItem>
            {
                new ComboBoxItem {Text = "Enero", Value = 1},
                new ComboBoxItem {Text = "Febrero", Value = 2},
                new ComboBoxItem {Text = "Marzo", Value = 3},
                new ComboBoxItem {Text = "Abril", Value = 4},
                new ComboBoxItem {Text = "Mayo", Value = 5},
                new ComboBoxItem {Text = "Junio", Value = 6},
                new ComboBoxItem {Text = "Junio", Value = 7},
                new ComboBoxItem {Text = "Agosto", Value = 8},
                new ComboBoxItem {Text = "Setiembre", Value = 9},
                new ComboBoxItem {Text = "Octubre", Value = 10},
                new ComboBoxItem {Text = "Noviembre", Value = 11},
                new ComboBoxItem {Text = "Diciembre", Value = 12}
            };

            cboMeses.DataSource = list;
            cboMeses.ValueMember = "Value";
            cboMeses.DisplayMember = "Text";
            cboMeses.SelectedValue = DateTime.Now.Month;
        }

        private void cboTitulares_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboTarjetas();
        }

        private int CuponSeleccionado
        {
            get
            {
                var id = gridCupones.CurrentRow.Cells[0].Value;
                if (id != null) return Convert.ToInt32(id);
                return -1;
            }
        }

        private int TarjetaSeleccionada
        {
            get { return cboTarjetas.SelectedItem != null ? ((ComboBoxItem)cboTarjetas.SelectedItem).Value : -1; }
        }

        private int TitularSeleccionado
        {
            get { return cboTitulares.SelectedItem != null ? ((ComboBoxItem)cboTitulares.SelectedItem).Value : -1; }
        }

        private int AñoSeleccionado
        {
            get { return cboAnios.SelectedItem != null ? ((ComboBoxItem)cboAnios.SelectedItem).Value : -1; }
        }

        private int MesSeleccionado
        {
            get { return cboMeses.SelectedItem != null ? ((ComboBoxItem)cboMeses.SelectedItem).Value : -1; }
        }

        private void cboTarjetas_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCupones();
        }

        private void cboAnios_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCupones();
        }

        private void cboMeses_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCupones();
        }

        private void chkTodosLosCupones_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodosLosCupones.CheckState == CheckState.Checked)
            {
                cboAnios.Enabled = false;
                cboMeses.Enabled = false;
            }
            else
            {
                cboAnios.Enabled = true;
                cboMeses.Enabled = true;
            }
            CargarCupones();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (CuponSeleccionado == -1)
            {
                MessageBox.Show("Seleccione un Cupón a eliminar", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }
            var nroCupon = gridCupones.CurrentRow.Cells[3].Value;
            var importeCupon = gridCupones.CurrentRow.Cells[5].Value;
            var result = MessageBox.Show("Confirma eliminar el Cupón #" + nroCupon + " de importe " + importeCupon + "?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                             MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                using (var uow = UnitOfWorkProvider.BeginUnitOfWork())
                {
                    SySTarjetasService.EliminarCupon(CuponSeleccionado);
                    CargarCupones();
                    uow.Commit();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (CuponSeleccionado == -1)
            {
                MessageBox.Show("Seleccione un Cupón a editar", "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }
            EditarCupon();
        }

        private void gridCupones_Click(object sender, EventArgs e)
        {

        }

    }
}
