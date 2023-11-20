namespace UIHotel
{
    partial class FrmReservationHandler
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
            btnUpdateReservation = new Button();
            grbReservationData = new GroupBox();
            btnDelete = new Button();
            dtpCheckOut = new DateTimePicker();
            dtpCheckIn = new DateTimePicker();
            txtRoomNumber = new TextBox();
            lblRoomNumber = new Label();
            lblCheckOut = new Label();
            lblCheckIn = new Label();
            dgvReservationHandler = new DataGridView();
            lblReservationsDgv = new Label();
            grbReservationData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReservationHandler).BeginInit();
            SuspendLayout();
            // 
            // btnUpdateReservation
            // 
            btnUpdateReservation.Font = new Font("Arial", 13F, FontStyle.Regular, GraphicsUnit.Point);
            btnUpdateReservation.Location = new Point(13, 302);
            btnUpdateReservation.Name = "btnUpdateReservation";
            btnUpdateReservation.Size = new Size(108, 42);
            btnUpdateReservation.TabIndex = 5;
            btnUpdateReservation.Text = "Guardar";
            btnUpdateReservation.UseVisualStyleBackColor = true;
            btnUpdateReservation.Click += btnUpdateReservation_Click;
            // 
            // grbReservationData
            // 
            grbReservationData.Controls.Add(btnDelete);
            grbReservationData.Controls.Add(dtpCheckOut);
            grbReservationData.Controls.Add(dtpCheckIn);
            grbReservationData.Controls.Add(txtRoomNumber);
            grbReservationData.Controls.Add(btnUpdateReservation);
            grbReservationData.Controls.Add(lblRoomNumber);
            grbReservationData.Controls.Add(lblCheckOut);
            grbReservationData.Controls.Add(lblCheckIn);
            grbReservationData.Font = new Font("Arial", 13F, FontStyle.Regular, GraphicsUnit.Point);
            grbReservationData.Location = new Point(30, 39);
            grbReservationData.Name = "grbReservationData";
            grbReservationData.Size = new Size(329, 355);
            grbReservationData.TabIndex = 4;
            grbReservationData.TabStop = false;
            grbReservationData.Text = "Reservacion";
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Arial", 13F, FontStyle.Regular, GraphicsUnit.Point);
            btnDelete.Location = new Point(205, 302);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(108, 42);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Eliminar";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // dtpCheckOut
            // 
            dtpCheckOut.Location = new Point(110, 116);
            dtpCheckOut.Name = "dtpCheckOut";
            dtpCheckOut.Size = new Size(203, 27);
            dtpCheckOut.TabIndex = 8;
            // 
            // dtpCheckIn
            // 
            dtpCheckIn.Location = new Point(110, 65);
            dtpCheckIn.Name = "dtpCheckIn";
            dtpCheckIn.Size = new Size(203, 27);
            dtpCheckIn.TabIndex = 7;
            // 
            // txtRoomNumber
            // 
            txtRoomNumber.Location = new Point(128, 177);
            txtRoomNumber.Name = "txtRoomNumber";
            txtRoomNumber.Size = new Size(163, 27);
            txtRoomNumber.TabIndex = 6;
            // 
            // lblRoomNumber
            // 
            lblRoomNumber.AutoSize = true;
            lblRoomNumber.Location = new Point(18, 183);
            lblRoomNumber.Name = "lblRoomNumber";
            lblRoomNumber.Size = new Size(95, 21);
            lblRoomNumber.TabIndex = 3;
            lblRoomNumber.Text = "Habitacion";
            // 
            // lblCheckOut
            // 
            lblCheckOut.AutoSize = true;
            lblCheckOut.Location = new Point(14, 122);
            lblCheckOut.Name = "lblCheckOut";
            lblCheckOut.Size = new Size(90, 21);
            lblCheckOut.TabIndex = 2;
            lblCheckOut.Text = "CheckOut";
            // 
            // lblCheckIn
            // 
            lblCheckIn.AutoSize = true;
            lblCheckIn.Location = new Point(13, 65);
            lblCheckIn.Name = "lblCheckIn";
            lblCheckIn.Size = new Size(75, 21);
            lblCheckIn.TabIndex = 1;
            lblCheckIn.Text = "CheckIn";
            // 
            // dgvReservationHandler
            // 
            dgvReservationHandler.BackgroundColor = SystemColors.ButtonFace;
            dgvReservationHandler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReservationHandler.Location = new Point(419, 46);
            dgvReservationHandler.Name = "dgvReservationHandler";
            dgvReservationHandler.RowTemplate.Height = 25;
            dgvReservationHandler.Size = new Size(427, 273);
            dgvReservationHandler.TabIndex = 6;
            dgvReservationHandler.DoubleClick += dgvReservationHandler_DoubleClick;
            // 
            // lblReservationsDgv
            // 
            lblReservationsDgv.AutoSize = true;
            lblReservationsDgv.Font = new Font("Arial Black", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lblReservationsDgv.Location = new Point(419, 15);
            lblReservationsDgv.Name = "lblReservationsDgv";
            lblReservationsDgv.Size = new Size(78, 28);
            lblReservationsDgv.TabIndex = 7;
            lblReservationsDgv.Text = "label1";
            // 
            // FrmReservationHandler
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1007, 451);
            Controls.Add(lblReservationsDgv);
            Controls.Add(dgvReservationHandler);
            Controls.Add(grbReservationData);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "FrmReservationHandler";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu Edicion Reservaciones";
            FormClosing += FrmReservationHandler_FormClosing;
            Load += FrmReservationHandler_Load;
            grbReservationData.ResumeLayout(false);
            grbReservationData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReservationHandler).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnUpdateReservation;
        private GroupBox grbReservationData;
        private TextBox txtRoomNumber;
        private Label lblRoomNumber;
        private Label lblCheckOut;
        private Label lblCheckIn;
        private DateTimePicker dtpCheckOut;
        private DateTimePicker dtpCheckIn;
        private DataGridView dgvReservationHandler;
        private Label lblReservationsDgv;
        private Button btnDelete;
    }
}