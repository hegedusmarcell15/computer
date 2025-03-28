using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace szamitogepek
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DG_restock();
        }
        private const string ConnectionSrting = "Server = localhost;Database=computer;Uid=root;password=;Sslmode=None";
        private bool DG_restock() 
        
        {
            using (var connection = new MySqlConnection(ConnectionSrting))
            {
                connection.Open();

                string sql = $"SELECT `beszelgetesneve` FROM `blogtemak`";
                MySqlCommand cmd = new MySqlCommand(sql, connection);

                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    var comment = new
                    {
                        name = dr.GetString(0)
                    };
                   
                }


                connection.Close();


                return true;
            }
        }
    }
}
