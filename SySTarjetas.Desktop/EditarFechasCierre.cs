using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SySTarjetas.Desktop.Controls;
using SySTarjetas.Core.Common;
using SySTarjetas.Core.Common.Extensions;
using SySTarjetas.Core.Infrastructure.Persistence;
using SySTarjetas.Core.Repository;
using SySTarjetas.Core.Service;

namespace SySTarjetas.Desktop
{
    public partial class EditarFechasCierre : BaseForm
    {
        public IUnitOfWorkProvider UnitOfWorkProvider { get; set; }
        public ISySTarjetasService SySTarjetasService { get; set; }
        public ITarjetaRepository TarjetaRepository { get; set; }
        public ITitularRepository TitularRepository { get; set; }

        protected DateTime _ultimaFechaCierre { get; set; }

        public EditarFechasCierre()
        {
            InitializeComponent();
        }

        private void EditarFechasCierre_Load(object sender, EventArgs e)
        {
            LoadComboTitulares();
            LoadComboTarjetas();
            CargarComboAños();
            CargarComboMeses();
            lblFechaDeCierreSeleccionada.Text = string.Empty;
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

        private int TarjetaSeleccionada
        {
            get { return cboTarjetas.SelectedItem != null ? ((ComboBoxItem)cboTarjetas.SelectedItem).Value : -1; }
        }

        private int TitularSeleccionado
        {
            get { return cboTitulares.SelectedItem != null ? ((ComboBoxItem)cboTitulares.SelectedItem).Value : -1; }
        }

        private DateTime FechaCupon
        {
            get { return txtFechaCierre.Value.Date; }
        }

        private int AñoSeleccionado
        {
            get { return cboAnios.SelectedItem != null ? ((ComboBoxItem)cboAnios.SelectedItem).Value : -1; }
        }

        private int MesSeleccionado
        {
            get { return cboMeses.SelectedItem != null ? ((ComboBoxItem)cboMeses.SelectedItem).Value : -1; }
        }

        private DateTime FechaCierreSeleccionada
        {
            get { return txtFechaCierre.Value.Date; }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!ValidarRequeridos())
            {
                return;
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

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cboTitulares_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadComboTarjetas();
        }

        private void cboTarjetas_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarFechaDeCierre();
        }

        private void CargarFechaDeCierre()
        {
            var fechaCierre = SySTarjetasService.TraerFechaDeCierre(TarjetaSeleccionada, AñoSeleccionado,
                                                                    MesSeleccionado);
            if (fechaCierre.HasValue)
            {
                _ultimaFechaCierre = fechaCierre.Value;
                MostrarFechaDeCierre(fechaCierre.Value);
            }
            else
            {
                PermitirSeleccionarFecha();
            }
        }

        private void PermitirSeleccionarFecha()
        {
            lblFechaCierre.Visible = false;
            txtFechaCierre.Visible = false;
            lnkCancelar.Visible = false;
            lnkSeleccionarFechaCierre.Visible = TarjetaSeleccionada > -1;
            lnkSeleccionarFechaCierre.Text = "Seleccionar";
            lblFechaDeCierreSeleccionada.Visible = true;
            lblFechaDeCierreSeleccionada.Text = "No hay fecha seleccionada";
        }

        private void MostrarFechaDeCierre(DateTime fechaCierre)
        {
            lblFechaCierre.Visible = false;
            txtFechaCierre.Visible = false;
            lnkCancelar.Visible = false;
            lnkSeleccionarFechaCierre.Visible = true;
            lnkSeleccionarFechaCierre.Text = "Cambiar";
            lblFechaDeCierreSeleccionada.Visible = true;
            lblFechaDeCierreSeleccionada.Text = "Fecha de Cierre: " + fechaCierre.ToShortDateString();
        }

        private void cboAnios_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarFechaDeCierre();
        }

        private void cboMeses_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarFechaDeCierre();
        }

        private void lnkSeleccionarFechaCierre_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lnkSeleccionarFechaCierre.Text == "Seleccionar")
            {
                lnkSeleccionarFechaCierre.Text = "Grabar";
                var fecha = new DateTime(AñoSeleccionado, MesSeleccionado, 1);
                fecha = fecha.LastMonthDay();
                MostrarDatePicker(fecha);
            }
            else if (lnkSeleccionarFechaCierre.Text == "Cambiar")
            {
                lnkSeleccionarFechaCierre.Text = "Actualizar";
                MostrarDatePicker(_ultimaFechaCierre);
            }
            else if (lnkSeleccionarFechaCierre.Text == "Grabar")
            {
                using (var uow = UnitOfWorkProvider.BeginUnitOfWork())
                {
                    SySTarjetasService.GrabarFechaDeCierre(TarjetaSeleccionada, AñoSeleccionado, MesSeleccionado, FechaCierreSeleccionada);
                    uow.Commit();
                }
                
                CargarFechaDeCierre();
            }
            else if (lnkSeleccionarFechaCierre.Text == "Actualizar")
            {
                using (var uow = UnitOfWorkProvider.BeginUnitOfWork())
                {
                    SySTarjetasService.ActualizarFechaDeCierre(TarjetaSeleccionada, AñoSeleccionado, MesSeleccionado, FechaCierreSeleccionada);
                    uow.Commit();
                }

                CargarFechaDeCierre();
            }
        }

        private void MostrarDatePicker(DateTime fecha)
        {
            lblFechaDeCierreSeleccionada.Visible = false;
            lblFechaCierre.Visible = true;
            txtFechaCierre.Visible = true;
            txtFechaCierre.Value = fecha;
            lnkCancelar.Visible = true;
        }

        private void lnkCancelar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CargarFechaDeCierre();
        }
    }
}
