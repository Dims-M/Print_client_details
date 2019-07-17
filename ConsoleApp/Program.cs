using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
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
            test2();
        }

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
    
