﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya
{
    static class SomeClass
    {
        //Статичное поле, которое хранит значение для передачи его между формами
        public static string variable_class;
        //Статичное поле, которое хранит значения ID добавленного клиента на Form15-addClient
        public static string new_inserted_id;
        //Статичное поле, которое хранит значение ID добаленного заказа
        public static string new_inserted_mainOrder_id;
        public static string aeee;

    }
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Menu());
        }
    }
}
