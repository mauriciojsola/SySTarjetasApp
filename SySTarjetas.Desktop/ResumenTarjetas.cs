using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Autofac;
using Autofac.Core;
using SySTarjetas.Core.Common;
using SySTarjetas.Core.Infrastructure.Persistence;
using SySTarjetas.Core.Repository;
using SySTarjetas.Core.Service;
using SySTarjetas.Desktop.Controls;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.UI;

namespace SySTarjetas.Desktop
{
    public partial class ResumenTarjetas : BaseForm
    {
        public ISySTarjetasService SySTarjetasService { get; set; }

        public ITarjetaRepository TarjetaRepository { get; set; }
        public ITitularRepository TitularRepository { get; set; }
        public IUnitOfWorkProvider UnitOfWorkProvider { get; set; }

        protected List<CuotasInfo> listadoCuotas;
        protected bool huboCambios { get; set; }

        private void ResumenTarjetas_Load(object sender, EventArgs e)
        {
            CargarComboTitulares();
            CargarComboTarjetas();
            CargarComboAños();
            CargarComboMeses();
            CargarCupones();
            huboCambios = false;
            gridCupones.SelectionMode = GridViewSelectionMode.FullRowSelect;
        }

        public ResumenTarjetas()
        {
            InitializeComponent();
        }

        public void CargarCupones()
        {
            if (TarjetaSeleccionada <= -1) return;
            listadoCuotas = SySTarjetasService.TraerResumenPorTarjetaAnioYMes(TarjetaSeleccionada, AñoSeleccionado, MesSeleccionado)
                .Select(
                x =>
                new CuotasInfo
                    {
                        Id = x.Id,
                        FechaCompra = x.Transaccion.FechaCompra.ToShortDateString(),
                        NroComprobante = x.Transaccion.NumeroCupon,
                        RazonSocial = x.Transaccion.Comercio.RazonSocial,
                        Cuota = x.NumeroCuota + " de " + x.Transaccion.CantidadCuotas,
                        Importe = x.Importe,
                        ImporteFormateado = x.Importe.ToString("N"),
                        Verificado = x.Verificado,
                        CuponId = x.Transaccion.Id
                    }).ToList();
            gridCupones.DataSource = listadoCuotas;
            gridCupones.Refresh();
            lblTotal.Text = listadoCuotas.Sum(x => x.Importe).ToString("N");
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
                new ComboBoxItem {Text = "Julio", Value = 7},
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

        private int CuotaSeleccionada
        {
            get
            {
                var id = gridCupones.CurrentRow.Cells[0].Value;
                if (id != null) return Convert.ToInt32(id);
                return -1;
            }
        }

        private int CuponSeleccionado
        {
            get
            {
                var id = gridCupones.CurrentRow.Cells[1].Value;
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

        private void btnActualizarCuponesVerificados_Click(object sender, EventArgs e)
        {
            ActualizarCuotasVerificadas();
        }

        private void ActualizarCuotasVerificadas()
        {
            using (var uow = UnitOfWorkProvider.BeginUnitOfWork())
            {
                foreach (var cuota in listadoCuotas)
                {
                    SySTarjetasService.MarcarVerificacionCuota(cuota.Id, cuota.Verificado);
                }
                uow.Commit();
            }
           
            MessageBox.Show("Verificaciones actualizadas", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            huboCambios = false;
        }

        private void gridCupones_ValueChanged(object sender, EventArgs e)
        {
            var editor = sender as RadCheckBoxEditor;
            if (editor == null) return;
            var verificado = ((ToggleState)editor.Value) == ToggleState.On;
            var cupon = listadoCuotas.FirstOrDefault(c => c.Id == CuotaSeleccionada);
            if (cupon != null) cupon.Verificado = verificado;
            huboCambios = true;
        }

        private void ResumenTarjetas_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConfirmarCambios();
        }

        private void ConfirmarCambios()
        {
            if (huboCambios)
            {
                if (MessageBox.Show("Actualizar las cuotas verificadas?", "Confirmación", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ActualizarCuotasVerificadas();
                    //e.Cancel = true;
                }
            }
        }

        private void EditarCupon()
        {
            var cuponSeleccionado = CuponSeleccionado;
            var formEdit = IoCContainer.Resolve<EditarCupones>(new Parameter[] { new NamedParameter("cuponId", CuponSeleccionado) });

            formEdit.ShowDialog();
            CargarCupones();
            SeleccionarFilaSegunCuponId(cuponSeleccionado);
        }

        private void gridCupones_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            ConfirmarCambios();
            EditarCupon();
            huboCambios = false;
        }

        private void SeleccionarFilaSegunCuponId(int cuponId)
        {
            var filaId = 0;
            foreach (var fila in gridCupones.Rows)
            {
                var id = (int)fila.Cells[1].Value;
                if (id == cuponId)
                {
                    break;
                }
                filaId++;
            }
            gridCupones.Rows[filaId].IsSelected = true;
            gridCupones.Rows[filaId].IsCurrent = true;
        }

    }
}
