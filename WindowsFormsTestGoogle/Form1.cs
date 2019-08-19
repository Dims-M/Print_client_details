using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConsoleApp;
using ConsoleApp.Model;
using System.Data.Entity;

namespace WindowsFormsTestGoogle
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// контекст для связки с БД
       /// </summary>
        TablGoogleContext googleContext2; // контекст для связки с БД
        public  Form1()
        {
            
            InitializeComponent();

            googleContext2 = new TablGoogleContext();
            googleContext2.TablGoogles.Load(); // загрузка к кэшь копии базы данных
        }

        //При загрузке формы
        private async void   Form1_Load(object sender, EventArgs e)
        {
           
            labelCauntClient.Visible = false;
            int tempCount = 0;
            await Task.Run(() => tempCount = BL.GetCountTablGoogle()); // получение количество сток из БД                                                   // tempCount = BL.GetCountTablGoogle();                                                      // BL.GetCountTablGoogle(); 
            labelCauntClient.Visible = true;
            labelCauntClient.Text = tempCount.ToString();

           //  await Task.Run(() => dataGridView1.DataSource = BL.GetCountLastValue());
            Invoke((MethodInvoker)delegate { dataGridView1.DataSource = BL.GetCountLastValue(); }); // загружаем в таблицу данные послеедние 10 значений
        
    }


        //Область для вывода данных при щелчке
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          //  dataGridView1.DataSource = googleContext2.TablGoogles.Local.ToBindingList(); // загрузка контекста в дату гриф

            // dataGridView1.
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //Кнопка выход
        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Тестовая кнопка обновить
        private void Button2_Click(object sender, EventArgs e)
        {
            // BL.AddDataTableGoogle();
            //  BL.test2();
            //labelCauntClient.Text =  BL.GetCountTablGoogle().ToString();
            // dataGridView1.DataSource = BL.GetClient();
            //  dataGridView1.DataSource = googleContext2.TablGoogles.Local.ToBindingList(); // загрузка контекста в дату гриф
            // await Task.Run(() => dataGridView1.DataSource = BL.GetCountLastValue());
            dataGridView1.DataSource = BL.GetCountLastValue();
           // dataGridView1.Refresh(); // обновляем грид
        }

        //Показать всех клиентов
        private void Button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource  = BL.GetAllTablGoogle();
           // dataGridView1.DataSource = googleContext2.TablGoogles.Local.ToBindingList(); // загрузка контекста в дату гриф
           
        }

        //кнопка поиска ок
        private void Button3_Click(object sender, EventArgs e)
        {
            if (textBoxSeath.Text !="" && textBoxSeath.Text != null)
            {
                dataGridView1.DataSource = null;

                dataGridView1.DataSource = BL.SeachNameClient(textBoxSeath.Text);
            }

            else
            {
                MessageBox.Show( "Ошибка при поиске \t\nПоле поиска не должно быть пустым");
            }
            // dataGridView1.Update();
           // dataGridView1.DataSource = null; 

           // dataGridView1.DataSource = BL.SeachNameClient("ООО Алар");
        }

        //Кнопка добавить клиента
        private void Button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Refresh(); // обновляем грид
            PlayerForm plForm = new PlayerForm(); // Создание новой формы
            DialogResult result = plForm.ShowDialog(this); // включение диалога

            if (result == DialogResult.Cancel) // если нажата кнопка отмены, то выход из формы
                return;

            using (var db2 = new TablGoogleContext())
            {
                TablGoogle tablGoogle = new TablGoogle();
                tablGoogle.NameClienta = plForm.textBoxNameClient.Text; // присваиваем текст
                tablGoogle.PassClient = plForm.textBoxPassClient.Text; 
                tablGoogle.TelefonClient = plForm.textBoxTelefonClienta.Text;
                tablGoogle.DataTimeAddTable = DateTime.Now.ToString(); // время создания

                db2.TablGoogles.Add(tablGoogle); // добавляем в БД новые данные
                db2.SaveChanges();
            }
             

            MessageBox.Show("Новый объект добавлен");
        }

        //Кнока изменить клиента
        private void Button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Refresh(); // обновляем грид

            if (dataGridView1.SelectedRows.Count > 0)
            {
                using (var db2 = new TablGoogleContext())
                {

                int index = dataGridView1.SelectedRows[0].Index; // Привязка индекса по id строки
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);

                    if (converted == false) //проверка 
                    return;


                TablGoogle tablGoogle  = db2.TablGoogles.Find(id); // ищем по базе ID строки

                PlayerForm plForm = new PlayerForm(); // создаем форму для редактирования

                    plForm.textBoxDatetime.Visible = true;
                    plForm.labelDateTime.Visible = true;
                     
                    plForm.textBoxNameClient.Text = tablGoogle.NameClienta;
                    plForm.textBoxPassClient.Text = tablGoogle.PassClient ;
                    plForm.textBoxTelefonClienta.Text = tablGoogle.TelefonClient;
                    plForm.textBoxNameClient.Text = tablGoogle.NameClienta;
                    plForm.textBoxDatetime.Text = tablGoogle.DataTimeAddTable;
                    
                    DialogResult result = plForm.ShowDialog(this); //включаем диалог

                if (result == DialogResult.Cancel)  //при нажатии отмены, выходим из формы
                    return;

                    tablGoogle.NameClienta = plForm.textBoxNameClient.Text; // присваиваем текст
                    tablGoogle.PassClient = plForm.textBoxPassClient.Text;
                    tablGoogle.TelefonClient = plForm.textBoxTelefonClienta.Text;
                    tablGoogle.DataTimeAddTable = DateTime.Now.ToString(); // время создания

                //player.Age = (int)plForm.numericUpDown1.Value;
                //player.Name = plForm.textBox1.Text;
                //player.Position = plForm.comboBox1.SelectedItem.ToString();

                db2.SaveChanges();
            //    dataGridView1.Refresh(); // обновляем грид
                MessageBox.Show("Объект обновлен");
               // dataGridView1.Refresh(); // обновляем грид
                }
             }
            dataGridView1.Refresh(); // обновляем грид
        }

        //Кнопка удалить строку клиента
        private void Button7_Click(object sender, EventArgs e)
        {
            dataGridView1.Refresh(); // обновляем грид
            if (dataGridView1.SelectedRows.Count > 0)
            {
                MessageBox.Show("ВНИМАНИЕ!!! ОБЬЕКТ ВСЕГДА БУДЕТ УДАЛЕН ИЗ БД.");
                using (var db2 = new TablGoogleContext())
                {

                    int index = dataGridView1.SelectedRows[0].Index;
                    int id = 0;
                    bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                    if (converted == false)
                        return;

                    TablGoogle tablGoogle = db2.TablGoogles.Find(id); 
                    db2.TablGoogles.Remove(tablGoogle);
                    db2.SaveChanges();
                }
                MessageBox.Show("Объект удален");
            }
           // dataGridView1.Refresh(); // обновляем грид
        }
    }
}
