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
             //List<IList<string>> values = response.Values.ToList<string>; // получаем таблицу
            //List<string> values = response.Values.ToList<>;

           // values.

            //    if (values == null && values.Count < 0)

            //  {
            //if (values != null && values.Count > 0)
            //{
            //   // values.Add();
            //}
            var tempList = new List<string>();

            foreach (var tempListtt in  values)
            {
                tempList.Add(tempListtt.ToString());
                
            }

            foreach (var tempListtt in tempList)
            {
                Console.WriteLine(tempListtt);

            }

            Console.WriteLine("Содержимое таблицы");

           // tempList.AddRange(values.);

            int inputId = 1234;
            string temph= "";

            foreach (var row in values)
            {
                for (int i =0; i< values.Count; i++)
                {

               try{

              if (  values.Contains(null))
                        {
                            Console.WriteLine("Ошибка");
                          //  values.Remove( Convert( row[i]));
                            Console.ReadKey();
                        }


                if (row[0] == null || string.IsNullOrEmpty(Convert.ToString(row[0])))
                {
                            // row[0] = inputId ;
                            continue;
                }

                if (row[1] == null) // || string.IsNullOrEmpty(Convert.ToString(row[1])))
                {
                      row[i] = "11";
                   //string temppp = row[1].ToString() ?? "незаданно";


                            i++;
                            // row[i] = inputId;
                            continue;
                        }

                if (row[2] == null || string.IsNullOrEmpty(Convert.ToString(row[2])))
                {
                   // row[2] = inputId;
                }

                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                       // row[i-1] += "yt pflfyyj";
                        //continue;

                        
                    }
                }
            }
            

                //for (int i= 0; i< values.Count; i++)
                //{
                //    Console.WriteLine(values.Count);
                //    if (string.IsNullOrEmpty(Convert.ToString(row[i])))
                //    {

                //        Console.WriteLine("Ошибка при проверке на null");
                //        continue;
                //    }
                //    Console.WriteLine(row[i]);
                //}

                //if (values != null && values.Count > 0)

                //if (row[1] == null)
                //{
                //    row[1] = "Незаданно!", ;
                //    Console.WriteLine("Ошибка массива!!!!!");
                //    row[1] = "Незаданно!";
                //}
                //     row.Insert(values.Count+1,tempList);
                //   // row[2] = "незаданно";

                // Print columns A and E, which correspond to indices 0 and 4.
                // Console.WriteLine("Организация: {0}, № телефона: {1}, пароль:{2}", row[0], row[1], row[2]);

                //if (row[1] == null || string.IsNullOrEmpty(Convert.ToString(row[1])))
                //{
                //    row[1] = 0;
                //}




                //  user?.Phone?.Company?.Name ?? "не установлено";
               // string temppp = row[1].ToString() ?? "незаданно";
                // onsole.WriteLine($"Организация: {row[0]},№ телефона: {row[1].ToString() ?? "незаданно"}");

                // Console.WriteLine($"Организация: {row[0]});//,№ телефона: {row[1].ToString() ?? "незаданно"}");
              //  Console.WriteLine(temppp);
                // FirstOrDefault

            
            //}

            //else
            //{
            Console.WriteLine("Завершино");
            //}
            Console.Read();
        }
    }

 }
    
