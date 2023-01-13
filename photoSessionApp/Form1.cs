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
        List<string> forbiddenDates = new List<string>(); //Список дат, на которые уже назначена фотосессия или печать
        List<string> forbiddenTimes = new List<string>();//Список времени, на которое уже назначена фотосессия или печать
        List<string> colorOfPaper = new List<string>(); //Список типов бумаги, получаемых с базы данных
        List<string> typeOfPaper = new List<string>(); //Список типов бумаги
        List<string> sizeOfPhoto = new List<string>(); //Список форматов печати
        List<string> shops = new List<string>(); //Список магазинов
        DateTime rentDay; //Выбранный пользователем день записи
        DateTime rentTime; //Выбранное пользователем время записи
        byte[] imgToDb; //Картинка, которая будет загружена в базу данных
        string? shop_id; //Номер магазина, получаемый с базы данных (промежуточная переменная)
        string? client_id; //Номер клиента, получаемый с базы данных(промежуточная переменная)
        int totalPrice = 500; //Полная цена за все выбранные услуги для печати
        int? orderId; //Номер заказа, получаемый с базы данных(промежуточная переменная)
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void Form1_Load(object sender, EventArgs e) //Событие, срабатывющее при создании формы
        {
            try
            {
                DatabaseInfo info = new("Server=.\\SQLEXPRESS;Database=PhotoSession;Trusted_Connection=True;"); //Получение информации о базе данных
                var connection = info.getConnectionWithDataBase(); //Создание подключения к базе данных
                await connection.OpenAsync(); //Здесь подключение к БД начинает работу, после этого можно взаимодействовать с базой данных через код
                SqlCommand select = new SqlCommand("SELECT date FROM appointments", connection); //Объявление SQL команды для извлекания из нее всех занятых дат
                SqlDataReader result = await select.ExecuteReaderAsync(); //Результат выполнения команды выше
                if (result.HasRows) //Если результат не пуст
                {
                    while (await result.ReadAsync())
                    {
                        DateTime date = result.GetDateTime(0);
                        forbiddenDates.Add(date.ToShortDateString());
                    }
                } //Добавляем в массив занятых дат все данные, полученные с запросом
                
                await connection.CloseAsync(); //Закрываем подключение
            }
            catch (Exception ex) //Обрабатываем потенциальные ошибки
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            try
            {
                //Далее 3 строки будут выполнять идентичные действия
                DatabaseInfo info1 = new("Server=.\\SQLEXPRESS;Database=PhotoSession;Trusted_Connection=True;");
                var connection1 = info1.getConnectionWithDataBase();
                await connection1.OpenAsync();
                SqlCommand select = new SqlCommand("SELECT variation_id,name FROM variation_option", connection1); //Команда на извлечение всех вариантов печати из базы данных
                SqlDataReader result = await select.ExecuteReaderAsync();
                if (result.HasRows)
                {
                    while (await result.ReadAsync())//В полученном запросе я брал значение двух столбцов, поэтому добавляю в массивы значения из name
                    {
                        switch (result.GetInt32(0)) //Проверяю id пришедших вариаций, и по ним добавляю данные в нужные массивы
                        {
                            case 1:
                                sizeOfPhoto.Add(result.GetValue(1).ToString()); //Добавляю данные в массив с форматами печати
                                break;
                            case 2: 
                                colorOfPaper.Add(result.GetValue(1).ToString()); //Добавляю данные в массив с цветами бумаги
                                break;
                            case 3:
                                typeOfPaper.Add(result.GetValue(1).ToString()); //Добавляю данные в массив с типами бумаги
                                break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Данных не пришло");
                }
                print_format_text.DataSource = sizeOfPhoto; //Привязываю заполненные массивы к элементам управления на экране
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
                SqlCommand select = new SqlCommand("SELECT location FROM shops", connection); //Получаю все адреса магазинов
                SqlDataReader result = await select.ExecuteReaderAsync();
                if (result.HasRows)
                {
                    while (await result.ReadAsync())
                    {
                        shops.Add(result.GetValue(0).ToString()); //Добавляю их в массив с адресами
                    }
                }

                await connection.CloseAsync();
                shops_text.DataSource = shops; //Привязываю заполненный массив к элементам управления на экране
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
                SqlCommand selectDates = new SqlCommand("SELECT date,time FROM appointments", connection); //Получаю все занятые даты и время
                var result = await selectDates.ExecuteReaderAsync();
                if (result.HasRows)
                {
                    while (await result.ReadAsync())
                    {
                        TimeSpan time = (TimeSpan)result.GetValue(1);
                        forbiddenTimes.Add(time.ToString("h\\:mm")); //Добавляю данные в массив, форматируя в нужный формат даты, пригодный для базы данных
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
            OpenFileDialog dialog= new OpenFileDialog(); //Открываю окно для выбора файла изображения
            dialog.Filter = "Файлы изображений|*.bmp;*.png;*.jpg"; //Выбирать можно только файлы изображений
            if (dialog.ShowDialog() == DialogResult.Cancel) return;
            try
            {
                using(FileStream fs = new FileStream(dialog.FileName, FileMode.Open)) //Записываю выбранную картинку в переменную фотографии
                {
                    imgToDb = new byte[fs.Length];
                    fs.Read(imgToDb, 0, imgToDb.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при добавлении картинки. Ошибка: {ex.Message}");
            }
            file_name_text.Text = dialog.FileName;
        }

        private void datePicker_DateSelected(object sender, DateRangeEventArgs e) //События, возникающее тогда, когда пользователь выбрал дату 
        {

                dateLabel.Text = e.Start.ToLongDateString(); //Присваиваю выбранную дату переменной даты, конвертируя ее в длинный тип даты(12-01-2023, например)
                rentDay = e.Start.Date; //Присваиваю выбранную дату переменной даты, конвертируя ее в длинный тип даты(12-01-2023, например)
        }

        private async void button1_Click(object sender, EventArgs e) //Событие, срабатывающее при нажатии кнопки "Отправить
        {
            try
            {

                bool existsAccount = await checkIfClientExists(); //Опрделяю, существует ли уже аккаунт с такими параметрами
                insertClientData(existsAccount); //ДОбавляю данные клиента в базу данных, если их нет
                DatabaseInfo info = new("Server=.\\SQLEXPRESS;Database=PhotoSession;Trusted_Connection=True;");
                var connection = info.getConnectionWithDataBase();

                
                await connection.OpenAsync();
                string selectVariations = $"SELECT variation_option_id,price FROM variation_option WHERE name = '{print_format_text.Text}' OR name = '{paper_type_text.Text}' OR name = '{photo_type_text.Text}'"; //Выбираю номера опций, которые выбрал пользователь
                string selectedShop = $"SELECT shop_id FROM shops WHERE location = '{shops_text.Text}'"; //Выбираю номер магазина, который выбрал пользователь
                string selectedClient = $"SELECT client_id FROM clients WHERE email = '{email_text.Text}' AND phone_number = '{phone_number_text.Text}'"; //Получаю данные добавленного ранее клиента(или уже существовавшего в базе данных)
                string query = selectedClient + Environment.NewLine + selectVariations + Environment.NewLine + selectedShop; //Формирую финальную строку запроса
                SqlDataAdapter values = new SqlDataAdapter(query, connection); //SqlDataAdapter позволяет получить данные из множества запросов сразу
                values.Fill(allData); //Добавляю полученные данные в объект DataSet подробнее: https://metanit.com/sharp/adonet/3.6.php или https://learn.microsoft.com/ru-ru/dotnet/api/system.data.dataset?view=net-7.0
                var cells = allData.Tables[2].Rows[0];
                shop_id = cells.ItemArray[0].ToString(); //Получаю номер магазина
                client_id = (allData.Tables[0].Rows[0].ItemArray[0].ToString()); //Получаю номер клиента
                table = allData.Tables[1].Rows;
                for (int i = 0; i < table.Count; i++)
                {
                    totalPrice += Convert.ToInt32(table[i].ItemArray[1]); //Считаю итоговую сумму заказа
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
                    insOrd.CommandText = $"INSERT INTO orders VALUES('{description_text.Text}',{totalPrice * Convert.ToInt32(numberOfPhotos.Text)},{Convert.ToInt32(numberOfPhotos.Text)})"; //Добавляю в базу данных заказ из полученных рранее значений
                    insOrd.Connection = cun;
                    insOrd.ExecuteNonQuery(); //Подробнее об командах Execute: https://metanit.com/sharp/adonet/2.5.php
                await cun.CloseAsync();


                DataSet ser = new DataSet();
                int result = 0;
                DatabaseInfo informa = new("Server=.\\SQLEXPRESS;Database=PhotoSession;Trusted_Connection=True;");
                var con = informa.getConnectionWithDataBase();
                await con.OpenAsync();
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT order_id FROM orders WHERE description='{description_text.Text}' and totalPrice='{totalPrice * Convert.ToInt32(numberOfPhotos.Text)}'", con); //Получаю номер созданного заказа
                adapter.Fill(ser);
                result = (int)ser.Tables[0].Rows[0].ItemArray[0]; //Присваиваю полученный номер переменной
                orderId = result;
                await con.CloseAsync();


                DatabaseInfo info = new("Server=.\\SQLEXPRESS;Database=PhotoSession;Trusted_Connection=True;");
                var connection = info.getConnectionWithDataBase();
                await connection.OpenAsync();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand insertToOrder = new SqlCommand();
                
                insertToOrder.Connection = connection;
                insertToOrder.Transaction = transaction; //Создаю транзакцию. Подробнее: https://learn.microsoft.com/ru-ru/dotnet/framework/data/adonet/transactions-and-concurrency


                string insertoptions = $"INSERT INTO order_variations_list VALUES({orderId},{Convert.ToInt32(table[0].ItemArray[0])}),({orderId},{Convert.ToInt32(table[1].ItemArray[0])}),({orderId},{Convert.ToInt32(table[2].ItemArray[0])});"; //Добавляю данные в таблицу order_variations_list, чтобы следить за тем, какие опции выбраны для определенного заказа
                MessageBox.Show(insertoptions);
                insertToOrder.CommandText = insertoptions;
                insertToOrder.ExecuteNonQuery();
                insertToOrder.CommandText = @"INSERT INTO order_files VALUES (@order_id,@file)"; //ДОбавляю фотограафию, выбранную пользователем, в базу данных
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
                coma.CommandText = $"INSERT INTO appointments VALUES('{rentDay.ToShortDateString()}','{rentTime.ToShortTimeString()}',{client_id},{orderId},{shop_id})"; //Добавляю все полученные ранее данные в таблицу appointments 
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
        private async Task<int> getorderID() //Функция для получения номер заказа
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
        private async Task<bool> checkIfClientExists() //Функция для проверки существования клиента
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
        private async void insertClientData(bool isExists) //функция для добавления нового пользователя, если его не существует
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
                    await connection1.CloseAsync();
                }
                else
                {
                    await connection1.CloseAsync();
                    throw new Exception("Пользователь с такими же данными уже зарегистрирован");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при создании зявки. Ошибка: {ex.Message}");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private async void dateTimePicker1_ValueChanged(object sender, EventArgs e) //Событие, срабатыввающее при выборе пользователем времени приема
        {
            if (dateLabel.Text == "") 
            {
                MessageBox.Show("Вы не выбрали дату");
            }
            if(forbiddenDates.Exists(item => item == rentDay.ToShortDateString()) && forbiddenTimes.Exists(item => item == time_picker.Value.ToShortTimeString())) // Если ввденное время и дата существуют в массивах, полученных от базы данных, то на такую дату и время записаться нельзя
            {
                MessageBox.Show("Данное время печати уже занято");
                var nwTime = time_picker.Value.AddHours(1); //Добавляю в выбранное пользователем время один час, для удобства пользователя
                time_picker.Text = nwTime.ToString();
            }
            else
            {
                rentTime = time_picker.Value; //Записываем время в нужную переменную
            }
        }

        private void button3_Click(object sender, EventArgs e) //Кнопка, открывающая форму заявки на фотосессию
        {
            adminRegistrationForm frm = new();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)//Кнопка, открывающая форму администратора
        {
            PhotoSessionForm frm = new();
            frm.ShowDialog();
        }
    }
}