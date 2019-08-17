using ConsoleApp.Model;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.OleDb;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using Excel = Microsoft.Office.Interop.Excel;
//using CodeFirst;

namespace ConsoleApp
{
    class Program
    {
      static  public Phone Phone { get; private set; }
       static string log = "Журнал событий: \t\n";

        static List<string> TestListGetBDTable = new List<string>();
        static List<int> TestListGetBDTableIDCllient = new List<int>();

        //Команда Update-Package

        //Источник
        //https://developers.google.com/sheets/api/quickstart/dotnet
        //Install-Package Google.Apis.Sheets.v4

        //http://qaru.site/questions/14594846/checking-for-empty-cells-in-google-sheets-using-c-via-google-sheets-api-v4/23537991
        // Примеры добавления в бд

        //  Пример как настроить Entity Framework + SQLite
        //https://ru.stackoverflow.com/questions/596782/entity-framework-sqlite

        //Работа с БД удаление очистка sqllite
        // DELETE FROM TablGoogles;
        //SELECT* FROM TablGoogles;
        //https://zametkinapolyah.ru/zametki-o-mysql/chast-10-5-udalenie-dannyx-i-strok-iz-tablicy-bazy-dannyx-sqlite.html

        //Программа для работы в трее
        //https://www.youtube.com/watch?v=ehnKtL9mCdg


        // При изменении этих областей удалите ранее сохраненные учетные данные
        // at ~/.credentials/sheets.googleapis.com-dotnet-quickstart.json
        static string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        static string ApplicationName = "Google Sheets API .NET Quickstart";
        //static string ApplicationName = "Тимы клиентов"; // имя аодключения
        static void Main(string[] args)
        {
            // test2(); // Загрузка  из гугл таблиц и добавления их в БД
            // LinoConneckt();  //Тестовой метод получения данных
            // Console.WriteLine( GetCountTablGoogle()); // получение количество сток из БД
            //  AddClientTablGoogle("Тестовая строка","51215658", "****");
            // Console.WriteLine($"После добавление новой строки в ручную {GetCountTablGoogle()}"); ; // получение количество сток из БД
            // DeleteClientTablGoogle(1204); // удаление по ID
            // Console.WriteLine($"После Удаление по ID строки в ручную {GetCountTablGoogle()}");
            
            //Поиск по имени
            // SeachNameClient("ООО Алар");//Поиск по имени ПОКА НЕ РАБОТАЕТ Ы

            GetClient(); //Вывод из бд

            //запосы лино
            //https://www.youtube.com/watch?v=ySDvruLcn2I&t=1555s
            RabotaLinfCodeBlok();

            Console.ReadKey();
        }

        /// <summary>
        /// Добавление в БД гугле таблиц НЕ использовать
        /// </summary>
        public static void ConnektGoogleTabl()
        {
            using (TablGoogleContext db = new TablGoogleContext())
            {
                // создаем два объекта User
                TablGoogle tablGoogle = new TablGoogle { NameClienta = "Первый клиент", PassClient = "12345" };
                TablGoogle tablGoogle2 = new TablGoogle { NameClienta = "Второй клиент", PassClient = "7777" };
                // User user2 = new User { Name = "Второнах", Age = 25 };

                // добавляем их в бд
                db.TablGoogles.Add(tablGoogle);
                db.TablGoogles.Add(tablGoogle2);
                //db.Users.Add(user1);
                //db.Users.Add(user2);
                db.SaveChanges(); // сохранение действий с БД

                log += "Записанный в БД текущие обьекты: \t\n tablGoogle и tablGoogle2 \t\n";

                Console.WriteLine("Что то записалось в БД");
            }

            Console.WriteLine(log);
            Console.ReadKey();
        }


        //НЕ использовать
        public static void AddTableToSqllite(TablGoogle tablGoogle)
        {
            using (TablGoogleContext db = new TablGoogleContext())
            {
                // создаем два объекта User
                TablGoogle tablGoogle1 = new TablGoogle();
                tablGoogle1 = tablGoogle;
                // TablGoogle tablGoogle2 = new TablGoogle { NameClienta = "Второй клиент", PassClient = "7777" };
                // User user2 = new User { Name = "Второнах", Age = 25 };

                // добавляем их в бд
                db.TablGoogles.Add(tablGoogle);
                //db.TablGoogles.Add(tablGoogle2);
                //db.Users.Add(user1);
                //db.Users.Add(user2);
                db.SaveChanges(); // сохранение действий с БД

                // log += "Записанный в БД текущие обьекты: \t\n tablGoogle и tablGoogle2 \t\n";

                // Console.WriteLine($"Что то записалось в БД{tablGoogle1}");
            }

            //   Console.WriteLine(log);
            // Console.ReadKey();
        }



        /// <summary>
        /// Полученние данных из БД из Таблиц гугла
        /// </summary>
        public static void AddDataTableGoogle()
        {

            using (TablGoogleContext db = new TablGoogleContext())
            {
                Console.WriteLine("Получение данных из БД");


                var temDb = db.TablGoogles; // получаем данные из Базы lанных
                log += $"Получаем данные из Базы данных!!!\t\n Количество элементов в БД {temDb.Count()}\t\n";

                foreach (TablGoogle user in temDb)
                {
                    string tempUsr = $"ID{user.Id} ИМЯ:{user.NameClienta} Телефоны:{user.PassClient} \t\n";
                    Console.WriteLine(tempUsr);
                    SaveFileText(tempUsr, "logWriterBD.txt");
                }

            }
            Console.WriteLine(log);
            Console.ReadKey();
        }

   
        /// <summary>
        /// Запись текста в файл
        /// </summary>
        /// <param name="text"></param>
        public static void SaveFileText(string text, string nameLog = "Тимы клиентов.txt")
        {
            // string patchText = "Тимы клиентов.txt";
            string patchText = nameLog;

            try
            {   // запись в файл. С дозаписью
                using (StreamWriter sw = new StreamWriter(patchText, true, System.Text.Encoding.Default))
                {
                    // sw.WriteLine("Дозапись");
                    sw.Write(text+"\t\n"); // запись
                }
            }
            catch (Exception ex)
            {
                log += "АХТУНГ призошла ошибка при записи текстового файла";
            }

        }
       
        
        
        /// <summary>
        /// Запись в таблицу ексель Пока не работает
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
                Console.WriteLine("Ошибка при записи в ексель файл " + ex);
                // MessageBox.Show("Error :" + ex.ToString());

            }
            Console.ReadKey();
        }

        /// <summary>
        /// Строка подключения к ексель странице
        /// </summary>
        /// <returns></returns>
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
        /// Скачиваем данные из таблицы гугл. Тимы и пароли и запысываем в sqllite
        /// </summary>
        public static void test2()
        {
            UserCredential credential;
            Stopwatch watch = new Stopwatch(); //обьект для замера времени работы программы
            watch.Start();

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
            string temph = "";

            using (TablGoogleContext db = new TablGoogleContext())
            {
                // создаем два объекта TablGoogle
                TablGoogle tablGoogle = new TablGoogle();

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

                        TablGoogle tablGoogle1 = new TablGoogle { NameClienta = row[0].ToString(), TelefonClient = row[1].ToString(), PassClient = row[2].ToString(), DataTimeAddTable=(DateTime.Now.ToString()) };
                        
                        db.TablGoogles.Add(tablGoogle1); // добавление в бд
                      //  db.SaveChanges(); // выходят ошибки
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
                //watch.Stop();
                Console.WriteLine($"Завершино Всего в списке {variableStirnTable} строк! \t\nИдет добавление данных в БД \t\n Ожидайте....");
                db.SaveChanges(); // сохранение действий с БД
                Console.WriteLine("Завершено!! Нажмите любую кнопку");
                watch.Stop();
               // Console.Read();
            }

            Console.WriteLine($"Завершино Всего в списке {variableStirnTable} строк!/t/n Полученно перебором{countStirnTable}\t\n Время получения списка пользователей и добавения данных {watch.ElapsedMilliseconds} милисекунд или {watch.Elapsed.Seconds}секунд \t\n");
            Console.Read();
            Console.Read();
        }

        /// <summary>
        /// Тестовой метод для работы с запросами Linq
        /// </summary>
        public static void LinoConneckt()
        {
            //https://www.youtube.com/watch?v=3yb4idCg-Qs&t=6859s
            //https://www.youtube.com/watch?v=ySDvruLcn2I&t=1076s

            using (var context = new TablGoogleContext()) // экземлряр контекства для связи с бд
            {
                var table = new TablGoogle();  
                context.TablGoogles.Load(); //Загрузка данных из БД

                var temp = context.TablGoogles.Local.ToBindingList(); //выгружаем в локальный кеш данне из бд

                int tempCant = temp.Count;  //количество элементов
                string tempZnach = "";

                foreach (var tt in temp.Reverse()) // Выводим с помощью реверса. Сначало последние
                {
                    table.Id = tt.Id;
                    table.NameClienta = tt.NameClienta;

                    //if (table.Id <= 20)
                    //{
                        tempZnach += $"ID{table.Id},\t\n ИМЯ {table.NameClienta} \t\n ";
                   // }
                    
                }

                //string temp1 = temp.
                
                    Console.WriteLine($"Общие количество записей {tempCant}");
                    Console.WriteLine(tempZnach);
                // this.DataContext = db.Phones.Local.ToBindingList();
            }
            Console.ReadKey();
        }
        /// <summary>
        /// Получение общего количества строк в таблице
        /// </summary>
        /// <returns></returns>
        public static int GetCountTablGoogle()
        {
            int rezultat;

            using (var db = new TablGoogleContext())
            {
                db.TablGoogles.Load(); //Загрузка данных из БД

                rezultat = db.TablGoogles.Local.ToBindingList().Count(); //выгружаем в локальный кеш данне из бд
            }
            return rezultat;
        }

        /// <summary>
        /// Добавление новой строки в таблицу
        /// </summary>
        /// <param name="nameClient"></param>
        /// <param name="passClient"></param>
        /// <param name="telefonClient"></param>
        public static void AddClientTablGoogle(string nameClient, string passClient,string telefonClient )
        {
            //Обект для доавления в БД
            TablGoogle adduserTable = new TablGoogle()
            {
                NameClienta = nameClient,
                PassClient = passClient,
                TelefonClient = telefonClient,
                DataTimeAddTable = DateTime.Now.ToString()
            };

            using (var db = new TablGoogleContext())// конткст для работы с базой данной
            {
                db.TablGoogles.Load(); // загрузка текущего стостояния бд в локальный кэш

                db.TablGoogles.Add(adduserTable); // добавление новой строки

                db.SaveChanges(); // сохранение изменения в БД
            }
        }

        /// <summary>
        /// Удаление нужной строки по id 
        /// </summary>
        /// <param name="idClienta"></param>
        public static void DeleteClientTablGoogle(int idClienta)
        {
            string tempLog = $"Удаленна строка под ID {idClienta}";

            //Обект для доавления в БД
            TablGoogle adduserTable = new TablGoogle();
             
            using (var db = new TablGoogleContext())// конткст для работы с базой данной
            {
                TablGoogle adduserTable2 = new TablGoogle();

                db.TablGoogles.Load(); // загрузка текущего стостояния бд в локальный кэш

                adduserTable2 = db.TablGoogles.Find(idClienta);

                db.TablGoogles.Remove(adduserTable2);// удаление нужной строки

                db.SaveChanges(); // сохранение изменения в БД
            }
        }

        /// <summary>
        /// Поиск по точному значению
        /// </summary>
        /// <param name="nameClient"></param>
        public static void SeachNameClient(string nameClient)
        {
            string tempLog = $"Поиск в таблице по имени клиента {nameClient} ";
            List<TablGoogle> lisTtablGoogles = new List<TablGoogle>(); // лист для хранения найденных элементов
            TablGoogle tablGoogle = new TablGoogle();

            #region Поиск по "строгой" строке.
            //using (var db = new TablGoogleContext()) // контекст для связи с бд
            //{
            //     db.TablGoogles.Load(); // загрузка базы в локальный кэш

            //    foreach (var tenCount in db.TablGoogles)
            //    {
            //        if(tenCount.NameClienta  == nameClient)
            //        {
            //            lisTtablGoogles.Add(tenCount);
            //           // Console.WriteLine(tenCount.NameClienta);
            //        }
            //    }

            //    foreach (var listTemp in lisTtablGoogles)
            //    {
            //        Console.WriteLine(listTemp.NameClienta);
            //    }
            //}

            #endregion

            using (var db2 = new TablGoogleContext())
            {
                db2.TablGoogles.Load();
                var name = db2.TablGoogles.Select(c=>c.NameClienta).FirstOrDefault();  // Вывод первого значения с строке
               IQueryable<string> nameSeach = db2.TablGoogles.Select(c=> c.NameClienta).Where(c=>c.Contains(nameClient));
                var temp = (from t in db2.TablGoogles where t.NameClienta.ToUpper().StartsWith(nameClient) select t).ToString();
                //var seahs = db2.TablGoogles.Where(t => t.NameClienta.ToUpper("А").OrderBy());

                Console.WriteLine($"Поиск 1{name}");
                Console.WriteLine($"Поиск 2---{nameSeach}");
                Console.WriteLine($"Поиск 3---{temp}");

                foreach (var ss in temp)
                {
                   // Console.WriteLine(ss);
                }
            }
            Console.WriteLine("Поиск завершен...Нажмите любую кнопку");
            Console.ReadKey();
        }

        /// <summary>
        /// Вывод всех данных из БД + поиск по слову
        /// </summary>
        public static void GetClient()
        {
            using (TablGoogleContext tablGoogle = new TablGoogleContext())
            {
                string temp = "ООО"; // переменная хранит  искомая имя
                string tempResult = "";
                int tempResultOD ;
                foreach (TablGoogle googleTable in tablGoogle.TablGoogles)
                {
                    if (googleTable.NameClienta.Contains(temp))
                    {
                        tempResult += $"{googleTable.Id} {googleTable.NameClienta}  \t\n";
                        tempResultOD = googleTable.Id;
                        TestListGetBDTable.Add(tempResult);
                        TestListGetBDTableIDCllient.Add(tempResultOD);


                    }
                    //Console.WriteLine(tempResult);
                }
                Console.WriteLine(tempResult);
                Console.WriteLine($"Количество найденых клиентов:{TestListGetBDTable.Count}");
            }
        }

        /// <summary>
        /// Тестовой метод работы с линг от codeBlog
        /// </summary>
        public static void RabotaLinfCodeBlok()
        {

            var resultGetLinq = from item in TestListGetBDTableIDCllient // указываем откудв азять и куда положить
                                where item <100  // условие быборки
                                select item ; // фыбираем и фиксируем нужнве изменнения 
            Console.WriteLine("Вывод списка клиентов");
            //линк запрос с помощь. метода разширений и лямба методов
            var result2 = TestListGetBDTableIDCllient.Where(item => item > 1000 & item < 1050);

            foreach (var temp in result2)
            {
                Console.WriteLine(temp);
            }

          //  var result2 = TestListGetBDTableIDCllient.Where(item => item > 1000 & item < 1010);
            Console.WriteLine("Для завершения нажмите любую клавишу");
            Console.ReadKey();
        }


    }


      


}
    
