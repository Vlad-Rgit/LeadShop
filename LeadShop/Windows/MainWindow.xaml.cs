using System;
using System.Collections.Generic;
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
using LeadShop.EF;

namespace LeadShop.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Context _context = new Context();


        public MainWindow()
        {
            App.Current.Resources["Context"] = _context;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User user = GetUser(tbx_login.Text, tbx_password.Password);

            if(user == null)
            {
                MessageBox.Show("Неправильный логин или пароль");
            }
            else
            {
                CallsInterface win = new CallsInterface(user);
                this.Hide();
                win.ShowDialog();
                this.Show();
            }
        }


        private User GetUser(string login, string password)     
            => _context.Users.FirstOrDefault(u => u.Login == login && u.Password == password);

        
    }
}
