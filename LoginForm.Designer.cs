namespace SistemaAuditoria
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtserver = new TextBox();
            txtuser = new TextBox();
            txtpassword = new TextBox();
            IngresaButton = new Button();
            label3 = new Label();
            txtBase = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(114, 31);
            label1.TabIndex = 2;
            // 
            // label2
            // 
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(114, 31);
            label2.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(150, 80);
            label4.Name = "label4";
            label4.Size = new Size(71, 28);
            label4.TabIndex = 3;
            label4.Text = "Server:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(150, 230);
            label5.Name = "label5";
            label5.Size = new Size(83, 28);
            label5.TabIndex = 4;
            label5.Text = "Usuario:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(150, 307);
            label6.Name = "label6";
            label6.Size = new Size(114, 28);
            label6.TabIndex = 5;
            label6.Text = "Contraseña:";
            // 
            // txtserver
            // 
            txtserver.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtserver.Location = new Point(280, 77);
            txtserver.Margin = new Padding(3, 4, 3, 4);
            txtserver.Name = "txtserver";
            txtserver.PlaceholderText = "Ingresa el server";
            txtserver.Size = new Size(208, 34);
            txtserver.TabIndex = 6;
            // 
            // txtuser
            // 
            txtuser.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtuser.Location = new Point(282, 224);
            txtuser.Margin = new Padding(3, 4, 3, 4);
            txtuser.Name = "txtuser";
            txtuser.PlaceholderText = "Ingrese el usuario";
            txtuser.Size = new Size(206, 34);
            txtuser.TabIndex = 7;
            // 
            // txtpassword
            // 
            txtpassword.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtpassword.Location = new Point(280, 301);
            txtpassword.Margin = new Padding(3, 4, 3, 4);
            txtpassword.Name = "txtpassword";
            txtpassword.PasswordChar = '*';
            txtpassword.PlaceholderText = "Ingrese la contraseña";
            txtpassword.Size = new Size(208, 34);
            txtpassword.TabIndex = 8;
            // 
            // IngresaButton
            // 
            IngresaButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            IngresaButton.Location = new Point(177, 383);
            IngresaButton.Margin = new Padding(3, 4, 3, 4);
            IngresaButton.Name = "IngresaButton";
            IngresaButton.Size = new Size(287, 55);
            IngresaButton.TabIndex = 9;
            IngresaButton.Text = "Iniciar Sesion";
            IngresaButton.UseVisualStyleBackColor = true;
            IngresaButton.Click += IngresaButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(150, 155);
            label3.Name = "label3";
            label3.Size = new Size(97, 28);
            label3.TabIndex = 10;
            label3.Text = "Database:";
            // 
            // textBox1
            // 
            txtBase.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBase.Location = new Point(280, 149);
            txtBase.Margin = new Padding(3, 4, 3, 4);
            txtBase.Name = "txtBase";
            txtBase.PlaceholderText = "Ingresa la database";
            txtBase.Size = new Size(208, 34);
            txtBase.TabIndex = 11;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(642, 544);
            Controls.Add(txtBase);
            Controls.Add(label3);
            Controls.Add(IngresaButton);
            Controls.Add(txtpassword);
            Controls.Add(txtuser);
            Controls.Add(txtserver);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "LoginForm";
            Text = "Form1";
            FormClosing += LoginForm_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtserver;
        private TextBox txtuser;
        private TextBox txtpassword;
        private Button IngresaButton;
        private TextBox txtBase;
    }
}
