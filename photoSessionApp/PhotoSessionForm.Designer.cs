namespace photoSessionApp
{
    partial class PhotoSessionForm
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
            this.time_picker = new System.Windows.Forms.DateTimePicker();
            this.time_text = new System.Windows.Forms.Label();
            this.description_text = new System.Windows.Forms.TextBox();
            this.datePicker = new System.Windows.Forms.MonthCalendar();
            this.email_text = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.shops_text = new System.Windows.Forms.ComboBox();
            this.phone_number_text = new System.Windows.Forms.TextBox();
            this.fname_text = new System.Windows.Forms.TextBox();
            this.name_text = new System.Windows.Forms.TextBox();
            this.surname_text = new System.Windows.Forms.TextBox();
            this.dateLabel = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // time_picker
            // 
            this.time_picker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.time_picker.Location = new System.Drawing.Point(214, 293);
            this.time_picker.Name = "time_picker";
            this.time_picker.Size = new System.Drawing.Size(200, 23);
            this.time_picker.TabIndex = 32;
            this.time_picker.ValueChanged += new System.EventHandler(this.time_picker_ValueChanged);
            // 
            // time_text
            // 
            this.time_text.AutoSize = true;
            this.time_text.Location = new System.Drawing.Point(279, 262);
            this.time_text.Name = "time_text";
            this.time_text.Size = new System.Drawing.Size(114, 15);
            this.time_text.TabIndex = 31;
            this.time_text.Text = "Время фотосессии:";
            // 
            // description_text
            // 
            this.description_text.Location = new System.Drawing.Point(12, 98);
            this.description_text.Multiline = true;
            this.description_text.Name = "description_text";
            this.description_text.Size = new System.Drawing.Size(265, 104);
            this.description_text.TabIndex = 30;
            this.description_text.Text = "Описание заказа";
            this.description_text.TextChanged += new System.EventHandler(this.description_text_TextChanged);
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(11, 293);
            this.datePicker.Name = "datePicker";
            this.datePicker.TabIndex = 29;
            this.datePicker.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.datePicker_DateSelected_1);
            // 
            // email_text
            // 
            this.email_text.Location = new System.Drawing.Point(149, 60);
            this.email_text.Name = "email_text";
            this.email_text.Size = new System.Drawing.Size(120, 23);
            this.email_text.TabIndex = 28;
            this.email_text.Text = "Электронная почта";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 467);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 27;
            this.button1.Text = "Отправить заявку";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 15);
            this.label1.TabIndex = 26;
            this.label1.Text = "Дата фотосессии:";
            // 
            // shops_text
            // 
            this.shops_text.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shops_text.FormattingEnabled = true;
            this.shops_text.Location = new System.Drawing.Point(12, 224);
            this.shops_text.Name = "shops_text";
            this.shops_text.Size = new System.Drawing.Size(163, 23);
            this.shops_text.TabIndex = 25;
            this.shops_text.SelectedIndexChanged += new System.EventHandler(this.shops_text_SelectedIndexChanged);
            // 
            // phone_number_text
            // 
            this.phone_number_text.Location = new System.Drawing.Point(11, 60);
            this.phone_number_text.Name = "phone_number_text";
            this.phone_number_text.Size = new System.Drawing.Size(120, 23);
            this.phone_number_text.TabIndex = 24;
            this.phone_number_text.Text = "Телефон";
            // 
            // fname_text
            // 
            this.fname_text.Location = new System.Drawing.Point(292, 9);
            this.fname_text.Name = "fname_text";
            this.fname_text.Size = new System.Drawing.Size(122, 23);
            this.fname_text.TabIndex = 23;
            this.fname_text.Text = "Отчество";
            // 
            // name_text
            // 
            this.name_text.Location = new System.Drawing.Point(149, 9);
            this.name_text.Name = "name_text";
            this.name_text.Size = new System.Drawing.Size(126, 23);
            this.name_text.TabIndex = 22;
            this.name_text.Text = "Имя";
            // 
            // surname_text
            // 
            this.surname_text.Location = new System.Drawing.Point(11, 9);
            this.surname_text.Name = "surname_text";
            this.surname_text.Size = new System.Drawing.Size(120, 23);
            this.surname_text.TabIndex = 21;
            this.surname_text.Text = "Фамилия";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(122, 261);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(0, 15);
            this.dateLabel.TabIndex = 33;
            this.dateLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(654, 69);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(121, 53);
            this.button3.TabIndex = 35;
            this.button3.Text = "Открыть окно администратора";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(654, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 54);
            this.button2.TabIndex = 34;
            this.button2.Text = "Открыть форму записи печать";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // PhotoSessionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 509);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.time_picker);
            this.Controls.Add(this.time_text);
            this.Controls.Add(this.description_text);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.email_text);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shops_text);
            this.Controls.Add(this.phone_number_text);
            this.Controls.Add(this.fname_text);
            this.Controls.Add(this.name_text);
            this.Controls.Add(this.surname_text);
            this.Name = "PhotoSessionForm";
            this.Text = "Расписание на завтра";
            this.Load += new System.EventHandler(this.PhotoSessionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DateTimePicker time_picker;
        private Label time_text;
        private TextBox description_text;
        private MonthCalendar datePicker;
        private TextBox email_text;
        private Button button1;
        private Label label1;
        private ComboBox shops_text;
        private TextBox phone_number_text;
        private TextBox fname_text;
        private TextBox name_text;
        private TextBox surname_text;
        private Label dateLabel;
        private Button button3;
        private Button button2;
    }
}