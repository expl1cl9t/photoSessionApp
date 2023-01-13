using photoSessionApp.database;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Transactions;

namespace photoSessionApp
{
    public partial class Form1 : Form
    {
        DataRowCollection table;
        DataSet allData = new DataSet();
        List<string> forbiddenDates = new List<string>(); //������ ���, �� ������� ��� ��������� ���������� ��� ������
        List<string> forbiddenTimes = new List<string>();//������ �������, �� ������� ��� ��������� ���������� ��� ������
        List<string> colorOfPaper = new List<string>(); //������ ����� ������, ���������� � ���� ������
        List<string> typeOfPaper = new List<string>(); //������ ����� ������
        List<string> sizeOfPhoto = new List<string>(); //������ �������� ������
        List<string> shops = new List<string>(); //������ ���������
        DateTime rentDay; //��������� ������������� ���� ������
        DateTime rentTime; //��������� ������������� ����� ������
        byte[] imgToDb; //��������, ������� ����� ��������� � ���� ������
        string? shop_id; //����� ��������, ���������� � ���� ������ (������������� ����������)
        string? client_id; //����� �������, ���������� � ���� ������(������������� ����������)
        int totalPrice = 500; //������ ���� �� ��� ��������� ������ ��� ������
        int? orderId; //����� ������, ���������� � ���� ������(������������� ����������)
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void Form1_Load(object sender, EventArgs e) //�������, ������������ ��� �������� �����
        {
            try
            {
                DatabaseInfo info = new("Server=.\\SQLEXPRESS;Database=PhotoSession;Trusted_Connection=True;"); //��������� ���������� � ���� ������
                var connection = info.getConnectionWithDataBase(); //�������� ����������� � ���� ������
                await connection.OpenAsync(); //����� ����������� � �� �������� ������, ����� ����� ����� ����������������� � ����� ������ ����� ���
                SqlCommand select = new SqlCommand("SELECT date FROM appointments", connection); //���������� SQL ������� ��� ���������� �� ��� ���� ������� ���
                SqlDataReader result = await select.ExecuteReaderAsync(); //��������� ���������� ������� ����
                if (result.HasRows) //���� ��������� �� ����
                {
                    while (await result.ReadAsync())
                    {
                        DateTime date = result.GetDateTime(0);
                        forbiddenDates.Add(date.ToShortDateString());
                    }
                } //��������� � ������ ������� ��� ��� ������, ���������� � ��������
                
                await connection.CloseAsync(); //��������� �����������
            }
            catch (Exception ex) //������������ ������������� ������
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            try
            {
                //����� 3 ������ ����� ��������� ���������� ��������
                DatabaseInfo info1 = new("Server=.\\SQLEXPRESS;Database=PhotoSession;Trusted_Connection=True;");
                var connection1 = info1.getConnectionWithDataBase();
                await connection1.OpenAsync();
                SqlCommand select = new SqlCommand("SELECT variation_id,name FROM variation_option", connection1); //������� �� ���������� ���� ��������� ������ �� ���� ������
                SqlDataReader result = await select.ExecuteReaderAsync();
                if (result.HasRows)
                {
                    while (await result.ReadAsync())//� ���������� ������� � ���� �������� ���� ��������, ������� �������� � ������� �������� �� name
                    {
                        switch (result.GetInt32(0)) //�������� id ��������� ��������, � �� ��� �������� ������ � ������ �������
                        {
                            case 1:
                                sizeOfPhoto.Add(result.GetValue(1).ToString()); //�������� ������ � ������ � ��������� ������
                                break;
                            case 2: 
                                colorOfPaper.Add(result.GetValue(1).ToString()); //�������� ������ � ������ � ������� ������
                                break;
                            case 3:
                                typeOfPaper.Add(result.GetValue(1).ToString()); //�������� ������ � ������ � ������ ������
                                break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("������ �� ������");
                }
                print_format_text.DataSource = sizeOfPhoto; //���������� ����������� ������� � ��������� ���������� �� ������
                paper_type_text.DataSource = typeOfPaper;
                photo_type_text.DataSource = colorOfPaper;
                await connection1.CloseAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

            try
            {
                DatabaseInfo info = new("Server=.\\SQLEXPRESS;Database=PhotoSession;Trusted_Connection=True;");
                var connection = info.getConnectionWithDataBase();
                await connection.OpenAsync();
                SqlCommand select = new SqlCommand("SELECT location FROM shops", connection); //������� ��� ������ ���������
                SqlDataReader result = await select.ExecuteReaderAsync();
                if (result.HasRows)
                {
                    while (await result.ReadAsync())
                    {
                        shops.Add(result.GetValue(0).ToString()); //�������� �� � ������ � ��������
                    }
                }

                await connection.CloseAsync();
                shops_text.DataSource = shops; //���������� ����������� ������ � ��������� ���������� �� ������
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            try
            {
                DatabaseInfo info = new("Server=.\\SQLEXPRESS;Database=PhotoSession;Trusted_Connection=True;");
                var connection = info.getConnectionWithDataBase();
                await connection.OpenAsync();
                SqlCommand selectDates = new SqlCommand("SELECT date,time FROM appointments", connection); //������� ��� ������� ���� � �����
                var result = await selectDates.ExecuteReaderAsync();
                if (result.HasRows)
                {
                    while (await result.ReadAsync())
                    {
                        TimeSpan time = (TimeSpan)result.GetValue(1);
                        forbiddenTimes.Add(time.ToString("h\\:mm")); //�������� ������ � ������, ���������� � ������ ������ ����, ��������� ��� ���� ������
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void choicePhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog= new OpenFileDialog(); //�������� ���� ��� ������ ����� �����������
            dialog.Filter = "����� �����������|*.bmp;*.png;*.jpg"; //�������� ����� ������ ����� �����������
            if (dialog.ShowDialog() == DialogResult.Cancel) return;
            try
            {
                using(FileStream fs = new FileStream(dialog.FileName, FileMode.Open)) //��������� ��������� �������� � ���������� ����������
                {
                    imgToDb = new byte[fs.Length];
                    fs.Read(imgToDb, 0, imgToDb.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"��������� ������ ��� ���������� ��������. ������: {ex.Message}");
            }
            file_name_text.Text = dialog.FileName;
        }

        private void datePicker_DateSelected(object sender, DateRangeEventArgs e) //�������, ����������� �����, ����� ������������ ������ ���� 
        {

                dateLabel.Text = e.Start.ToLongDateString(); //���������� ��������� ���� ���������� ����, ����������� �� � ������� ��� ����(12-01-2023, ��������)
                rentDay = e.Start.Date; //���������� ��������� ���� ���������� ����, ����������� �� � ������� ��� ����(12-01-2023, ��������)
        }

        private async void button1_Click(object sender, EventArgs e) //�������, ������������� ��� ������� ������ "���������
        {
            try
            {

                bool existsAccount = await checkIfClientExists(); //��������, ���������� �� ��� ������� � ������ �����������
                insertClientData(existsAccount); //�������� ������ ������� � ���� ������, ���� �� ���
                DatabaseInfo info = new("Server=.\\SQLEXPRESS;Database=PhotoSession;Trusted_Connection=True;");
                var connection = info.getConnectionWithDataBase();

                
                await connection.OpenAsync();
                string selectVariations = $"SELECT variation_option_id,price FROM variation_option WHERE name = '{print_format_text.Text}' OR name = '{paper_type_text.Text}' OR name = '{photo_type_text.Text}'"; //������� ������ �����, ������� ������ ������������
                string selectedShop = $"SELECT shop_id FROM shops WHERE location = '{shops_text.Text}'"; //������� ����� ��������, ������� ������ ������������
                string selectedClient = $"SELECT client_id FROM clients WHERE email = '{email_text.Text}' AND phone_number = '{phone_number_text.Text}'"; //������� ������ ������������ ����� �������(��� ��� ��������������� � ���� ������)
                string query = selectedClient + Environment.NewLine + selectVariations + Environment.NewLine + selectedShop; //�������� ��������� ������ �������
                SqlDataAdapter values = new SqlDataAdapter(query, connection); //SqlDataAdapter ��������� �������� ������ �� ��������� �������� �����
                values.Fill(allData); //�������� ���������� ������ � ������ DataSet ���������: https://metanit.com/sharp/adonet/3.6.php ��� https://learn.microsoft.com/ru-ru/dotnet/api/system.data.dataset?view=net-7.0
                var cells = allData.Tables[2].Rows[0];
                shop_id = cells.ItemArray[0].ToString(); //������� ����� ��������
                client_id = (allData.Tables[0].Rows[0].ItemArray[0].ToString()); //������� ����� �������
                table = allData.Tables[1].Rows;
                for (int i = 0; i < table.Count; i++)
                {
                    totalPrice += Convert.ToInt32(table[i].ItemArray[1]); //������ �������� ����� ������
                }
                await connection.CloseAsync();
            }
            catch (Exception ex)
            {

                throw;
            }

            try
            {
                DatabaseInfo ih = new("Server=.\\SQLEXPRESS;Database=PhotoSession;Trusted_Connection=True;");
                SqlConnection cun = ih.getConnectionWithDataBase();
                await cun.OpenAsync();
                SqlCommand insOrd = new SqlCommand();
                    insOrd.CommandText = $"INSERT INTO orders VALUES('{description_text.Text}',{totalPrice * Convert.ToInt32(numberOfPhotos.Text)},{Convert.ToInt32(numberOfPhotos.Text)})"; //�������� � ���� ������ ����� �� ���������� ������ ��������
                    insOrd.Connection = cun;
                    insOrd.ExecuteNonQuery(); //��������� �� �������� Execute: https://metanit.com/sharp/adonet/2.5.php
                await cun.CloseAsync();


                DataSet ser = new DataSet();
                int result = 0;
                DatabaseInfo informa = new("Server=.\\SQLEXPRESS;Database=PhotoSession;Trusted_Connection=True;");
                var con = informa.getConnectionWithDataBase();
                await con.OpenAsync();
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT order_id FROM orders WHERE description='{description_text.Text}' and totalPrice='{totalPrice * Convert.ToInt32(numberOfPhotos.Text)}'", con); //������� ����� ���������� ������
                adapter.Fill(ser);
                result = (int)ser.Tables[0].Rows[0].ItemArray[0]; //���������� ���������� ����� ����������
                orderId = result;
                await con.CloseAsync();


                DatabaseInfo info = new("Server=.\\SQLEXPRESS;Database=PhotoSession;Trusted_Connection=True;");
                var connection = info.getConnectionWithDataBase();
                await connection.OpenAsync();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand insertToOrder = new SqlCommand();
                
                insertToOrder.Connection = connection;
                insertToOrder.Transaction = transaction; //������ ����������. ���������: https://learn.microsoft.com/ru-ru/dotnet/framework/data/adonet/transactions-and-concurrency


                string insertoptions = $"INSERT INTO order_variations_list VALUES({orderId},{Convert.ToInt32(table[0].ItemArray[0])}),({orderId},{Convert.ToInt32(table[1].ItemArray[0])}),({orderId},{Convert.ToInt32(table[2].ItemArray[0])});"; //�������� ������ � ������� order_variations_list, ����� ������� �� ���, ����� ����� ������� ��� ������������� ������
                MessageBox.Show(insertoptions);
                insertToOrder.CommandText = insertoptions;
                insertToOrder.ExecuteNonQuery();
                insertToOrder.CommandText = @"INSERT INTO order_files VALUES (@order_id,@file)"; //�������� �����������, ��������� �������������, � ���� ������
                insertToOrder.Parameters.Add("@order_id",SqlDbType.Int);
                insertToOrder.Parameters.Add("@file", SqlDbType.Image, 1000000);
                insertToOrder.Parameters["@order_id"].Value = orderId;
                insertToOrder.Parameters["@file"].Value = imgToDb;
                insertToOrder.ExecuteNonQuery();

                transaction.Commit();
                await connection.CloseAsync();



                DatabaseInfo info1 = new("Server=.\\SQLEXPRESS;Database=PhotoSession;Trusted_Connection=True;");
                var connection1 = info1.getConnectionWithDataBase();
                await connection1.OpenAsync();
                SqlTransaction transaction1= connection1.BeginTransaction();
                SqlCommand coma= new SqlCommand();
                coma.CommandText = $"INSERT INTO appointments VALUES('{rentDay.ToShortDateString()}','{rentTime.ToShortTimeString()}',{client_id},{orderId},{shop_id})"; //�������� ��� ���������� ����� ������ � ������� appointments 
                coma.Connection= connection1;
                coma.Transaction = transaction1;
                coma.ExecuteNonQuery();

                transaction1.Commit();
                await connection1.CloseAsync();
            }
            catch (Exception ex)
            {

                throw;

            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private async Task<int> getorderID() //������� ��� ��������� ����� ������
        {
            DataSet ser = new DataSet();
            int result = 0;
            DatabaseInfo info = new("Server=.\\SQLEXPRESS;Database=PhotoSession;Trusted_Connection=True;");
            var connection = info.getConnectionWithDataBase();
            await connection.OpenAsync();
            SqlDataAdapter adapter= new SqlDataAdapter($"SELECT order_id FROM orders WHERE description='{description_text.Text}' and totalPrice='{totalPrice * Convert.ToInt32(numberOfPhotos.Text)}'",connection);
            adapter.Fill(ser);
            result = (int)ser.Tables[0].Rows[0].ItemArray[0];
            await connection.CloseAsync();
            return result;
        }
        private async Task<bool> checkIfClientExists() //������� ��� �������� ������������� �������
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
                MessageBox.Show($"��������� ������ ��� �������� �����. ������: {ex.Message}");
            }
            await connection.CloseAsync();
            return isHaveExistingAccount;
        }
        private async void insertClientData(bool isExists) //������� ��� ���������� ������ ������������, ���� ��� �� ����������
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
                    MessageBox.Show("������������ ������� ������");
                    await connection1.CloseAsync();
                }
                else
                {
                    await connection1.CloseAsync();
                    throw new Exception("������������ � ������ �� ������� ��� ���������������");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"��������� ������ ��� �������� �����. ������: {ex.Message}");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private async void dateTimePicker1_ValueChanged(object sender, EventArgs e) //�������, �������������� ��� ������ ������������� ������� ������
        {
            if (dateLabel.Text == "") 
            {
                MessageBox.Show("�� �� ������� ����");
            }
            if(forbiddenDates.Exists(item => item == rentDay.ToShortDateString()) && forbiddenTimes.Exists(item => item == time_picker.Value.ToShortTimeString())) // ���� �������� ����� � ���� ���������� � ��������, ���������� �� ���� ������, �� �� ����� ���� � ����� ���������� ������
            {
                MessageBox.Show("������ ����� ������ ��� ������");
                var nwTime = time_picker.Value.AddHours(1); //�������� � ��������� ������������� ����� ���� ���, ��� �������� ������������
                time_picker.Text = nwTime.ToString();
            }
            else
            {
                rentTime = time_picker.Value; //���������� ����� � ������ ����������
            }
        }

        private void button3_Click(object sender, EventArgs e) //������, ����������� ����� ������ �� ����������
        {
            adminRegistrationForm frm = new();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)//������, ����������� ����� ��������������
        {
            PhotoSessionForm frm = new();
            frm.ShowDialog();
        }
    }
}