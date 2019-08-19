namespace WindowsFormsTestGoogle
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.labelCInfo = new System.Windows.Forms.Label();
            this.labelCauntClient = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tablGoogleContextBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tablGoogleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameClientaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passClientDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefonClientDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataTimeAddTableDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablGoogleContextBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablGoogleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.labelCauntClient);
            this.panel1.Controls.Add(this.labelCInfo);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(871, 469);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(759, 420);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 419);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 37);
            this.button2.TabIndex = 1;
            this.button2.Text = "Обновить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // labelCInfo
            // 
            this.labelCInfo.AutoSize = true;
            this.labelCInfo.Location = new System.Drawing.Point(14, 13);
            this.labelCInfo.Name = "labelCInfo";
            this.labelCInfo.Size = new System.Drawing.Size(155, 17);
            this.labelCInfo.TabIndex = 2;
            this.labelCInfo.Text = "Количество клиентов:";
            // 
            // labelCauntClient
            // 
            this.labelCauntClient.AutoSize = true;
            this.labelCauntClient.Location = new System.Drawing.Point(176, 13);
            this.labelCauntClient.Name = "labelCauntClient";
            this.labelCauntClient.Size = new System.Drawing.Size(46, 17);
            this.labelCauntClient.TabIndex = 3;
            this.labelCauntClient.Text = "label1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(13, 50);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(834, 306);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(826, 277);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Все клиенты";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(595, 235);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(603, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(138, 22);
            this.textBox1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(524, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Поиск";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameClientaDataGridViewTextBoxColumn,
            this.passClientDataGridViewTextBoxColumn,
            this.telefonClientDataGridViewTextBoxColumn,
            this.dataTimeAddTableDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tablGoogleBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(6, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(814, 261);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(ConsoleApp.Model.User);
            // 
            // tablGoogleContextBindingSource
            // 
            this.tablGoogleContextBindingSource.DataSource = typeof(ConsoleApp.TablGoogleContext);
            // 
            // tablGoogleBindingSource
            // 
            this.tablGoogleBindingSource.DataSource = typeof(ConsoleApp.Model.TablGoogle);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(759, 25);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 29);
            this.button3.TabIndex = 7;
            this.button3.Text = "ОК";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(17, 348);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(184, 26);
            this.button4.TabIndex = 8;
            this.button4.Text = "Показать всех клиентов";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Width = 30;
            // 
            // nameClientaDataGridViewTextBoxColumn
            // 
            this.nameClientaDataGridViewTextBoxColumn.DataPropertyName = "NameClienta";
            this.nameClientaDataGridViewTextBoxColumn.HeaderText = "NameClienta";
            this.nameClientaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nameClientaDataGridViewTextBoxColumn.Name = "nameClientaDataGridViewTextBoxColumn";
            this.nameClientaDataGridViewTextBoxColumn.Width = 125;
            // 
            // passClientDataGridViewTextBoxColumn
            // 
            this.passClientDataGridViewTextBoxColumn.DataPropertyName = "PassClient";
            this.passClientDataGridViewTextBoxColumn.HeaderText = "PassClient";
            this.passClientDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.passClientDataGridViewTextBoxColumn.Name = "passClientDataGridViewTextBoxColumn";
            this.passClientDataGridViewTextBoxColumn.Width = 125;
            // 
            // telefonClientDataGridViewTextBoxColumn
            // 
            this.telefonClientDataGridViewTextBoxColumn.DataPropertyName = "TelefonClient";
            this.telefonClientDataGridViewTextBoxColumn.HeaderText = "TelefonClient";
            this.telefonClientDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.telefonClientDataGridViewTextBoxColumn.Name = "telefonClientDataGridViewTextBoxColumn";
            this.telefonClientDataGridViewTextBoxColumn.Width = 125;
            // 
            // dataTimeAddTableDataGridViewTextBoxColumn
            // 
            this.dataTimeAddTableDataGridViewTextBoxColumn.DataPropertyName = "DataTimeAddTable";
            this.dataTimeAddTableDataGridViewTextBoxColumn.HeaderText = "DataTimeAddTable";
            this.dataTimeAddTableDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.dataTimeAddTableDataGridViewTextBoxColumn.Name = "dataTimeAddTableDataGridViewTextBoxColumn";
            this.dataTimeAddTableDataGridViewTextBoxColumn.Width = 125;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 493);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablGoogleContextBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablGoogleBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label labelCauntClient;
        private System.Windows.Forms.Label labelCInfo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource tablGoogleBindingSource;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.BindingSource tablGoogleContextBindingSource;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameClientaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passClientDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefonClientDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataTimeAddTableDataGridViewTextBoxColumn;
    }
}

