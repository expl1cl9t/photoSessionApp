namespace photoSessionApp
{
    partial class timetableNextDayForn
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
            this.tableGrid = new System.Windows.Forms.DataGridView();
            this.shops_text = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tableGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tableGrid
            // 
            this.tableGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableGrid.Location = new System.Drawing.Point(12, 71);
            this.tableGrid.Name = "tableGrid";
            this.tableGrid.ReadOnly = true;
            this.tableGrid.RowTemplate.Height = 25;
            this.tableGrid.Size = new System.Drawing.Size(762, 288);
            this.tableGrid.TabIndex = 0;
            this.tableGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // shops_text
            // 
            this.shops_text.FormattingEnabled = true;
            this.shops_text.Location = new System.Drawing.Point(12, 32);
            this.shops_text.Name = "shops_text";
            this.shops_text.Size = new System.Drawing.Size(121, 23);
            this.shops_text.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(147, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Получить расписание";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timetableNextDayForn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.shops_text);
            this.Controls.Add(this.tableGrid);
            this.Name = "timetableNextDayForn";
            this.Text = "timetableNextDayForn";
            this.Load += new System.EventHandler(this.timetableNextDayForn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tableGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView tableGrid;
        private ComboBox shops_text;
        private Button button1;
    }
}