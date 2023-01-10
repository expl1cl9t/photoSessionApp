using photoSessionApp.database;
using System.Data.SqlClient;

namespace photoSessionApp
{
    public partial class Form1 : Form
    {
        List<string> forbiddenDates= new List<string>();
        List<string> colorOfPaper = new List<string>();
        List<string> typeOfPaper = new List<string>();
        List<string> sizeOfPhoto = new List<string>();
        Image photoToPrint;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                DatabaseInfo info = new("Server=.\\SQLEXPRESS;Database=PhotoSession;Trusted_Connection=True;");
                var connection = info.getConnectionWithDataBase();
                await connection.OpenAsync();
                SqlCommand select = new SqlCommand("SELECT date FROM appointments", connection);
                SqlDataReader result = await select.ExecuteReaderAsync();
                if (result.HasRows)
                {
                    while (await result.ReadAsync())
                    {
                        forbiddenDates.Add(result.GetValue(0).ToString());
                    }
                }
                
                await connection.CloseAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            try
            {
                DatabaseInfo info1 = new("Server=.\\SQLEXPRESS;Database=PhotoSession;Trusted_Connection=True;");
                var connection1 = info1.getConnectionWithDataBase();
                await connection1.OpenAsync();
                SqlCommand select = new SqlCommand("SELECT variation_id,name FROM variation_option", connection1);
                SqlDataReader result = await select.ExecuteReaderAsync();
                if (result.HasRows)
                {
                    while (await result.ReadAsync())
                    {
                        switch (result.GetInt32(0))
                        {
                            case 1:
                                sizeOfPhoto.Add(result.GetValue(1).ToString());
                                break;
                            case 2: 
                                colorOfPaper.Add(result.GetValue(1).ToString());
                                break;
                            case 3:
                                typeOfPaper.Add(result.GetValue(1).ToString());
                                break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Данных не пришло");
                }
                print_format_text.DataSource = sizeOfPhoto;
                paper_type_text.DataSource = typeOfPaper;
                photo_type_text.DataSource = colorOfPaper;
                await connection1.CloseAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void choicePhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog= new OpenFileDialog();
            dialog.Filter = "Файлы изображений|*.bmp;*.png;*.jpg";
            if (dialog.ShowDialog() == DialogResult.Cancel) return;
            try
            {
                photoToPrint =Image.FromFile(dialog.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при добавлении картинки. Ошибка: {ex.Message}");
            }
            file_name_text.Text = dialog.FileName;
            selectedPicture.Image= photoToPrint;
        }

        private void datePicker_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (forbiddenDates.Exists(item => DateTime.Parse(item) == e.Start)){
                MessageBox.Show("Данная дата уже занята для фотосессии");
                datePicker.SetDate(DateTime.Now);
                dateLabel.Text = DateTime.Now.ToLongDateString();
            }
            else
            {
                dateLabel.Text = e.Start.ToLongDateString();
            }
            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            bool existsAccount = await checkIfClientExists();
            insertClientData(existsAccount);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private async Task<bool> checkIfClientExists()
        {
            DatabaseInfo info = new("Server=.\\SQLEXPRESS;Database=PhotoSession;Trusted_Connection=True;");
            var connection = info.getConnectionWithDataBase();
            bool isHaveExistingAccount = false;
            await connection.OpenAsync();
            try
            {
                SqlCommand existingUsers = new SqlCommand($"SELECT * FROM clients WHERE email = '{email_text.Text}' OR phone_number = '{phone_number_text.Text}'", connection);
                var existing = await existingUsers.ExecuteReaderAsync();
                isHaveExistingAccount = existing.HasRows;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при создании зявки. Ошибка: {ex.Message}");
            }
            await connection.CloseAsync();
            return isHaveExistingAccount;
        }
        private async void insertClientData(bool isExists)
        {
            try
            {
                DatabaseInfo info1 = new("Server=.\\SQLEXPRESS;Database=PhotoSession;Trusted_Connection=True;");
                var connection1 = info1.getConnectionWithDataBase();
                await connection1.OpenAsync();
                if (!isExists)
                {
                    SqlCommand indertUser = new SqlCommand($"INSERT INTO clients(name,surname,fname,phone_number,email) VALUES('{name_text.Text}','{surname_text.Text}','{fname_text.Text}','{phone_number_text.Text.Trim()}','{email_text.Text}')", connection1);
                    indertUser.ExecuteNonQuery();
                    MessageBox.Show("Пользователь успешно создан");
                }
                else
                {
                    MessageBox.Show("Пользователь с такими же данными уже зарегистрирован");
                }
                await connection1.CloseAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при создании зявки. Ошибка: {ex.Message}");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}