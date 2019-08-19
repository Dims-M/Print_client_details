
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
using ConsoleApp.Model; // 
using ConsoleApp;

namespace WindowsFormsTestGoogle
{
   public  class BL
    {
        //Коментарии
        //В окне менеджера Nuget введем в окно поиска "SQLite", и менеджер отобразит нам ряд результатов.
        //Из них нам надо установить пакет под названием System.Data.SqlClient:

        //ПЕРЕМЕННЫЕ
       // static public Phone Phone { get; private set; } //На удаление
        static string log = "Журнал событий: \t\n";

        static List<string> TestListGetBDTable = new List<string>();
        static List<int> TestListGetBDTableIDCllient = new List<int>();
        static List<TablGoogle> TestListTablGoogle = new List<TablGoogle>(); // Лист для хранения обьектов класса

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

        //запросы лино
        //https://www.youtube.com/watch?v=ySDvruLcn2I&t=1555s

        // При изменении этих областей удалите ранее сохраненные учетные данные
        // at ~/.credentials/sheets.googleapis.com-dotnet-quickstart.json
        static string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        static string ApplicationName = "Google Sheets API .NET Quickstart";
        //static string ApplicationName = "Тимы клиентов"; // имя аодключения

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
          //  Console.ReadKey();
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
                    sw.Write(text + "\t\n"); // запись
                }
            }
            catch (Exception ex)
            {
                log += "АХТУНГ призошла ошибка при записи текстового файла";
            }

        }


        /// <summary>
        /// Скачиваем данные из таблицы гугл. Тимы и пароли и запысываем в sqllite
        /// </summary>
        public static void test2()
        {
            UserCredential credential;
            Stopwatch watch = new Stopwatch(); //обьект для замера времени работы программы
            watch.Start(); //запуск программы замера

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
             //   Console.WriteLine("Файл учетных данных, сохраненный: " + credPath);
            }

            // Create Google Sheets API service.
            var service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Определение параметров запроса 
            //String spreadsheetId = "1BxiMVs0XRA5nFMdKvBdBZjgmUUqptlbs74OgvE2upms";
            String spreadsheetId = "1H6LEiczHkmw5tYBoO9nwR_fBXZTm4QAudwQDNYuIsDo";
            //  String range = "Class Data!A2:E";
            String range = "A2:E"; // с каких ящеек ищем

            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(spreadsheetId, range);

            // ПРИМЕР Печать имен и специальностей студентов в образце электронной таблицы:
            // https://docs.google.com/spreadsheets/d/1H6LEiczHkmw5tYBoO9nwR_fBXZTm4QAudwQDNYuIsDo/edit#gid=0
            // https://docs.google.com/spreadsheets/d/1BxiMVs0XRA5nFMdKvBdBZjgmUUqptlbs74OgvE2upms/edit

            ValueRange response = request.Execute();
            IList<IList<Object>> values = response.Values; // получаем таблицу с данными

           // Console.WriteLine("Содержимое таблицы");

            int countStirnTable = 0;
            int variableStirnTable = values.Count; //количество строк
            var tempList = new List<string>(); 
            string temph = "";

            using (TablGoogleContext db = new TablGoogleContext())
            {
                // создаем объект TablGoogle
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

                        TablGoogle tablGoogle1 = new TablGoogle { NameClienta = row[0].ToString(), TelefonClient = row[1].ToString(), PassClient = row[2].ToString(), DataTimeAddTable = (DateTime.Now.ToString()) };

                        db.TablGoogles.Add(tablGoogle1); // добавление в бд
                                                         //  db.SaveChanges(); // выходят ошибки
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
                //watch.Stop();
           //     Console.WriteLine($"Завершино Всего в списке {variableStirnTable} строк! \t\nИдет добавление данных в БД \t\n Ожидайте....");
                db.SaveChanges(); // сохранение действий с БД
             //   Console.WriteLine("Завершено!! Нажмите любую кнопку");
                watch.Stop();
                // Console.Read();
            }

          //  Console.WriteLine($"Завершино Всего в списке {variableStirnTable} строк!/t/n Полученно перебором{countStirnTable}\t\n Время получения списка пользователей и добавения данных {watch.ElapsedMilliseconds} милисекунд или {watch.Elapsed.Seconds}секунд \t\n");
          //  Console.Read();
          //  Console.Read();
        } // конец метода тест2

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
        /// Получение общего количества строк в таблице с помощью запроса к Бд
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
        public static void AddClientTablGoogle(string nameClient, string passClient, string telefonClient)
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

                // var resulIF = db.TablGoogles.Where(item => item.NameClienta != adduserTable.NameClienta); // 



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
        public static List<TablGoogle> SeachNameClient(string nameClient)
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
                var name = db2.TablGoogles.Select(c => c.NameClienta).FirstOrDefault();  // Вывод первого значения с строке
                IQueryable<string> nameSeach = db2.TablGoogles.Select(c => c.NameClienta).Where(c => c.Contains(nameClient));
                var temp = (from t in db2.TablGoogles where t.NameClienta.ToUpper().StartsWith(nameClient) select t).ToList();
                //var seahs = db2.TablGoogles.Where(t => t.NameClienta.ToUpper("А").OrderBy());

                Console.WriteLine($"Поиск 1{name}");
                Console.WriteLine($"Поиск 2---{nameSeach}");
                Console.WriteLine($"Поиск 3---{temp}");

                foreach (var ss in temp)
                {
                    // Console.WriteLine(ss);
                }
                return temp.ToList();
            }
            // Console.WriteLine("Поиск завершен...Нажмите любую кнопку");
            // Console.ReadKey();
             
        }

        /// <summary>
        /// Вывод всех данных из БД + поиск по слову
        /// </summary>
        public static List<string> GetClient()
        {
            using (TablGoogleContext tablGoogle = new TablGoogleContext())
            {
                string temp = "ООО"; // переменная хранит  искомая имя
                string tempResult = "";
                int tempResultOD;
                foreach (TablGoogle googleTable in tablGoogle.TablGoogles)
                {
                    if (googleTable.NameClienta.Contains(temp))
                    {
                        tempResult += $"{googleTable.Id} {googleTable.NameClienta}  \t\n";
                        tempResultOD = googleTable.Id;
                        TestListGetBDTable.Add(tempResult);
                        TestListGetBDTableIDCllient.Add(tempResultOD);
                        TestListTablGoogle.Add(googleTable);


                    }
                    //Console.WriteLine(tempResult);
                }
                return TestListGetBDTable;// List<string>;
              //  Console.WriteLine(tempResult);
              // Console.WriteLine($"Количество найденых клиентов:{TestListGetBDTable.Count}");
            }
        }

        /// <summary>
        /// Метод возращает реверсирование все строки из БД
        /// </summary>
        /// <returns></returns>
        public static List<TablGoogle> GetAllTablGoogle()
        {
            List<TablGoogle> tenpp = new List<TablGoogle>();

            using (var db2 = new TablGoogleContext())
            {
                db2.TablGoogles.Load();
                var temppppp = db2.TablGoogles.Local.ToBindingList();

                foreach (TablGoogle googleTable in temppppp.Reverse())
                {
                    tenpp.Add(googleTable);
                }
            }
            return tenpp;
         }

            public static List<TablGoogle> GetCountLastValue()
        {
            using (var db2 = new TablGoogleContext())
            {
                db2.TablGoogles.Load();
                var temppppp = db2.TablGoogles.Local.ToBindingList();

                //  var name = db2.TablGoogles.Select(c => c.NameClienta).FirstOrDefault();  // Вывод первого значения с строке
                //var temp = db2.TablGoogles.Select(c => c.NameClienta).Reverse().ToList();

                List<TablGoogle> tenpp = new List<TablGoogle>();
                // var ttttt = db2.TablGoogles.; //  SkipLast();
                // var temp = (from t in db2.TablGoogles where (t.NameClienta.ToUpper()).ToList());
                //
                int i = 0;
                foreach (TablGoogle googleTable in temppppp.Reverse())
                {
                     
                    tenpp.Add(googleTable);
                    i++;
                    if (i==10)
                    {
                        break;
                    }
                    
                }

                //  var temp = (from t in db2.TablGoogles where t.NameClienta.ToUpper().StartsWith(nameClient) select t).ToList();
                //var seahs = db2.TablGoogles.Where(t => t.NameClienta.ToUpper("А").OrderBy());
                return tenpp;
            }
        }
            /// <summary>
            /// Тестовой метод работы с линг от codeBlog
            /// </summary>
            public static void RabotaLinfCodeBlok()
        {
            //https://www.youtube.com/watch?v=ySDvruLcn2I&t=2922s

            var resultGetLinq = from item in TestListGetBDTableIDCllient // указываем откудв азять и куда положить
                                where item < 100  // условие быборки
                                select item; // фыбираем и фиксируем нужнве изменнения 
            Console.WriteLine("Вывод списка клиентов");
            //линк запрос с помощь. метода разширений и лямба методов
            var result2 = TestListGetBDTableIDCllient.Where(item => item > 1000 & item < 1050);

            //  var result2 = TestListGetBDTableIDCllient.Where(item => item > 1000 & item < 1010);

            var result3 = TestListTablGoogle.Where(item => item.TelefonClient == "9033149356");

            foreach (var temp in result3)
            {
                Console.WriteLine(temp);
            }

            Console.WriteLine("Для завершения нажмите любую клавишу");
            Console.WriteLine("Преоброзование одного типа в другой.");

            //Преоброзование одного типа в дугойй
            var selectColection = TestListTablGoogle.Select(nameCletnt => nameCletnt.NameClienta); //преоброзование
            var selectColectionPass = TestListTablGoogle.Select(nameCletnt => nameCletnt.PassClient); //преоброзование
            var selectColectionTelefon = TestListTablGoogle.Select(nameCletnt => nameCletnt.TelefonClient); //преоброзование

            var orderCollectoins = TestListTablGoogle.OrderBy(nameGet => nameGet.NameClienta); // упорядование по имени
                                                                                               //   var orderCollectoins = TestListTablGoogle.OrderBy(nameGet => nameGet.NameClienta); // упорядование по имени
            var orderCollectoinsPassClenta = TestListTablGoogle.OrderBy(nameGet => nameGet.TelefonClient).ThenBy(nameCleenta => nameCleenta.NameClienta); // упорядование по имени

            //обьединение в колекциях
            //  var arreyUnion = selectColectionTelefon.Union(selectColectionPass);

            // убираем повторение в колекциях 


            //Вывод колекции
            foreach (var temp in selectColectionTelefon)
            {
                Console.WriteLine(temp);
            }
            Console.WriteLine($"Количество значений{selectColectionTelefon.Count()}\t\nПосле******************");



            Console.ReadKey();
        }


    

    }
}
