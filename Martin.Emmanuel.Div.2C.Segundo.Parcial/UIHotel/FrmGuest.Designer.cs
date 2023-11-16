namespace UIHotel
{
    partial class FrmGuest
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
            grbGuestData = new GroupBox();
            txtName = new TextBox();
            txtPhoneNumber = new TextBox();
            txtLastName = new TextBox();
            txtDni = new TextBox();
            lblPhoneNumber = new Label();
            lblLastName = new Label();
            lblName = new Label();
            lblDni = new Label();
            btnRegisterGuest = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            btnDeleteGuest = new Button();
            dgvGuestsHandler = new DataGridView();
            btnModifyGuest = new Button();
            lblGuestDgv = new Label();
            grbGuestData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGuestsHandler).BeginInit();
            SuspendLayout();
            // 
            // grbGuestData
            // 
            grbGuestData.Controls.Add(txtName);
            grbGuestData.Controls.Add(txtPhoneNumber);
            grbGuestData.Controls.Add(txtLastName);
            grbGuestData.Controls.Add(txtDni);
            grbGuestData.Controls.Add(lblPhoneNumber);
            grbGuestData.Controls.Add(lblLastName);
            grbGuestData.Controls.Add(lblName);
            grbGuestData.Controls.Add(lblDni);
            grbGuestData.Font = new Font("Arial", 13F, FontStyle.Regular, GraphicsUnit.Point);
            grbGuestData.Location = new Point(47, 30);
            grbGuestData.Name = "grbGuestData";
            grbGuestData.Size = new Size(319, 284);
            grbGuestData.TabIndex = 2;
            grbGuestData.TabStop = false;
            grbGuestData.Text = "Datos Huesped";
            // 
            // txtName
            // 
            txtName.Location = new Point(132, 116);
            txtName.Name = "txtName";
            txtName.Size = new Size(163, 27);
            txtName.TabIndex = 7;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(132, 237);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(163, 27);
            txtPhoneNumber.TabIndex = 6;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(132, 171);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(163, 27);
            txtLastName.TabIndex = 5;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(132, 56);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(163, 27);
            txtDni.TabIndex = 4;
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Location = new Point(13, 240);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(113, 21);
            lblPhoneNumber.TabIndex = 3;
            lblPhoneNumber.Text = "Nro Telefono";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(13, 177);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(73, 21);
            lblLastName.TabIndex = 2;
            lblLastName.Text = "Apellido";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(13, 116);
            lblName.Name = "lblName";
            lblName.Size = new Size(73, 21);
            lblName.TabIndex = 1;
            lblName.Text = "Nombre";
            // 
            // lblDni
            // 
            lblDni.AutoSize = true;
            lblDni.Location = new Point(13, 62);
            lblDni.Name = "lblDni";
            lblDni.Size = new Size(45, 21);
            lblDni.TabIndex = 0;
            lblDni.Text = "DNI ";
            // 
            // btnRegisterGuest
            // 
            btnRegisterGuest.Font = new Font("Arial", 13F, FontStyle.Regular, GraphicsUnit.Point);
            btnRegisterGuest.Location = new Point(25, 338);
            btnRegisterGuest.Name = "btnRegisterGuest";
            btnRegisterGuest.Size = new Size(108, 42);
            btnRegisterGuest.TabIndex = 3;
            btnRegisterGuest.Text = "Guardar";
            btnRegisterGuest.UseVisualStyleBackColor = true;
            btnRegisterGuest.Click += btnRegisterGuest_Click;
            // 
            // btnDeleteGuest
            // 
            btnDeleteGuest.Font = new Font("Arial", 13F, FontStyle.Regular, GraphicsUnit.Point);
            btnDeleteGuest.Location = new Point(170, 338);
            btnDeleteGuest.Name = "btnDeleteGuest";
            btnDeleteGuest.Size = new Size(108, 42);
            btnDeleteGuest.TabIndex = 4;
            btnDeleteGuest.Text = "Eliminar";
            btnDeleteGuest.UseVisualStyleBackColor = true;
            btnDeleteGuest.Click += btnDeleteGuest_Click;
            // 
            // dgvGuestsHandler
            // 
            dgvGuestsHandler.BackgroundColor = SystemColors.ButtonFace;
            dgvGuestsHandler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGuestsHandler.Location = new Point(450, 39);
            dgvGuestsHandler.Name = "dgvGuestsHandler";
            dgvGuestsHandler.RowTemplate.Height = 25;
            dgvGuestsHandler.Size = new Size(451, 275);
            dgvGuestsHandler.TabIndex = 5;
            dgvGuestsHandler.DoubleClick += dgbGuestsHandler_DoubleClick;
            // 
            // btnModifyGuest
            // 
            btnModifyGuest.Font = new Font("Arial", 13F, FontStyle.Regular, GraphicsUnit.Point);
            btnModifyGuest.Location = new Point(325, 338);
            btnModifyGuest.Name = "btnModifyGuest";
            btnModifyGuest.Size = new Size(108, 42);
            btnModifyGuest.TabIndex = 6;
            btnModifyGuest.Text = "Modificar";
            btnModifyGuest.UseVisualStyleBackColor = true;
            btnModifyGuest.Click += btnModifyGuest_Click;
            // 
            // lblGuestDgv
            // 
            lblGuestDgv.AutoSize = true;
            lblGuestDgv.Font = new Font("Arial Black", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblGuestDgv.Location = new Point(450, 9);
            lblGuestDgv.Name = "lblGuestDgv";
            lblGuestDgv.Size = new Size(76, 27);
            lblGuestDgv.TabIndex = 7;
            lblGuestDgv.Text = "label1";
            // 
            // FrmGuest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(923, 425);
            Controls.Add(lblGuestDgv);
            Controls.Add(btnModifyGuest);
            Controls.Add(dgvGuestsHandler);
            Controls.Add(btnDeleteGuest);
            Controls.Add(btnRegisterGuest);
            Controls.Add(grbGuestData);
            MinimizeBox = false;
            Name = "FrmGuest";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu Resgitro Huesped en Sistema";
            FormClosing += FrmGuestRegister_FormClosing;
            Load += FrmGuestRegister_Load;
            grbGuestData.ResumeLayout(false);
            grbGuestData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGuestsHandler).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grbGuestData;
        private TextBox txtName;
        private TextBox txtPhoneNumber;
        private TextBox txtLastName;
        private TextBox txtDni;
        private Label lblPhoneNumber;
        private Label lblLastName;
        private Label lblName;
        private Label lblDni;
        private Button btnRegisterGuest;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button btnDeleteGuest;
        private DataGridView dgvGuestsHandler;
        private Button btnModifyGuest;
        private Label lblGuestDgv;
    }
}