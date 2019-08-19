namespace WindowsFormsTestGoogle
{
    partial class PlayerForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelAddName = new System.Windows.Forms.Label();
            this.labelPassClienta = new System.Windows.Forms.Label();
            this.labelTelefonClienta = new System.Windows.Forms.Label();
            this.textBoxNameClient = new System.Windows.Forms.TextBox();
            this.textBoxPassClient = new System.Windows.Forms.TextBox();
            this.textBoxTelefonClienta = new System.Windows.Forms.TextBox();
            this.checkBoxArenda = new System.Windows.Forms.CheckBox();
            this.checkBoxArendaEvolaina = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelDateTime = new System.Windows.Forms.Label();
            this.textBoxDatetime = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(195, 352);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "ОК";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(290, 352);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 29);
            this.button2.TabIndex = 1;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxDatetime);
            this.panel1.Controls.Add(this.labelDateTime);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.checkBoxArendaEvolaina);
            this.panel1.Controls.Add(this.checkBoxArenda);
            this.panel1.Controls.Add(this.textBoxTelefonClienta);
            this.panel1.Controls.Add(this.textBoxPassClient);
            this.panel1.Controls.Add(this.textBoxNameClient);
            this.panel1.Controls.Add(this.labelTelefonClienta);
            this.panel1.Controls.Add(this.labelPassClienta);
            this.panel1.Controls.Add(this.labelAddName);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(12, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 395);
            this.panel1.TabIndex = 2;
            // 
            // labelAddName
            // 
            this.labelAddName.AutoSize = true;
            this.labelAddName.Location = new System.Drawing.Point(20, 33);
            this.labelAddName.Name = "labelAddName";
            this.labelAddName.Size = new System.Drawing.Size(93, 17);
            this.labelAddName.TabIndex = 2;
            this.labelAddName.Text = "Имя клиента";
            // 
            // labelPassClienta
            // 
            this.labelPassClienta.AutoSize = true;
            this.labelPassClienta.Location = new System.Drawing.Point(20, 103);
            this.labelPassClienta.Name = "labelPassClienta";
            this.labelPassClienta.Size = new System.Drawing.Size(115, 17);
            this.labelPassClienta.TabIndex = 3;
            this.labelPassClienta.Text = "Пароль клиента";
            // 
            // labelTelefonClienta
            // 
            this.labelTelefonClienta.AutoSize = true;
            this.labelTelefonClienta.Location = new System.Drawing.Point(20, 173);
            this.labelTelefonClienta.Name = "labelTelefonClienta";
            this.labelTelefonClienta.Size = new System.Drawing.Size(126, 17);
            this.labelTelefonClienta.TabIndex = 4;
            this.labelTelefonClienta.Text = "Телефон клиента";
            // 
            // textBoxNameClient
            // 
            this.textBoxNameClient.Location = new System.Drawing.Point(151, 33);
            this.textBoxNameClient.Name = "textBoxNameClient";
            this.textBoxNameClient.Size = new System.Drawing.Size(164, 22);
            this.textBoxNameClient.TabIndex = 5;
            // 
            // textBoxPassClient
            // 
            this.textBoxPassClient.Location = new System.Drawing.Point(151, 100);
            this.textBoxPassClient.Name = "textBoxPassClient";
            this.textBoxPassClient.Size = new System.Drawing.Size(164, 22);
            this.textBoxPassClient.TabIndex = 6;
            // 
            // textBoxTelefonClienta
            // 
            this.textBoxTelefonClienta.Location = new System.Drawing.Point(151, 170);
            this.textBoxTelefonClienta.Name = "textBoxTelefonClienta";
            this.textBoxTelefonClienta.Size = new System.Drawing.Size(164, 22);
            this.textBoxTelefonClienta.TabIndex = 7;
            // 
            // checkBoxArenda
            // 
            this.checkBoxArenda.AutoSize = true;
            this.checkBoxArenda.Location = new System.Drawing.Point(18, 240);
            this.checkBoxArenda.Name = "checkBoxArenda";
            this.checkBoxArenda.Size = new System.Drawing.Size(79, 21);
            this.checkBoxArenda.TabIndex = 8;
            this.checkBoxArenda.Text = "Аренда";
            this.checkBoxArenda.UseVisualStyleBackColor = true;
            // 
            // checkBoxArendaEvolaina
            // 
            this.checkBoxArendaEvolaina.AutoSize = true;
            this.checkBoxArendaEvolaina.Location = new System.Drawing.Point(123, 240);
            this.checkBoxArendaEvolaina.Name = "checkBoxArendaEvolaina";
            this.checkBoxArendaEvolaina.Size = new System.Drawing.Size(147, 21);
            this.checkBoxArendaEvolaina.TabIndex = 9;
            this.checkBoxArendaEvolaina.Text = "Аренда Эволайна";
            this.checkBoxArendaEvolaina.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 10;
            // 
            // labelDateTime
            // 
            this.labelDateTime.AutoSize = true;
            this.labelDateTime.Location = new System.Drawing.Point(20, 210);
            this.labelDateTime.Name = "labelDateTime";
            this.labelDateTime.Size = new System.Drawing.Size(112, 17);
            this.labelDateTime.TabIndex = 11;
            this.labelDateTime.Text = "Дата создания:";
            this.labelDateTime.Visible = false;
            // 
            // textBoxDatetime
            // 
            this.textBoxDatetime.Location = new System.Drawing.Point(151, 212);
            this.textBoxDatetime.Name = "textBoxDatetime";
            this.textBoxDatetime.Size = new System.Drawing.Size(164, 22);
            this.textBoxDatetime.TabIndex = 12;
            this.textBoxDatetime.Visible = false;
            // 
            // PlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 428);
            this.Controls.Add(this.panel1);
            this.Name = "PlayerForm";
            this.Text = "PlayerForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelTelefonClienta;
        private System.Windows.Forms.Label labelPassClienta;
        private System.Windows.Forms.Label labelAddName;
        public System.Windows.Forms.TextBox textBoxNameClient;
        public System.Windows.Forms.TextBox textBoxPassClient;
        public System.Windows.Forms.TextBox textBoxTelefonClienta;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBoxDatetime;
        public System.Windows.Forms.Label labelDateTime;
        public System.Windows.Forms.CheckBox checkBoxArendaEvolaina;
        public System.Windows.Forms.CheckBox checkBoxArenda;
    }
}