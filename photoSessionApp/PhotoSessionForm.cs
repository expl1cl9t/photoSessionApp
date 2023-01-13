using photoSessionApp.database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;

namespace photoSessionApp
{
    public partial class PhotoSessionForm : Form
    {
        DataRowCollection table;
        DataSet allData = new DataSet();
        List<string> forbiddenDates = new List<string>();
        List<string> forbiddenTimes = new List<string>();
        List<string> colorOfPaper = new List<string>();
        List<string> typeOfPaper = new List<string>();
        List<string> sizeOfPhoto = new List<string>();
        List<string> shops = new List<string>();
        DateTime rentDay;
        DateTime rentTime;
        Image photoToPrint;
        byte[] imgToDb;
        string? shop_id;
        string? client_id;
        int basedPriceToPrint = 500;
        int totalPrice = 500;
        int? orderId;
        int? variatioID1;
        public PhotoSessionForm()
        {
            InitializeComponent();
        }

        private void description_text_TextChanged(object sender, EventArgs e)
        {

        }

        private void shops_text_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void PhotoSessionForm_Load(object sender, EventArgs e)
        {
            try
            {
                DatabaseInfo info = new("Server=.\\SQLEXPRESS;Database=PhotoSession;Trusted_Connection=True;");
                var connection = info.getConnectionWithDataBase();
                await connection.OpenAsync();
                SqlCommand select = new SqlCommand("SELECT date FROM appointments", connection); //Запрос на получение всех дат из таблицы приемов
                SqlDataReader result = await select.ExecuteReaderAsync();
                if (result.HasRows)
                {
                    while (await result.ReadAsync())
                    {
                        DateTime date = result.GetDateTime(0);
                        forbiddenDates.Add(date.ToShortDateString());
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
                DatabaseInfo info = new("Server=.\\SQLEXPRESS;Database=PhotoSession;Trusted_Connection=True;");
                var connection = info.getConnectionWithDataBase();
                await connection.OpenAsync();
                SqlCommand select = new SqlCommand("SELECT location FROM shops", connection); //Запрос на получение всех филиалов магазинов из таблицы shops
                SqlDataReader result = await select.ExecuteReaderAsync();
                if (result.HasRows)
                {
                    while (await result.ReadAsync())
                    {
                        shops.Add(result.GetValue(0).ToString());
                    }
                }

                await connection.CloseAsync();
                shops_text.DataSource = shops;
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
                SqlCommand selectDates = new SqlCommand("SELECT date,time FROM appointments", connection); //Запрос на получение дат и времени приема, на которые уже назначен прием
                var result = await selectDates.ExecuteReaderAsync();
                if (result.HasRows)
                {
                    while (await result.ReadAsync())
                    {
                        TimeSpan time = (TimeSpan)result.GetValue(1);
                        forbiddenTimes.Add(time.ToString("h\\:mm"));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void datePicker_DateSelected(object sender, DateRangeEventArgs e)
        {
            dateLabel.Text = e.Start.ToLongDateString();
            rentDay = e.Start.Date;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void time_picker_ValueChanged(object sender, EventArgs e)
        {
            if (dateLabel.Text == "")
            {
                MessageBox.Show("Вы не выбрали дату");
            }
            if (forbiddenDates.Exists(item => item == rentDay.ToShortDateString()) && forbiddenTimes.Exists(item => item == time_picker.Value.ToShortTimeString()))
            {
                MessageBox.Show("Данное время фотосессии уже занято");
                var nwTime = time_picker.Value.AddHours(1);
                time_picker.Text = nwTime.ToString();
            }
            else
            {
                rentTime = time_picker.Value.ToUniversalTime();
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            bool existsAccount = await checkIfClientExists();
            insertClientData(existsAccount);
            DatabaseInfo info = new("Server=.\\SQLEXPRESS;Database=PhotoSession;Trusted_Connection=True;");
            var connection = info.getConnectionWithDataBase();


            await connection.OpenAsync();
            
            string selectedShop = $"SELECT shop_id FROM shops WHERE location = '{shops_text.Text}'"; //Запрос на получение номера магазина по выбранному адресу
            string selectedClient = $"SELECT client_id FROM clients WHERE email = '{email_text.Text}' AND phone_number = '{phone_number_text.Text}'"; //Получение id клиента для формирования заявки .
            string query = selectedClient + Environment.NewLine + selectedShop;
            SqlDataAdapter values = new SqlDataAdapter(query, connection);
            values.Fill(allData);
            var cells = allData.Tables[1].Rows[0];
            shop_id = cells.ItemArray[0].ToString();
            client_id = (allData.Tables[0].Rows[0].ItemArray[0].ToString());
            await connection.CloseAsync();

            DatabaseInfo ih = new("Server=.\\SQLEXPRESS;Database=PhotoSession;Trusted_Connection=True;");
            SqlConnection cun = ih.getConnectionWithDataBase();
            await cun.OpenAsync();
            SqlCommand insOrd = new SqlCommand();
            insOrd.CommandText = $"INSERT INTO orders VALUES('{description_text.Text}',500,1)"; //ДОбавляем описание к заказу
            insOrd.Connection = cun;
            insOrd.ExecuteNonQuery();
            await cun.CloseAsync();

            DataSet ser = new DataSet();
            int result = 0;
            DatabaseInfo informa = new("Server=.\\SQLEXPRESS;Database=PhotoSession;Trusted_Connection=True;");
            var con = informa.getConnectionWithDataBase();
            await con.OpenAsync();
            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT order_id FROM orders WHERE description='{description_text.Text}' and totalPrice=500", con); //Поиск номера заказа в базе данных по описанию заказа и по его стоимости
            adapter.Fill(ser);
            result = (int)ser.Tables[0].Rows[0].ItemArray[0];
            orderId = result;
            await con.CloseAsync();

            DatabaseInfo info1 = new("Server=.\\SQLEXPRESS;Database=PhotoSession;Trusted_Connection=True;");
            var connection1 = info1.getConnectionWithDataBase();
            await connection1.OpenAsync();
            SqlTransaction transaction1 = connection1.BeginTransaction();
            SqlCommand coma = new SqlCommand();
            coma.CommandText = $"INSERT INTO appointments VALUES('{rentDay.ToShortDateString()}','{rentTime.ToShortTimeString()}',{client_id},{orderId},{shop_id})"; //Добавление данных в таблицу приема appointments
            coma.Connection = connection1;
            coma.Transaction = transaction1;
            coma.ExecuteNonQuery();
            coma.CommandText = $"INSERT INTO order_variations_list VALUES({orderId},9)"; //Добавление данных в таблицу-список вариаций заказа, привязанных к определенному заказу
            coma.ExecuteNonQuery();
            transaction1.Commit();
            await connection1.CloseAsync();
        }
        private async Task<bool> checkIfClientExists()
        {
            DatabaseInfo info = new("Server=.\\SQLEXPRESS;Database=PhotoSession;Trusted_Connection=True;");
            var connection = info.getConnectionWithDataBase();
            bool isHaveExistingAccount = false;
            await connection.OpenAsync();
            try
            {
                SqlCommand existingUsers = new SqlCommand($"SELECT * FROM clients WHERE email = '{email_text.Text}' OR phone_number = '{phone_number_text.Text}'", connection); //Получение клиента с ввдененными данными, по сути просто проверка на то, чтобы клиента с такими же данными не существовало.
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
                    SqlCommand indertUser = new SqlCommand($"INSERT INTO clients(name,surname,fname,phone_number,email) VALUES('{name_text.Text}','{surname_text.Text}','{fname_text.Text}','{phone_number_text.Text.Trim()}','{email_text.Text}')", connection1); //Создание нового пользователя, если его нет в базе данных
                    indertUser.ExecuteNonQuery();
                    MessageBox.Show("Пользователь успешно создан");
                    await connection1.CloseAsync();
                }
                else
                {
                    await connection1.CloseAsync();;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при создании зявки. Ошибка: {ex.Message}");
            }
        }

        private void datePicker_DateSelected_1(object sender, DateRangeEventArgs e)
        {
            dateLabel.Text = e.Start.ToLongDateString();
            rentDay = e.Start.Date;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            adminRegistrationForm frm = new();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.ShowDialog();
        }
    }
}
