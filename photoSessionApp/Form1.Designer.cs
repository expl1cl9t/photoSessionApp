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
            this.photoService_text = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.selectedPicture = new System.Windows.Forms.PictureBox();
            this.email_text = new System.Windows.Forms.TextBox();
            this.datePicker = new System.Windows.Forms.MonthCalendar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.time_text = new System.Windows.Forms.Label();
            this.numberOfPhotos = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.selectedPicture)).BeginInit();
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
            this.print_format_text.FormattingEnabled = true;
            this.print_format_text.Location = new System.Drawing.Point(11, 117);
            this.print_format_text.Name = "print_format_text";
            this.print_format_text.Size = new System.Drawing.Size(121, 23);
            this.print_format_text.TabIndex = 4;
            // 
            // paper_type_text
            // 
            this.paper_type_text.FormattingEnabled = true;
            this.paper_type_text.Location = new System.Drawing.Point(11, 156);
            this.paper_type_text.Name = "paper_type_text";
            this.paper_type_text.Size = new System.Drawing.Size(121, 23);
            this.paper_type_text.TabIndex = 5;
            // 
            // photo_type_text
            // 
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
            // photoService_text
            // 
            this.photoService_text.FormattingEnabled = true;
            this.photoService_text.Location = new System.Drawing.Point(12, 276);
            this.photoService_text.Name = "photoService_text";
            this.photoService_text.Size = new System.Drawing.Size(121, 23);
            this.photoService_text.TabIndex = 9;
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
            // selectedPicture
            // 
            this.selectedPicture.Location = new System.Drawing.Point(470, 2);
            this.selectedPicture.Name = "selectedPicture";
            this.selectedPicture.Size = new System.Drawing.Size(331, 239);
            this.selectedPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.selectedPicture.TabIndex = 14;
            this.selectedPicture.TabStop = false;
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(150, 117);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(265, 104);
            this.textBox1.TabIndex = 17;
            this.textBox1.Text = "Описание заказа";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 560);
            this.Controls.Add(this.numberOfPhotos);
            this.Controls.Add(this.time_text);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.email_text);
            this.Controls.Add(this.selectedPicture);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.photoService_text);
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
            ((System.ComponentModel.ISupportInitialize)(this.selectedPicture)).EndInit();
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
        private ComboBox photoService_text;
        private Label label1;
        private Label dateLabel;
        private Button button1;
        private PictureBox selectedPicture;
        private TextBox email_text;
        private MonthCalendar datePicker;
        private TextBox textBox1;
        private Label time_text;
        private TextBox numberOfPhotos;
    }
}