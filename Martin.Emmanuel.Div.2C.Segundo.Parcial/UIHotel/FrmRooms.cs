using Entities.Controllers;
using Entities.Handlers.RoomExceptions;
using Entities.Models;
using Entities.Utilities;
using Entities.Validators;
namespace UIHotel
{
    public partial class FrmRooms : BaseFormTrack
    {
        private readonly GuestController _guestController;
        private readonly RoomController _roomController;
        private readonly ReservationController _reservationController;
        private readonly DataEntryValidator _dataEntryValidator;
        private readonly EFrmType _eFrmRoomType;

        public FrmRooms(EFrmType register)
        {
            this.InitializeComponent();
            this._roomController = new();
            this._dataEntryValidator = new();
            this._eFrmRoomType = register;
            if (register == EFrmType.Edit)
            {
                this.btnRegisterRoom.Visible = false;
                this.btnDeleteRoom.Visible = true;
                this.btnModifyRoom.Visible = true;

            }
            else
            {

                this.btnRegisterRoom.Visible = true;
                this.btnDeleteRoom.Visible = false;
                this.btnModifyRoom.Visible = false;
            }
        }


        public FrmRooms(EFrmType register, GuestController guestController, RoomController roomController, ReservationController reservationController)
        {
            this.InitializeComponent();
            this._guestController = guestController;
            this._roomController = roomController;
            this._reservationController = reservationController;
            this._dataEntryValidator = new();
            this._eFrmRoomType = register;
            this.OnUserTracker += OnUserAction;

            if (register == EFrmType.Edit)
            {
                this.btnRegisterRoom.Visible = false;
                this.btnDeleteRoom.Visible = true;
                this.btnModifyRoom.Visible = true;
            }
            else
            {
                this.btnRegisterRoom.Visible = true;
                this.btnDeleteRoom.Visible = false;
                this.btnModifyRoom.Visible = false;
            }
        }
        /// <summary>
        /// Evento que se ejecuta al hacer doble click sobre una fila del DataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void FrmRooms_Load(object sender, EventArgs e)
        {
            await this.UpdateRoomDataGrid();
            this.cmbRoomType.DataSource = Enum.GetValues(typeof(ERoomType));
        }
        /// <summary>
        /// Evento que se ejecuta al hacer doble click sobre una fila del DataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnRegisterRoom_Click(object sender, EventArgs e)
        {
            try
            {
                var roomNumber = this._dataEntryValidator.ValidateRoomNumber(this.txtRoomNumber.Text);
                await this._dataEntryValidator.ValidateRoomExistenceForNewRoom(roomNumber);
                var room = new Room
                {
                    Number = roomNumber,
                    Type = (ERoomType)this.cmbRoomType.SelectedItem,
                };
                await this._roomController.AddRoom(room);
                await this.UpdateRoomDataGrid();
                MessageBox.Show("Huesped registrado correctamente", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.TriggerUserTracker($"Usuario registra nueva habitacion a sistema: {DateTime.Now} - Nro: {room.Number}");
            }
            catch (Exception ex)
            {
                this.ShowError($"Error al agregar habitacion: {ex.Message}");
            }
        }

        /// <summary>
        /// Muestra un mensaje de error.
        /// </summary>
        /// <param name="message"></param>

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// Evento que se ejecuta al hacer doble click sobre una fila del DataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            if (this.dgvRoomHandler.CurrentRow != null)
            {
                try
                {
                    var room = (Room)this.dgvRoomHandler.CurrentRow.DataBoundItem;
                    if (room is not null)
                    {
                        await this._roomController.DeleteRoom(room.Number);
                        MessageBox.Show("Habitacion eliminada correctamente", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await this.UpdateRoomDataGrid();
                        this.TriggerUserTracker($"Usuario elimina habitacion de sistema: {DateTime.Now} - Nro: {room.Number}");
                    }
                }
                catch (RoomNotDeletedException ex)
                {
                    this.ShowError(ex.Message);
                }
            }
            else
            {
                this.ShowError("No hay Habitaciones para eliminar");
            }
        }
        /// <summary>
        /// Evento que se ejecuta al hacer doble click sobre una fila del DataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnModifyRoom_Click(object sender, EventArgs e)
        {
            try
            {
                var room = (Room)this.dgvRoomHandler.CurrentRow.DataBoundItem;
                if (room is not null)
                {
                    var roomNumber = this._dataEntryValidator.ValidateRoomNumber(this.txtRoomNumber.Text);
                    await this._dataEntryValidator.ValidateRoomExistenceForNewRoom(roomNumber);
                    var newRoom = new Room
                    {
                        Number = roomNumber,
                        Type = (ERoomType)this.cmbRoomType.SelectedItem,
                        Available = true,
                    };
                    await this._roomController.UpdateRoom(newRoom);
                    await this.UpdateRoomDataGrid();
                    MessageBox.Show("Habitacion actualizada correctamente", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.TriggerUserTracker($"Usuario modifica habitacion en sistema: {DateTime.Now} - Nro: {room.Number}");
                }
            }
            catch (Exception ex)
            {
                this.ShowError($"Error al actualizar habitacion: {ex.Message}");
            }
        }

        /// <summary>
        /// Actualiza los campos de texto con los detalles del huesped seleccionado.
        /// </summary>
        private void UpdateTxtView()
        {
            var room = (Room)this.dgvRoomHandler.CurrentRow.DataBoundItem;
            if (room is not null)
            {
                this.txtRoomNumber.Text = room.Number.ToString();
                this.cmbRoomType.SelectedItem = room.Type;
            }
        }

        /// <summary>
        /// Actualiza los encabezados de las columnas del DataGridView.
        /// </summary>
        private void UpdateDatGrid()
        {
            this.dgvRoomHandler.Columns[0].HeaderText = "Numero";
            this.dgvRoomHandler.Columns[1].Visible = false;
            this.dgvRoomHandler.Columns[2].HeaderText = "Tipo";
            this.dgvRoomHandler.Columns[3].Visible = false;
        }

        /// <summary>
        /// Actualiza el DataGridView con los huespedes actuales.
        /// </summary>
        private async Task UpdateRoomDataGrid()
        {
            try
            {
                this.dgvRoomHandler.DataSource = null;
                var rooms = await this._roomController.GetAllRooms();
                var availableRooms = rooms.Where(room => room.Available).ToList();
                this.dgvRoomHandler.DataSource = availableRooms;
                this.UpdateDatGrid();
                if (availableRooms.Count > 0)
                {
                    this.lblRoomDgv.Text = "Habitaciones. Doble click sobre la habitacion que quiera seleccionar.";
                    this.UpdateTxtView();
                    if (_eFrmRoomType == EFrmType.Register)
                    {
                        this.DeleteData();
                    }
                }
                else
                {
                    this.DeleteData();
                }
            }
            catch (RoomNotObtainedException ex)
            {
                this.ShowError($"Error al actualizar las habitaciones: {ex.Message}");
            }
        }

        /// <summary>
        /// Borra los datos de los campos de texto y el DataGridView.
        /// </summary>
        public void DeleteData()
        {
            this.txtRoomNumber.Text = string.Empty;
            this.cmbRoomType.SelectedItem = null;
            if (_eFrmRoomType == EFrmType.Register)
            {
                this.lblRoomDgv.Text = "Habitaciones";
            }
            else
            {
                this.lblRoomDgv.Text = "No hay habitaciones";
            }
        }

        /// <summary>
        /// Evento que se ejecuta al cerrar el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmRooms_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmPrincipal frmPrincipal = new(_guestController, _roomController, _reservationController);
            frmPrincipal.Show();
        }

        /// <summary>
        /// Evento que se ejecuta al hacer doble click sobre una fila del DataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvRoomHandler_DoubleClick(object sender, EventArgs e)
        {
            this.UpdateTxtView();
        }

        /// <summary>
        /// Agrega accion de usuario a la lista de acciones.
        /// </summary>
        /// <param name="action"></param>
        private void OnUserAction(string action)
        {
            UtilityClass.ActionLog.Add(action);
        }
    }
}
