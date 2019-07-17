using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    
    /// <summary>
    /// Класс отвечаюсь за представление с колонками в БД
    /// </summary>
        public class Phone : INotifyPropertyChanged
        {
            private string title;
            private string company;
            private int price;
            private DateTime dateTime;

            public int Id { get; set; }

            public string NameLogin
        {
                get { return title; }
                set
                {
                    title = value;
                    OnPropertyChanged("Title");
                }
            }
            public string Company
        {
                get { return company; }
                set
                {
                    company = value;
                    OnPropertyChanged("Company");
                }
            }
            public int NamePass
        {
                get { return price; }
                set
                {
                    price = value;
                    OnPropertyChanged("Price");
                }
            }


        public int DateTimeAdd
        {
            get { return Convert.ToInt32(dateTime); }
            set
            {
                dateTime = Convert.ToDateTime(value);
                OnPropertyChanged("Price");
            }
        }

        
        /// <summary>
        /// Делегат события
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged([CallerMemberName]string prop = "")
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }

