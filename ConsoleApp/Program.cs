using ConsoleApp.Model;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace ConsoleApp
{
    class Program
    {
      static  public Phone Phone { get; private set; }
       static string log = "Журнал событий: \t\n";
       

        //Источник
        //https://developers.google.com/sheets/api/quickstart/dotnet
        //Install-Package Google.Apis.Sheets.v4

        //http://qaru.site/questions/14594846/checking-for-empty-cells-in-google-sheets-using-c-via-google-sheets-api-v4/23537991
        // Примеры добавления в бд

        // При изменении этих областей удалите ранее сохраненные учетные данные
        // at ~/.credentials/sheets.googleapis.com-dotnet-quickstart.json
        static string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        static string ApplicationName = "Google Sheets API .NET Quickstart";
        static void Main(string[] args)
        {
           //  test2();
            //connektDB();

           // ConnektEnityDBAddClass(); //работа с тестовой базой; //Добавление в БД
            AddDataUser(); //Чтение из БД

           // SaveExelTable(); //Запись в ексел Пока не работает
        }

        //НЕРАБОТАЕТ
        public static void connektBD()
        {

           // using (var db = new SQLiteConnection("mobiles.db", true))
            using (var context = new ApplicationContext() )
            {
                try
                {

                Console.WriteLine("Соединение с БД");
                Console.ReadKey();

                context.Phones.Add(new Phone() { NameLogin = "aaa111", Company = "bbb111", NamePass= 777, DateTimeAdd= 17111 });
               // context.Phones.Add(new Person() { Name = "aaa222", Surname = "bbb222" });
              ///  context.Phones.Add(new Person() { Name = "aaa333", Surname = "bbb333" });

                    // SQLiteCommand command = new SQLiteCommand("SELECT * FROM 'Phones';");

                    // SQLiteDataReader people = command.ExecuteReader();

                    // while (people.Read())
                    //{
                    //    object getname = people[0];
                    //    Console.WriteLine(getname);
                    //}


                }

                catch (Exception ex)
                {
                    Console.WriteLine("Соединение с БД"+ex);
                    Console.ReadKey();
                }
              //  db.Close();
            }

            Console.WriteLine("Конец метода Соединение с БД");
            Console.ReadKey();
        }

        /// <summary>
        /// тестовой метод присоединение к БД
        /// </summary>
        public static void connektDB()
        {
            //const string databaseName = @"mobiles.db;
            //SQLiteConnection connection =
            //new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            //connection.Open();
            //SQLiteCommand command = new SQLiteCommand("SELECT name FROM sqlite_master WHERE type='table' ORDER BY name;", connection);
            //SQLiteDataReader reader = command.ExecuteReader();
            //foreach (DbDataRecord record in reader)
            //    Console.WriteLine("Таблица: " + record["name"]);
            //connection.Close();
            //Console.WriteLine("Готово");
            //Console.ReadKey(true);
            //string db = "mobiles.db";

            //string connectBD = "testDB.db";

            //try
            //{
            //    connectionBDTEst = new SQLiteConnection("Data Sourse=testDB.bd; Version=3");
            //    connectionBDTEst.Open();

            //    Console.ReadKey();
            //}
            //catch(Exception ex)
            //{
            //    log += "Ошибка при подключению к БД testDB.bd \t\n";
            //    log += ex.ToString();
            //    Console.WriteLine(log);
            //}


            Console.ReadKey();



        }

        /// <summary>
        /// Добавление в данных в БД
        /// </summary>
        public static void ConnektEnityDBAddClass()
        {
            using (UserContext db = new UserContext())
            {
                // создаем два объекта User
                User user1 = new User { Name = "Первонах", Age = 30 };
                User user2 = new User { Name = "Второнах", Age = 25 };

                // добавляем их в бд
                db.Users.Add(user1);
                db.Users.Add(user2);
                db.SaveChanges(); // сохранение действий с БД

                log += "Записанный в БД текущие обьекты: \t\n user1 и user2 \t\n";

                Console.WriteLine("Что то записалось в БД");
            }
            Console.WriteLine(log);
            Console.ReadKey();

            
        }

        public static void ConnektEnityGoogleTabl()
        {
            using (UserContext db = new UserContext())
            {
                // создаем два объекта User
                User user1 = new User { Name = "Первонах", Age = 30 };
                User user2 = new User { Name = "Второнах", Age = 25 };

                // добавляем их в бд
                db.Users.Add(user1);
                db.Users.Add(user2);
                db.SaveChanges(); // сохранение действий с БД

                log += "Записанный в БД текущие обьекты: \t\n user1 и user2 \t\n";

                Console.WriteLine("Что то записалось в БД");
            }
            Console.WriteLine(log);
            Console.ReadKey();


        }

        /// <summary>
        /// Полученние данных из БД
        /// </summary>
        public static void AddDataUser()
        {
            
            using (UserContext db = new UserContext())
            {
                Console.WriteLine("Получение данных из БД");


                var temDb = db.Users; // получаем данные из Базы жанных
                log += $"Получаем данные из Базы данных!!!\t\n Количество элементов в БД {temDb.Count()}\t\n" ;

                foreach (User user in temDb)
                {
                    string tempUsr = $"ID{user.Id} ИМЯ:{user.Name} Возраст:{user.Age} \t\n";
                    Console.WriteLine(tempUsr);
                    SaveFileText(tempUsr,"logWriterBD.txt");
                }
                
            }
            Console.WriteLine(log);
            Console.ReadKey();
        }

        /// <summary>
        /// Запись текста в файл
        /// </summary>
        /// <param name="text"></param>
        public static void SaveFileText( string text, string nameLog = "Тимы клиентов.txt")
        {
           // string patchText = "Тимы клиентов.txt";
            string patchText = nameLog;

            try
            {   // запись в файл. С дозаписью
                using (StreamWriter sw = new StreamWriter(patchText, true, System.Text.Encoding.Default))
                {
                   // sw.WriteLine("Дозапись");
                    sw.Write(text); // запись
                }
            }
            catch (Exception ex)
            {
                log+="АХТУНГ призошла ошибка при записи текстового файла";
            }

        }
        /// <summary>
        /// Запись в таблицу ексель
        /// </summary>


        public static void SaveExelTable()
        {
            // https://www.codeproject.com/Tips/705470/Read-and-Write-Excel-Documents-Using-OLEDB
            //http://www.cyberforum.ru/csharp-net/thread709715.html
            Console.WriteLine("Попытка записи в ексель файл ");
          //  string path = "c:\\Jurnal\\Журнал учета файлов.xls";
            string path = "Журнал учета файлов.xls"; //

            if (!File.Exists(path))
                SQLiteConnection.CreateFile(path);

            string coonekTexel = GetConnectionString();

           // OleDbConnection excelConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source='Журнал учета файлов.xls';Extended Properties=Excel 12.0;");
            OleDbConnection excelConnection = new OleDbConnection(coonekTexel);

            try
            {

               string nameoffile = "Тест1";
                long fsize = 1050;
                string date_cr = "2019";
               string date_cr_time = DateTime.Now.ToString();
                int nom = 1;

                 string sqlStquery = "Insert into [БД$]([Имя файла],[Размер файла],[Дата создания],[Время создания],[Номер]) Values('" + nameoffile + "','"
                    + fsize + "','" + date_cr + "','" + date_cr_time + "','" + nom + "')";
               // string еучеее = "текстовой текст";
               // string sqlStquery =  "Insert into [БД$]([Имя файла] Values('"+еучеее+"')";

                excelConnection.Open();

                OleDbDataAdapter dbadapter = new OleDbDataAdapter(sqlStquery, excelConnection);

                dbadapter.SelectCommand.ExecuteNonQuery();
                dbadapter.Dispose();


                excelConnection.Close();
                excelConnection.Dispose();
            }
            catch (Exception ex)
            {
                excelConnection.Close();
                excelConnection.Dispose();
                Console.WriteLine("Ошибка при записи в ексель файл "+ex);
                // MessageBox.Show("Error :" + ex.ToString());

            }
            Console.ReadKey();
        }

        private static string GetConnectionString()
        {
            Dictionary<string, string> props = new Dictionary<string, string>();
            string path = "Журнал учета файлов.xls"; //
            // XLSX - Excel 2007, 2010, 2012, 2013
            props["Provider"] = "Microsoft.ACE.OLEDB.12.0;";
            props["Extended Properties"] = "Excel 12.0 XML";
           // props["Data Source"] = "C:\\MyExcel.xlsx";
            props["Data Source"] = path;

            // XLS - Excel 2003 and Older
            //props["Provider"] = "Microsoft.Jet.OLEDB.4.0";
            //props["Extended Properties"] = "Excel 8.0";
            //props["Data Source"] = "C:\\MyExcel.xls";

            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string, string> prop in props)
            {
                sb.Append(prop.Key);
                sb.Append('=');
                sb.Append(prop.Value);
                sb.Append(';');
            }

            return sb.ToString();
        }

        /// <summary>
        /// Скачиваем данные из таблицы гугл. Тимы и пароли
        /// </summary>
        public static void test2()
        {
            UserCredential credential;

            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // Маркер файла.json сохраняет маркеры доступа и обновления пользователя
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                                Scopes,
                                "user",
                                CancellationToken.None,
                                new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Файл учетных данных, сохраненный: " + credPath);
            }

            // Create Google Sheets API service.
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define request parameters.
            //String spreadsheetId = "1BxiMVs0XRA5nFMdKvBdBZjgmUUqptlbs74OgvE2upms";
            String spreadsheetId = "1H6LEiczHkmw5tYBoO9nwR_fBXZTm4QAudwQDNYuIsDo";
            //  String range = "Class Data!A2:E";
            String range = "A2:E"; // с каких ящеек ищем

            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(spreadsheetId, range);

            // Prints the names and majors of students in a sample spreadsheet:
            // https://docs.google.com/spreadsheets/d/1H6LEiczHkmw5tYBoO9nwR_fBXZTm4QAudwQDNYuIsDo/edit#gid=0
            // https://docs.google.com/spreadsheets/d/1BxiMVs0XRA5nFMdKvBdBZjgmUUqptlbs74OgvE2upms/edit

            ValueRange response = request.Execute();
             IList<IList<Object>> values = response.Values; // получаем таблицу
           
            Console.WriteLine("Содержимое таблицы");

            int countStirnTable = 0;
            int variableStirnTable = values.Count;
            var tempList = new List<string>();
            string temph= "";


            foreach (var row in values)
            {
                    try
                    {
                    temph = $"Организация: {row[0]}, № телефона: {row[1]}, пароль:{row[2]}";

                    // Console.WriteLine("Организация: {0}, № телефона: {1}, пароль:{2}", row[0], row[1], row[2]);
                    Console.WriteLine(temph);
                    tempList.Add(temph);
                     countStirnTable++;
                    SaveFileText(temph);
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex); 
                    }
                }
         
            Console.WriteLine($"Завершино Всего в списке {variableStirnTable} строк!/t/n Полученно перебором{countStirnTable}");
            
            Console.Read();
        }
    }

}
    
