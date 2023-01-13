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

namespace photoSessionApp
{
    public partial class userOrdersForm : Form
    {
        private List<string> user_orders_id = new List<string>();
        private List<string> descriptions = new List<string>();
        private List<string> totalPrices = new List<string>();
        private List<string> amounts = new List<string>();
        public userOrdersForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getOrderIds();
            getOrdersData();
            for (int i = 0; i < descriptions.Count; i++)
            {
                tableGrid.Rows.Add(descriptions[i], amounts[i], totalPrices[i]);
            }
        }

        private void userOrdersForm_Load(object sender, EventArgs e)
        {
            var timeColumn = new DataGridViewColumn();
            timeColumn.HeaderText = "Описание заказа";
            timeColumn.Width = tableGrid.Width / 3;
            timeColumn.ReadOnly = true;
            timeColumn.Name = "timeColumn";
            timeColumn.CellTemplate = new DataGridViewTextBoxCell();
            tableGrid.Columns.Add(timeColumn);

            var userName = new DataGridViewColumn();
            userName.Width = tableGrid.Width / 3;
            userName.HeaderText = "Количеество экземпляров";
            userName.ReadOnly = true;
            userName.Name = "nameColumn";
            userName.CellTemplate = new DataGridViewTextBoxCell();
            tableGrid.Columns.Add(userName);

            var typeOfService = new DataGridViewColumn();
            typeOfService.Width = tableGrid.Width / 3;
            typeOfService.HeaderText = "Общая цена";
            typeOfService.ReadOnly = true;
            typeOfService.Name = "nameColumn";
            typeOfService.CellTemplate = new DataGridViewTextBoxCell();
            tableGrid.Columns.Add(typeOfService);
        }
        private void getOrderIds()
        {
            DataSet set = new();
            DatabaseInfo info = new("Server=.\\SQLEXPRESS;Database=PhotoSession;Trusted_Connection=True;");
            var connection = info.getConnectionWithDataBase();
            connection.Open();
            SqlDataAdapter select = new($"SELECT order_id FROM appointments WHERE client_id = {userId.Text}", connection); //ПОлучение всех номеров заказа по выбранному пользователю
            select.Fill(set);
            for (int i = 0; i < set.Tables[0].Rows.Count; i++)
            {
                user_orders_id.Add(set.Tables[0].Rows[i].ItemArray[0].ToString());
            }
            connection.Close();
        }
        private void getOrdersData()
        {
            for (int i = 0; i < user_orders_id.Count; i++)
            {
                DataSet set = new();
                DatabaseInfo info = new("Server=.\\SQLEXPRESS;Database=PhotoSession;Trusted_Connection=True;");
                var connection = info.getConnectionWithDataBase();
                connection.Open();
                SqlDataAdapter select = new($"SELECT description,amount,totalPrice FROM orders WHERE order_id = {user_orders_id[i]}", connection); //Получения всех данных у всех заказов, совершенных пользователем.
                select.Fill(set);
                for (int ij = 0; ij < set.Tables[0].Rows.Count; ij++)
                {
                    descriptions.Add(set.Tables[0].Rows[ij].ItemArray[0].ToString());
                    amounts.Add(set.Tables[0].Rows[ij].ItemArray[1].ToString());
                    totalPrices.Add( set.Tables[0].Rows[ij].ItemArray[2].ToString());
                    
                }
                connection.Close();
            }
        }
    }
}
