using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
      static  public Phone Phone { get; private set; }

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
            // test2();
            connektBD();
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

        public void connektDB()
        {
            const string databaseName = @"mobiles.db;
            SQLiteConnection connection =
            new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT name FROM sqlite_master WHERE type='table' ORDER BY name;", connection);
            SQLiteDataReader reader = command.ExecuteReader();
            foreach (DbDataRecord record in reader)
                Console.WriteLine("Таблица: " + record["name"]);
            connection.Close();
            Console.WriteLine("Готово");
            Console.ReadKey(true);
            string db = "mobiles.db";

        }


        /// <summary>
        /// Метод для считывания страниц таблиц гугла
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
    
