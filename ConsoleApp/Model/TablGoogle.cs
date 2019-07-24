﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Model
{
    /// <summary>
    /// Класс описывает пользователя
    /// Каждое свойство будет сопоставляться с отдельным столбцом в таблице из бд.
    /// </summary>
   public class TablGoogle
    {
        //Автосвойства для хранения данных плучаемых из БД
        public int Id { get; set; }
        public string NameClienta { get; set; }
        public string PassClient { get; set; }
    }
}
