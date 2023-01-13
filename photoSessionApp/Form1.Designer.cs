namespace photoSessionApp
{
    partial class Form1
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
            this.surname_text = new System.Windows.Forms.TextBox();
            this.name_text = new System.Windows.Forms.TextBox();
            this.fname_text = new System.Windows.Forms.TextBox();
            this.phone_number_text = new System.Windows.Forms.TextBox();
            this.print_format_text = new System.Windows.Forms.ComboBox();
            this.paper_type_text = new System.Windows.Forms.ComboBox();
            this.photo_type_text = new System.Windows.Forms.ComboBox();
            this.choicePhoto = new System.Windows.Forms.Button();
            this.file_name_text = new System.Windows.Forms.Label();
            this.shops_text = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.email_text = new System.Windows.Forms.TextBox();
            this.datePicker = new System.Windows.Forms.MonthCalendar();
            this.description_text = new System.Windows.Forms.TextBox();
            this.time_text = new System.Windows.Forms.Label();
            this.numberOfPhotos = new System.Windows.Forms.TextBox();
            this.time_picker = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // surname_text
            // 
            this.surname_text.Location = new System.Drawing.Point(12, 27);
            this.surname_text.Name = "surname_text";
            this.surname_text.Size = new System.Drawing.Size(120, 23);
            this.surname_text.TabIndex = 0;
            this.surname_text.Text = "Фамилия";
            // 
            // name_text
            // 
            this.name_text.Location = new System.Drawing.Point(150, 27);
            this.name_text.Name = "name_text";
            this.name_text.Size = new System.Drawing.Size(126, 23);
            this.name_text.TabIndex = 1;
            this.name_text.Text = "Имя";
            // 
            // fname_text
            // 
            this.fname_text.Location = new System.Drawing.Point(293, 27);
            this.fname_text.Name = "fname_text";
            this.fname_text.Size = new System.Drawing.Size(122, 23);
            this.fname_text.TabIndex = 2;
            this.fname_text.Text = "Отчество";
            // 
            // phone_number_text
            // 
            this.phone_number_text.Location = new System.Drawing.Point(12, 78);
            this.phone_number_text.Name = "phone_number_text";
            this.phone_number_text.Size = new System.Drawing.Size(120, 23);
            this.phone_number_text.TabIndex = 3;
            this.phone_number_text.Text = "Телефон";
            // 
            // print_format_text
            // 
            this.print_format_text.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.print_format_text.FormattingEnabled = true;
            this.print_format_text.Location = new System.Drawing.Point(11, 117);
            this.print_format_text.Name = "print_format_text";
            this.print_format_text.Size = new System.Drawing.Size(121, 23);
            this.print_format_text.TabIndex = 4;
            // 
            // paper_type_text
            // 
            this.paper_type_text.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.paper_type_text.FormattingEnabled = true;
            this.paper_type_text.Location = new System.Drawing.Point(11, 156);
            this.paper_type_text.Name = "paper_type_text";
            this.paper_type_text.Size = new System.Drawing.Size(121, 23);
            this.paper_type_text.TabIndex = 5;
            // 
            // photo_type_text
            // 
            this.photo_type_text.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.photo_type_text.FormattingEnabled = true;
            this.photo_type_text.Location = new System.Drawing.Point(12, 198);
            this.photo_type_text.Name = "photo_type_text";
            this.photo_type_text.Size = new System.Drawing.Size(121, 23);
            this.photo_type_text.TabIndex = 6;
            // 
            // choicePhoto
            // 
            this.choicePhoto.Location = new System.Drawing.Point(12, 237);
            this.choicePhoto.Name = "choicePhoto";
            this.choicePhoto.Size = new System.Drawing.Size(121, 23);
            this.choicePhoto.TabIndex = 7;
            this.choicePhoto.Text = "Выбрать фото";
            this.choicePhoto.UseVisualStyleBackColor = true;
            this.choicePhoto.Click += new System.EventHandler(this.choicePhoto_Click);
            // 
            // file_name_text
            // 
            this.file_name_text.AutoSize = true;
            this.file_name_text.Location = new System.Drawing.Point(150, 241);
            this.file_name_text.Name = "file_name_text";
            this.file_name_text.Size = new System.Drawing.Size(140, 15);
            this.file_name_text.TabIndex = 8;
            this.file_name_text.Text = "Имя выбранного файла";
            // 
            // shops_text
            // 
            this.shops_text.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shops_text.FormattingEnabled = true;
            this.shops_text.Location = new System.Drawing.Point(12, 276);
            this.shops_text.Name = "shops_text";
            this.shops_text.Size = new System.Drawing.Size(163, 23);
            this.shops_text.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 311);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Дата печати:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(122, 311);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(0, 15);
            this.dateLabel.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 509);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Отправить заявку";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // email_text
            // 
            this.email_text.Location = new System.Drawing.Point(150, 78);
            this.email_text.Name = "email_text";
            this.email_text.Size = new System.Drawing.Size(120, 23);
            this.email_text.TabIndex = 15;
            this.email_text.Text = "Электронная почта";
            this.email_text.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(11, 335);
            this.datePicker.Name = "datePicker";
            this.datePicker.TabIndex = 16;
            this.datePicker.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.datePicker_DateSelected);
            // 
            // description_text
            // 
            this.description_text.Location = new System.Drawing.Point(150, 117);
            this.description_text.Multiline = true;
            this.description_text.Name = "description_text";
            this.description_text.Size = new System.Drawing.Size(265, 104);
            this.description_text.TabIndex = 17;
            this.description_text.Text = "Описание заказа";
            // 
            // time_text
            // 
            this.time_text.AutoSize = true;
            this.time_text.Location = new System.Drawing.Point(277, 311);
            this.time_text.Name = "time_text";
            this.time_text.Size = new System.Drawing.Size(86, 15);
            this.time_text.TabIndex = 18;
            this.time_text.Text = "Время печати:";
            // 
            // numberOfPhotos
            // 
            this.numberOfPhotos.Location = new System.Drawing.Point(293, 78);
            this.numberOfPhotos.Name = "numberOfPhotos";
            this.numberOfPhotos.Size = new System.Drawing.Size(122, 23);
            this.numberOfPhotos.TabIndex = 19;
            this.numberOfPhotos.Text = "Количество фотографий";
            this.numberOfPhotos.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // time_picker
            // 
            this.time_picker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.time_picker.Location = new System.Drawing.Point(215, 335);
            this.time_picker.Name = "time_picker";
            this.time_picker.Size = new System.Drawing.Size(200, 23);
            this.time_picker.TabIndex = 20;
            this.time_picker.Leave += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(685, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 54);
            this.button2.TabIndex = 21;
            this.button2.Text = "Открыть форму записи на фотосессию";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(685, 87);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(121, 53);
            this.button3.TabIndex = 22;
            this.button3.Text = "Открыть окно администратора";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 560);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.time_picker);
            this.Controls.Add(this.numberOfPhotos);
            this.Controls.Add(this.time_text);
            this.Controls.Add(this.description_text);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.email_text);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shops_text);
            this.Controls.Add(this.file_name_text);
            this.Controls.Add(this.choicePhoto);
            this.Controls.Add(this.photo_type_text);
            this.Controls.Add(this.paper_type_text);
            this.Controls.Add(this.print_format_text);
            this.Controls.Add(this.phone_number_text);
            this.Controls.Add(this.fname_text);
            this.Controls.Add(this.name_text);
            this.Controls.Add(this.surname_text);
            this.Name = "Form1";
            this.Text = "Запись на печать";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox surname_text;
        private TextBox name_text;
        private TextBox fname_text;
        private TextBox phone_number_text;
        private ComboBox print_format_text;
        private ComboBox paper_type_text;
        private ComboBox photo_type_text;
        private Button choicePhoto;
        private Label file_name_text;
        private ComboBox shops_text;
        private Label label1;
        private Label dateLabel;
        private Button button1;
        private TextBox email_text;
        private MonthCalendar datePicker;
        private TextBox description_text;
        private Label time_text;
        private TextBox numberOfPhotos;
        private DateTimePicker time_picker;
        private Button button2;
        private Button button3;
    }
}