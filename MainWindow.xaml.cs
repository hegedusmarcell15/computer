using System;
using System.Collections.Generic;
using System.Data;
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
            ReadComputer();
        }

        private const string ConnString = "Server=localhost;Database=computer;Uid=root;SslMode=None";
        private void Rendszer_Click(object sender, RoutedEventArgs e)
        {
            ReadOsystem();
        }
        private void computer_Click(object sender, RoutedEventArgs e)
        {
            ReadComputer();
        }
        private void ReadComputer()
        {
            try
            {
                using (var conn = new MySqlConnection(ConnString))
                {
                    string sql = "SELECT * FROM `comp`";

                    conn.Open();
                    using (var da = new MySqlDataAdapter(sql, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DG_adatok.ItemsSource = dt.DefaultView;
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void ReadOsystem()
        {
            try
            {
                using (var conn= new MySqlConnection(ConnString))
                {
                    string sql = "SELECT * FROM `osystem`";

                    conn.Open();
                    using (var da = new MySqlDataAdapter(sql, conn))
                    {

                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        DG_adatok.ItemsSource = dt.DefaultView;



                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            }
        }
    }
