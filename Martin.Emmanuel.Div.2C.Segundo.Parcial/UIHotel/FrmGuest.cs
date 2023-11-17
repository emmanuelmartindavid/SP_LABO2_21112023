using Entities.Controllers;
using Entities.Validators;
using Entities.Exceptions;
using Entities.Models;
using Entities.Handlers.GuestExceptions;
using Entities.Handlers.ReservationExceptions;
using Entities.Handlers.RoomExceptions;



namespace UIHotel
{
    /// <summary>
    /// Form para registrar huespedes.
    /// </summary>
    public partial class FrmGuest : Form
    {
        private readonly GuestController _guestController;
        private readonly ReservationController _reservationController;
        private readonly DataEntryValidator _dataEntryValidator;
        private readonly RoomController _roomController;
        private readonly EFrmType _eFrmGuestType;
        public FrmGuest(EFrmType eFrmGuestType)
        {
            InitializeComponent();
            this._guestController = new();
            this._dataEntryValidator = new();
            this._reservationController = new();
            this._roomController = new();
            this._eFrmGuestType = eFrmGuestType;

            if (eFrmGuestType == EFrmType.Edit)
            {
                this.btnRegisterGuest.Visible = false;
                this.btnDeleteGuest.Visible = true;
                this.btnModifyGuest.Visible = true;

            }
            else
            {
                this.btnRegisterGuest.Visible = true;
                this.btnDeleteGuest.Visible = false;
                this.btnModifyGuest.Visible = false;

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmGuestRegister_Load(object sender, EventArgs e)
        {
            this.UpdateGuestDataGrid();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnRegisterGuest_Click(object sender, EventArgs e)
        {
            try
            {
                this._dataEntryValidator.ValidateDniGuest(txtDni.Text);
                this._dataEntryValidator.ValidateNameGuest(txtName.Text, txtLastName.Text);
                this._dataEntryValidator.ValidatePhoneNumberGuest(txtPhoneNumber.Text);
                int dni = int.Parse(txtDni.Text);
                await _dataEntryValidator.ValidateGuestExistence(dni);
                var guest = new Guest
                {
                    Dni = dni,
                    Name = txtName.Text,
                    LastName = txtLastName.Text,
                    PhoneNumber = long.Parse(txtPhoneNumber.Text),
                };
                await this._guestController.AddGuest(guest);
                this.UpdateGuestDataGrid();
                MessageBox.Show("Huesped registrado correctamente", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                this.ShowError($"Error al actualizar huesped: {ex.Message}");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmGuestRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmPrincipal frmPrincipal = new();
            frmPrincipal.Show();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnDeleteGuest_Click(object sender, EventArgs e)
        {

            if (this.dgvGuestsHandler.CurrentRow != null)
            {
                try
                {
                    var guest = (Guest)this.dgvGuestsHandler.CurrentRow.DataBoundItem;
                    if (guest is not null)
                    {
                        await this._guestController.DeleteGuest(guest);

                        if (await this._dataEntryValidator.ValidateReservationExistence(guest.Dni))
                        {
                            var reservation = await this._reservationController.GetReservationByDni(guest.Dni);
                            await this._roomController.UpdateRoomAvailability(reservation.RoomNumber, true);
                            await this._reservationController.Delete(reservation);
                        }
                        MessageBox.Show("Reserva eliminada correctamente", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.UpdateGuestDataGrid();
                    }

                }
                catch (Exception ex)
                {
                    this.ShowError($"Error al eliminar huesped: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("No hay huespedes para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private async void btnModifyGuest_Click(object sender, EventArgs e)
        {
            try
            {
                var guest = (Guest)this.dgvGuestsHandler.CurrentRow.DataBoundItem;
                if (guest is not null)
                {
                    this._dataEntryValidator.ValidateDniGuest(this.txtDni.Text);
                    var guestDni = int.Parse(this.txtDni.Text);
                    this._dataEntryValidator.ValidateNameGuest(this.txtName.Text, this.txtLastName.Text);
                    this._dataEntryValidator.ValidatePhoneNumberGuest(this.txtPhoneNumber.Text);
                    await this._dataEntryValidator.ValidateGuestExistence(guestDni, guest.Dni);

                    var newGuest = new Guest
                    {
                        Dni = guest.Dni,
                        Name = this.txtName.Text,
                        LastName = this.txtLastName.Text,
                        PhoneNumber = long.Parse(this.txtPhoneNumber.Text),
                    };
                    await this._guestController.UpdateGuest(newGuest);
                    this.UpdateGuestDataGrid();
                    MessageBox.Show("Huesped actualizado correctamente", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                this.ShowError($"Error al actualizar huesped: {ex.Message}");
            }
        }
        /// <summary>
        /// Actualiza los campos de texto con los detalles del huesped seleccionado.
        /// </summary>
        private void UpdateTxtView()
        {
            var guest = (Guest)this.dgvGuestsHandler.CurrentRow.DataBoundItem;
            if (guest is not null)
            {
                this.txtDni.Text = guest.Dni.ToString();
                this.txtName.Text = guest.Name;
                this.txtLastName.Text = guest.LastName;
                this.txtPhoneNumber.Text = guest.PhoneNumber.ToString();
            }
        }


        /// <summary>
        /// Actualiza los encabezados de las columnas del DataGridView.
        /// </summary>
        private void UpdateDatGrid()
        {
            this.dgvGuestsHandler.Columns[0].HeaderText = "DNI";
            this.dgvGuestsHandler.Columns[1].HeaderText = "Nombre";
            this.dgvGuestsHandler.Columns[2].HeaderText = "Apellido";
            this.dgvGuestsHandler.Columns[3].HeaderText = "Nro Telefono";
            this.dgvGuestsHandler.Columns[4].Visible = false;
        }

        /// <summary>
        /// Actualiza el DataGridView con los huespedes actuales.
        /// </summary>
        private async void UpdateGuestDataGrid()
        {
            try
            {
                var guest = await this._guestController.GetAllGuests();
                this.dgvGuestsHandler.DataSource = guest;
                this.UpdateDatGrid();
                if (guest.Count > 0)
                {
                    this.lblGuestDgv.Text = "Huespedes. Doble click sobre el huesped que quiera seleccionar.";
                    this.UpdateTxtView();
                    if (_eFrmGuestType == EFrmType.Register)
                    {
                        this.DeleteData();
                    }
                }
                else
                {
                    this.DeleteData();
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex.Message);

            }
        }

        /// <summary>
        /// Borra los datos de los campos de texto y el DataGridView.
        /// </summary>
        public void DeleteData()
        {
            this.txtDni.Text = string.Empty;
            this.txtName.Text = string.Empty;
            this.txtLastName.Text = string.Empty;
            this.txtPhoneNumber.Text = string.Empty;
            if (_eFrmGuestType == EFrmType.Register)
            {
                this.lblGuestDgv.Text = "Huespedes";
            }
            else
            {
                this.lblGuestDgv.Text = "No hay huespedes";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgbGuestsHandler_DoubleClick(object sender, EventArgs e)
        {
            this.UpdateTxtView();
        }


        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

