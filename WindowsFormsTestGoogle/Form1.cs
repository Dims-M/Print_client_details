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
        }


        //Область для вывода данных
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
            dataGridView1.DataSource = googleContext2.TablGoogles.Local.ToBindingList(); // загрузка контекста в дату гриф

        }
    }
}
