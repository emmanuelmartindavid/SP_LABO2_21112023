using Entities.Controllers;
using Entities.Exceptions;
using Entities.Models;
using Entities.Validators;
namespace UIHotel
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FrmRooms : Form
    {
        private readonly RoomController _roomController;
        private readonly DataEntryValidator _dataEntryValidator;
        private readonly EFrmType _eFrmRoomType;


        public FrmRooms(EFrmType register)
        {
            InitializeComponent();
            _roomController = new();
            _dataEntryValidator = new();
            this._eFrmRoomType = register;

            if (register == EFrmType.Edit)
            {
                this.btnRegisterRoom.Visible = false;
                this.btnDeleteRoom.Visible = true;
                this.btnModifyRoom.Visible = true;
                this.lblAvaible.Visible = false;
            }
            else
            {
                this.lblAvaible.Visible = false;
                this.cmbAvaiableRoom.Visible = false;
                this.btnRegisterRoom.Visible = true;
                this.btnDeleteRoom.Visible = false;
                this.btnModifyRoom.Visible = false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmRooms_Load(object sender, EventArgs e)
        {
            this.UpdateRoomDataGrid();
            this.cmbAvaiableRoom.DataSource = new List<bool> { true, false };
            this.cmbRoomType.DataSource = Enum.GetValues(typeof(ERoomType));
            this.cmbAvaiableRoom.DisplayMember = "DisplayProperty";
        }
        /// <summary>
        /// 
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
                    Available = (bool)this.cmbAvaiableRoom.SelectedItem,
                };
                await this._roomController.AddRoom(room);
                this.UpdateRoomDataGrid();
                MessageBox.Show("Huesped registrado correctamente", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ValidateDataGuestException ex)
            {
                this.ShowError(ex.Message);
            }
            catch (Exception)
            {
                this.ShowError("Ha ocurrido un error inesperado");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            if (this.dgvRoomHandler.CurrentRow != null)
            {
                var room = (Room)this.dgvRoomHandler.CurrentRow.DataBoundItem;
                if (room is not null)
                {
                    await this._roomController.DeleteRoom(room.Number);
                    MessageBox.Show("Habitacion eliminada correctamente", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.UpdateRoomDataGrid();
                }
            }
            else
            {
                this.ShowError("No hay Habitaciones para eliminar");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnModifyRoom_Click(object sender, EventArgs e)
        {
            try
            {
                /*if (this.dgvReservationHandler.CurrentRow == null)
                {
                    this.ShowError("No hay reservas para actualizar");
                    return;
                }*/
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
                    this.UpdateRoomDataGrid();
                    MessageBox.Show("Habitacion actualizada correctamente", "Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (ValidateDataRoomException ex)
            {
                this.ShowError(ex.Message);
            }
            catch (ValidateDataReservationException ex)
            {
                this.ShowError(ex.Message);
            }
            catch (Exception ex)
            {
                this.ShowError($"Error al actualizar Habitacion: {ex.Message}");
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
                this.cmbAvaiableRoom.SelectedItem = room.Available;
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
        private async void UpdateRoomDataGrid()
        {
            var room = await _roomController.GetAvailableRooms();
            this.dgvRoomHandler.DataSource = room;
            this.UpdateDatGrid();
            if (room.Count > 0)
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

        /// <summary>
        /// Borra los datos de los campos de texto y el DataGridView.
        /// </summary>
        public void DeleteData()
        {

            this.txtRoomNumber.Text = string.Empty;
            this.cmbRoomType.SelectedItem = null;
            this.cmbAvaiableRoom.SelectedItem = null;

            if (_eFrmRoomType == EFrmType.Register)
            {
                this.lblRoomDgv.Text = "Huespedes";
            }
            else
            {
                this.lblRoomDgv.Text = "No hay huespedes";
            }
        }
    }
}
