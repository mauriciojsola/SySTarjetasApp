using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SySTarjetas.Core;
using SySTarjetas.Core.Common;
using SySTarjetas.Core.Common.Extensions;
using SySTarjetas.Core.Infrastructure.Persistence;
using SySTarjetas.Core.Repository;
using SySTarjetas.Core.Service;
using SySTarjetas.Desktop.Controls;

namespace SySTarjetas.Desktop
{
    public partial class EditarCupones : BaseForm
    {
        public IUnitOfWorkProvider UnitOfWorkProvider { get; set; }
        public ISySTarjetasService SySTarjetasService { get; set; }
        public IComercioRepository ComercioRepository { get; set; }
        public ITitularRepository TitularRepository { get; set; }
        public ITarjetaRepository TarjetaRepository { get; set; }

        private int _cuponId { get; set; }

        public EditarCupones()
            : this(-1)
        {
        }

        public EditarCupones(int cuponId)
        {
            _cuponId = cuponId;
            InitializeComponent();
        }

        private void EditarCupones_Load(object sender, EventArgs e)
        {
            Inicializar();
        }

        private void Inicializar()
        {
            LoadComboTitulares();
            LoadComboTarjetas();
            LoadComboComercios();
            if (_cuponId > 0)
            {
                PrepararCuponParaEdicion();
            }
        }

        private void PrepararCuponParaEdicion()
        {
            var cupon = SySTarjetasService.TraerCuponPorId(_cuponId);
            cboTitulares.SelectedValue = cupon.Tarjeta.Titular.Id;
            cboTitulares.Enabled = false;
            cboTarjetas.SelectedValue = cupon.Tarjeta.Id;
            cboTarjetas.Enabled = false;
            txtFechaCupon.Value = cupon.FechaCompra;
            cboComercios.SelectedValue = cupon.Comercio.Id;
            txtNroCupon.Text = cupon.NumeroCupon.ToString();
            txtImporte.Text = cupon.Importe.ToString();
            txtCuotas.Text = cupon.CantidadCuotas.ToString();
            txtObservaciones.Text = cupon.Observaciones;
        }

        private void LoadComboComercios()
        {
            var comercios = ComercioRepository.GetAll().OrderBy(x => x.RazonSocial)
               .Select(x => new ComboBoxItem { Text = x.RazonSocial, Value = x.Id }).ToList();

            cboComercios.Items.Clear();
            var list = new List<ComboBoxItem> { new ComboBoxItem { Text = "--- Seleccione un Comercio ---", Value = -1 } };
            list.AddRange(comercios);

            cboComercios.DataSource = list;
            cboComercios.ValueMember = "Value";
            cboComercios.DisplayMember = "Text";
        }

        private void LoadComboTitulares()
        {
            var titulares = TitularRepository.GetAll().OrderBy(x => x.Apellido).ThenBy(x => x.Nombre)
                .Select(x => new ComboBoxItem { Text = x.Apellido + ", " + x.Nombre, Value = x.Id }).ToList();

            cboTitulares.Items.Clear();
            var list = new List<ComboBoxItem> { new ComboBoxItem { Text = "--- Seleccione un Titular ---", Value = -1 } };
            list.AddRange(titulares);

            cboTitulares.DataSource = list;
            cboTitulares.ValueMember = "Value";
            cboTitulares.DisplayMember = "Text";
        }

        private void LoadComboTarjetas()
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

        private void InicializarPorNuevaCarga()
        {
            cboComercios.SelectedValue = -1;
            cboTarjetas.SelectedValue = -1;
            txtNroCupon.Text = string.Empty;
            txtFechaCupon.Value = DateTime.Now;
            txtImporte.Text = string.Empty;
            txtCuotas.Text = string.Empty;
            txtObservaciones.Text = string.Empty;
        }

        private string BuildCardText(Tarjeta tarjeta)
        {
            return tarjeta.Banco.RazonSocial + " - " + tarjeta.TipoTarjeta.Descripcion + " -   [" + tarjeta.NumeroTarjeta + "]";
        }

        private void cboTitulares_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadComboTarjetas();
        }

        private void EditarCupones_Resize(object sender, EventArgs e)
        {

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            // Necesito hacer esto para actualizar el contexto
            if (!ValidarRequeridos())
            {
                return;
            }

            using (var uow = UnitOfWorkProvider.BeginUnitOfWork())
            {
                if (_cuponId < 0)
                {
                    if (SySTarjetasService.ExisteCupon(TarjetaSeleccionada, FechaCupon, ComercioSeleccionado,
                                                       Convert.ToInt32(txtNroCupon.Text)))
                    {
                        MessageBox.Show("El cupón ya existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNroCupon.Focus();
                        return;
                    }

                    try
                    {
                        SySTarjetasService.GrabarCupon(TarjetaSeleccionada, FechaCupon, ComercioSeleccionado,
                                                       Convert.ToInt32(txtNroCupon.Text), Convert.ToDouble(txtImporte.Text),
                                                       Convert.ToInt32(txtCuotas.Text), txtObservaciones.Text);
                        uow.Commit();

                        MessageBox.Show("Cupón grabado", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        InicializarPorNuevaCarga();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    try
                    {
                        SySTarjetasService.ActualizarCupon(_cuponId, TarjetaSeleccionada, FechaCupon, ComercioSeleccionado,
                                                           Convert.ToInt32(txtNroCupon.Text), Convert.ToDouble(txtImporte.Text),
                                                           Convert.ToInt32(txtCuotas.Text), txtObservaciones.Text);

                        uow.Commit();

                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

            }
        }

        private bool ValidarRequeridos()
        {
            if (TitularSeleccionado == -1)
            {
                MessageBox.Show("Seleccione un Titular");
                cboTitulares.Focus();
                return false;
            }

            if (TarjetaSeleccionada == -1)
            {
                MessageBox.Show("Seleccione una Tarjeta");
                cboTarjetas.Focus();
                return false;
            }

            if (ComercioSeleccionado == -1)
            {
                MessageBox.Show("Seleccione un Comercio");
                cboComercios.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtNroCupon.Text) || !txtNroCupon.Text.EsNumero())
            {
                MessageBox.Show("Ingrese un número de cupón");
                txtNroCupon.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtImporte.Text) || !txtImporte.Text.EsNumero())
            {
                MessageBox.Show("Ingrese un importe");
                txtImporte.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtCuotas.Text) || !txtCuotas.Text.EsNumero() || txtCuotas.Text.ToInt32() < 1)
            {
                MessageBox.Show("Ingrese la cantidad de cuotas");
                txtCuotas.Focus();
                return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private int TarjetaSeleccionada
        {
            get { return cboTarjetas.SelectedItem != null ? ((ComboBoxItem)cboTarjetas.SelectedItem).Value : -1; }
        }

        private int ComercioSeleccionado
        {
            get { return cboComercios.SelectedItem != null ? ((ComboBoxItem)cboComercios.SelectedItem).Value : -1; }
        }

        private int TitularSeleccionado
        {
            get { return cboTitulares.SelectedItem != null ? ((ComboBoxItem)cboTitulares.SelectedItem).Value : -1; }
        }

        private DateTime FechaCupon
        {
            get { return txtFechaCupon.Value.Date; }
        }

        private void txtFechaCupon_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                cboComercios.Focus();
            }
        }

        private void cboComercios_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                txtNroCupon.Focus();
            }
        }

        private void txtNroCupon_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                txtImporte.Focus();
            }
        }

        private void txtImporte_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                txtCuotas.Focus();
            }
        }

        private void txtCuotas_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                btnGrabar.Focus();
            }
        }

        private void cboTitulares_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                cboTarjetas.Focus();
            }
        }

        private void cboTarjetas_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                txtFechaCupon.Focus();
            }
        }


    }
}
