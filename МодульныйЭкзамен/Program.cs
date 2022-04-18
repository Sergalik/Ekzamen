using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace МодульныйЭкзамен
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static void conn(out SqlConnection dbConnection)
        {
            string ConnStr = "Data Source=ngknn.ru;Initial Catalog=Экзамен_ПМ01_СидоровАлексей;User ID=44П;Password=H12TjtrV";
            dbConnection = new SqlConnection(ConnStr);
            dbConnection.Open();
        }

        internal static class DataSave
        {
            public static string DataValue { get; set; }
            public static int id { get; set; }
            public static DataTable table { get; set; }
            public static SqlCommand cmd { get; set; }
            public static string nameButton { get; set; }
            public static int tableRow { get; set; }



        }
    }
}
