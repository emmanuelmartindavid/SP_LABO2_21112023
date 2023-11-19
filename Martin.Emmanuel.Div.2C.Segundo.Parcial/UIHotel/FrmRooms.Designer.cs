namespace UIHotel
{
    partial class FrmRooms
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblRoomDgv = new Label();
            btnModifyRoom = new Button();
            dgvRoomHandler = new DataGridView();
            btnDeleteRoom = new Button();
            btnRegisterRoom = new Button();
            grbRoomData = new GroupBox();
            cmbAvaiableRoom = new ComboBox();
            cmbRoomType = new ComboBox();
            txtRoomNumber = new TextBox();
            lblAvaible = new Label();
            lblType = new Label();
            lblRoomNumber = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvRoomHandler).BeginInit();
            grbRoomData.SuspendLayout();
            SuspendLayout();
            // 
            // lblRoomDgv
            // 
            lblRoomDgv.AutoSize = true;
            lblRoomDgv.Font = new Font("Arial Black", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblRoomDgv.Location = new Point(432, 31);
            lblRoomDgv.Name = "lblRoomDgv";
            lblRoomDgv.Size = new Size(76, 27);
            lblRoomDgv.TabIndex = 13;
            lblRoomDgv.Text = "label1";
            // 
            // btnModifyRoom
            // 
            btnModifyRoom.Font = new Font("Arial", 13F, FontStyle.Regular, GraphicsUnit.Point);
            btnModifyRoom.Location = new Point(302, 340);
            btnModifyRoom.Name = "btnModifyRoom";
            btnModifyRoom.Size = new Size(108, 42);
            btnModifyRoom.TabIndex = 12;
            btnModifyRoom.Text = "Modificar";
            btnModifyRoom.UseVisualStyleBackColor = true;
            btnModifyRoom.Click += btnModifyRoom_Click;
            // 
            // dgvRoomHandler
            // 
            dgvRoomHandler.BackgroundColor = SystemColors.ButtonFace;
            dgvRoomHandler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRoomHandler.Location = new Point(432, 61);
            dgvRoomHandler.Name = "dgvRoomHandler";
            dgvRoomHandler.RowTemplate.Height = 25;
            dgvRoomHandler.Size = new Size(451, 275);
            dgvRoomHandler.TabIndex = 11;
            dgvRoomHandler.DoubleClick += dgvRoomHandler_DoubleClick;
            // 
            // btnDeleteRoom
            // 
            btnDeleteRoom.Font = new Font("Arial", 13F, FontStyle.Regular, GraphicsUnit.Point);
            btnDeleteRoom.Location = new Point(152, 340);
            btnDeleteRoom.Name = "btnDeleteRoom";
            btnDeleteRoom.Size = new Size(108, 42);
            btnDeleteRoom.TabIndex = 10;
            btnDeleteRoom.Text = "Eliminar";
            btnDeleteRoom.UseVisualStyleBackColor = true;
            btnDeleteRoom.Click += btnDeleteRoom_Click;
            // 
            // btnRegisterRoom
            // 
            btnRegisterRoom.Font = new Font("Arial", 13F, FontStyle.Regular, GraphicsUnit.Point);
            btnRegisterRoom.Location = new Point(12, 340);
            btnRegisterRoom.Name = "btnRegisterRoom";
            btnRegisterRoom.Size = new Size(108, 42);
            btnRegisterRoom.TabIndex = 9;
            btnRegisterRoom.Text = "Guardar";
            btnRegisterRoom.UseVisualStyleBackColor = true;
            btnRegisterRoom.Click += btnRegisterRoom_Click;
            // 
            // grbRoomData
            // 
            grbRoomData.Controls.Add(cmbAvaiableRoom);
            grbRoomData.Controls.Add(cmbRoomType);
            grbRoomData.Controls.Add(txtRoomNumber);
            grbRoomData.Controls.Add(lblAvaible);
            grbRoomData.Controls.Add(lblType);
            grbRoomData.Controls.Add(lblRoomNumber);
            grbRoomData.Font = new Font("Arial", 13F, FontStyle.Regular, GraphicsUnit.Point);
            grbRoomData.Location = new Point(33, 61);
            grbRoomData.Name = "grbRoomData";
            grbRoomData.Size = new Size(325, 232);
            grbRoomData.TabIndex = 8;
            grbRoomData.TabStop = false;
            grbRoomData.Text = "Datos Habitacion";
            // 
            // cmbAvaiableRoom
            // 
            cmbAvaiableRoom.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAvaiableRoom.FormattingEnabled = true;
            cmbAvaiableRoom.Location = new Point(155, 171);
            cmbAvaiableRoom.Name = "cmbAvaiableRoom";
            cmbAvaiableRoom.Size = new Size(121, 27);
            cmbAvaiableRoom.TabIndex = 6;
            // 
            // cmbRoomType
            // 
            cmbRoomType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoomType.FormattingEnabled = true;
            cmbRoomType.Location = new Point(155, 110);
            cmbRoomType.Name = "cmbRoomType";
            cmbRoomType.Size = new Size(121, 27);
            cmbRoomType.TabIndex = 5;
            // 
            // txtRoomNumber
            // 
            txtRoomNumber.Location = new Point(155, 56);
            txtRoomNumber.Name = "txtRoomNumber";
            txtRoomNumber.Size = new Size(121, 27);
            txtRoomNumber.TabIndex = 4;
            // 
            // lblAvaible
            // 
            lblAvaible.AutoSize = true;
            lblAvaible.Location = new Point(13, 177);
            lblAvaible.Name = "lblAvaible";
            lblAvaible.Size = new Size(122, 21);
            lblAvaible.TabIndex = 2;
            lblAvaible.Text = "Disponibilidad";
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new Point(13, 116);
            lblType.Name = "lblType";
            lblType.Size = new Size(45, 21);
            lblType.TabIndex = 1;
            lblType.Text = "Tipo";
            // 
            // lblRoomNumber
            // 
            lblRoomNumber.AutoSize = true;
            lblRoomNumber.Location = new Point(13, 62);
            lblRoomNumber.Name = "lblRoomNumber";
            lblRoomNumber.Size = new Size(73, 21);
            lblRoomNumber.TabIndex = 0;
            lblRoomNumber.Text = "Numero";
            // 
            // FrmRooms
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(895, 452);
            Controls.Add(lblRoomDgv);
            Controls.Add(btnModifyRoom);
            Controls.Add(dgvRoomHandler);
            Controls.Add(btnDeleteRoom);
            Controls.Add(btnRegisterRoom);
            Controls.Add(grbRoomData);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "FrmRooms";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Habitaciones";
            FormClosing += FrmRooms_FormClosing;
            Load += FrmRooms_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRoomHandler).EndInit();
            grbRoomData.ResumeLayout(false);
            grbRoomData.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblRoomDgv;
        private Button btnModifyRoom;
        private DataGridView dgvRoomHandler;
        private Button btnDeleteRoom;
        private Button btnRegisterRoom;
        private GroupBox grbRoomData;
        private TextBox txtRoomNumber;
        private Label lblAvaible;
        private Label lblType;
        private Label lblRoomNumber;
        private ComboBox cmbAvaiableRoom;
        private ComboBox cmbRoomType;
    }
}