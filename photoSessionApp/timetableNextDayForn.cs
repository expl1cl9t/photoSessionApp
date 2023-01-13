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
    public partial class timetableNextDayForn : Form
    {
        private List<string> shops = new List<string>();
        private List<string> ordersDescription = new List<string>();
        private List<string> names = new List<string>();
        private List<string> timesOfOrder = new();
        private List<string> serviceName= new List<string>();
        List<string> user_ids = new List<string>();
        List<string> order_ids = new List<string>();
        private string? shop_id;
        public timetableNextDayForn()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void timetableNextDayForn_Load(object sender, EventArgs e)
        {
            DatabaseInfo info = new("Server=.\\SQLEXPRESS;Database=PhotoSession;Trusted_Connection=True;");
            var connection = info.getConnectionWithDataBase();
            await connection.OpenAsync();
            SqlCommand select = new SqlCommand("SELECT location FROM shops", connection);
            SqlDataReader result = await select.ExecuteReaderAsync();
            if (result.HasRows)
            {
                while (await result.ReadAsync())
                {
                    shops.Add(result.GetValue(0).ToString());
                }
            }

            await connection.CloseAsync(); //Создание объекта DataViewGrid, который будет отображать полученные данные в таблице
            shops_text.DataSource = shops;
            var timeColumn = new DataGridViewColumn();
            timeColumn.HeaderText= "Время приема";
            timeColumn.Width = tableGrid.Width / 3;
            timeColumn.ReadOnly= true;
            timeColumn.Name = "timeColumn";
            timeColumn.CellTemplate = new DataGridViewTextBoxCell();
            tableGrid.Columns.Add(timeColumn);

            var userName = new DataGridViewColumn();
            userName.Width = tableGrid.Width / 3;
            userName.HeaderText = "Имя пользователя";
            userName.ReadOnly = true;
            userName.Name = "nameColumn";
            userName.CellTemplate = new DataGridViewTextBoxCell();
            tableGrid.Columns.Add(userName);

            var typeOfService = new DataGridViewColumn();
            typeOfService.Width = tableGrid.Width / 2;
            typeOfService.HeaderText= "Описание заказа";
            typeOfService.ReadOnly = true;
            typeOfService.Name = "nameColumn";
            typeOfService.CellTemplate = new DataGridViewTextBoxCell();
            tableGrid.Columns.Add(typeOfService);
        }
        private void getShopId() //Функция для получения номера магазина по его названию
        {
            DataSet set = new();
            DatabaseInfo info = new("Server=.\\SQLEXPRESS;Database=PhotoSession;Trusted_Connection=True;");
            var connection = info.getConnectionWithDataBase();
            connection.Open();
            SqlDataAdapter select = new ($"SELECT shop_id FROM shops WHERE location = '{shops_text.SelectedItem.ToString()}'", connection); //Получение номера выбранного магазина
            select.Fill(set);
            shop_id = set.Tables[0].Rows[0].ItemArray[0].ToString();
            connection.Close();
        }
        private void getUsersNames()
        {
            DataSet set = new();
            DatabaseInfo info = new("Server=.\\SQLEXPRESS;Database=PhotoSession;Trusted_Connection=True;");
            var connection = info.getConnectionWithDataBase();
            connection.Open();
            SqlDataAdapter select = new($"SELECT client_id FROM appointments WHERE shop_id = {shop_id} AND date = '{DateTime.Now.AddDays(1).ToString(@"yyyy-MM-dd")}'",connection); //Получение всех клиентов на прием, где номер магазина соответсвует выбранному и дата приема назначена на завтрашний день
            select.Fill(set);
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                user_ids.Add(set.Tables[0].Rows[i].ItemArray[0].ToString());
            }
            connection.Close();
        }
        private void getAppointments()
        {
            getUsersNames();
            for (int i = 0; i < user_ids.Count; i++)
            {
                DataSet set = new();
                DatabaseInfo info = new("Server=.\\SQLEXPRESS;Database=PhotoSession;Trusted_Connection=True;");
                var connection = info.getConnectionWithDataBase();
                connection.Open();
                SqlDataAdapter select = new($"SELECT surname,name,fname FROM clients WHERE client_id = {user_ids[i]}", connection); //Выбрать полное имя клиента на основе его id
                select.Fill(set);
                for (int ij = 0; ij < set.Tables[0].Rows.Count; ij++)
                {
                    string surname = set.Tables[0].Rows[ij].ItemArray[0].ToString();
                    string name = set.Tables[0].Rows[ij].ItemArray[1].ToString();
                    string fname = set.Tables[0].Rows[ij].ItemArray[2].ToString();
                    names.Add($"{surname} {name} {fname}");

                }
                connection.Close();
            }
        }
        private void getOrderIds() //Функция получения всех идентификаторов заказов
        {
            DataSet set = new();
            DatabaseInfo info = new("Server=.\\SQLEXPRESS;Database=PhotoSession;Trusted_Connection=True;");
            var connection = info.getConnectionWithDataBase();
            connection.Open();
            SqlDataAdapter select = new($"SELECT order_id FROM appointments WHERE shop_id = {shop_id} AND date = '{DateTime.Now.AddDays(1).ToString(@"yyyy-MM-dd")}'", connection); //Получение всех заявок на прием, где номер магазина соответсвует выбранному и дата приема назначена на завтрашний день
            select.Fill(set);
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                order_ids.Add(set.Tables[0].Rows[i].ItemArray[0].ToString());
            }
            connection.Close();
        }
        private void getDesciptions()
        {
            getOrderIds();
            for (int i = 0; i < user_ids.Count; i++)
            {
                DataSet set = new();
                DatabaseInfo info = new("Server=.\\SQLEXPRESS;Database=PhotoSession;Trusted_Connection=True;");
                var connection = info.getConnectionWithDataBase();
                connection.Open();
                SqlDataAdapter select = new($"SELECT description FROM orders WHERE order_id = {order_ids[i]}", connection); //Выбрать все описания заказов по номеру заказа
                select.Fill(set);
                for (int ij = 0; ij < set.Tables[0].Rows.Count; ij++)
                {
                    string surname = set.Tables[0].Rows[ij].ItemArray[0].ToString();
                    ordersDescription.Add($"{surname.ToString()}");
                }
                connection.Close();
            }
        }
        private void getTime()
        {
            DataSet set = new();
            DatabaseInfo info = new("Server=.\\SQLEXPRESS;Database=PhotoSession;Trusted_Connection=True;");
            var connection = info.getConnectionWithDataBase();
            connection.Open();
            SqlDataAdapter select = new($"SELECT time FROM appointments WHERE shop_id = {shop_id} AND date = '{DateTime.Now.AddDays(1).ToString(@"yyyy-MM-dd")}'", connection); //Получение "расписания" на завтрашний день по выбранному магазину
            select.Fill(set);
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                timesOfOrder.Add(set.Tables[0].Rows[i].ItemArray[0].ToString());
            }
            connection.Close();
        }
        private void getTimeOf()
        {

        }

        private async void button1_Click(object sender, EventArgs e) //По нажатию кнопки все функции вызываются и синхронизирубтся
        {
            getShopId();
            getAppointments();
            getDesciptions();
            getTime();
            for (int i = 0; i < user_ids.Count; i++) //Данные добавляются в таблицу
            {
                tableGrid.Rows.Add(timesOfOrder[i], names[i], ordersDescription[i]);
            }
        }
    }
    
}
