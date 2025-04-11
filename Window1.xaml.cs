using MySql.Data.MySqlClient;
using System;
using System.Windows;

namespace szamitogepek
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private const string ConnectionString = "Server=localhost;Database=computer;Uid=root;Sslmode=None";

        private bool Beleptetes(string username, string password)
        {
            try
            {
                using (var connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();

                    string sql = "SELECT ID FROM users WHERE felhasznalonev = @username AND jelszo = @password";

                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    MySqlDataReader dr = cmd.ExecuteReader();

                    bool van = dr.Read();

                    if (van)
                    {
                        GlobalUser.Id = dr.GetInt32("ID");
                    }

                    return van;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt: " + ex.Message);
                return false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string username = tb_felhasznalonev.Text;
                string password = tb_jelszo.Password;

                if (Beleptetes(username, password))
                {
                    MessageBox.Show("Sikeres bejelentkezés!");

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Hibás felhasználónév vagy jelszó!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba: " + ex.Message);
            }
        }
    }


    public static class GlobalUser
    {
        public static int Id { get; set; }
    }
}