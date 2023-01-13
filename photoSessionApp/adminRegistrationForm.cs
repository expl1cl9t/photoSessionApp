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
    public partial class adminRegistrationForm : Form
    {
        private List<String> logins= new List<String>();
        private List<String> passwords = new List<String>();
        DataSet ser = new DataSet();
        public adminRegistrationForm()
        {
            InitializeComponent();
        }

        private async void adminRegistrationForm_Load(object sender, EventArgs e)
        {
            DatabaseInfo info1 = new("Server=.\\SQLEXPRESS;Database=PhotoSession;Trusted_Connection=True;");
            var connection1 = info1.getConnectionWithDataBase();
            await connection1.OpenAsync();
            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT phone_number,email FROM clients",connection1); //Получение данных пользователей, с которыми будут сравниваться ввденнные данные
            adapter.Fill(ser);
            for (int i = 0; i < ser.Tables[0].Rows.Count; i++)
            {
                logins.Add(ser.Tables[0].Rows[i].ItemArray[0].ToString());
                passwords.Add(ser.Tables[0].Rows[i].ItemArray[1].ToString());
            }
            await connection1.CloseAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(passwords.Exists(item => item == passwordEntry.Text) && logins.Exists(item => item == loginEntry.Text)) //Если и ввденные данные совпадают с теми, что уже есть в базе данных, тогда авторизация пройдет успешно
            {
                //Открыть форму отчетночти
                MessageBox.Show("Данные верны"); //После успешной авторизации кнопки становятся активными
                button2.Enabled= true;
                button3.Enabled = true;
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль"); //В случае, если данные неверны, тогда очистить поля для ввода
                passwordEntry.Text = "";
                loginEntry.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timetableNextDayForn frm= new timetableNextDayForn();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            userOrdersForm frm = new userOrdersForm();
            frm.ShowDialog();
        }
    }
}
