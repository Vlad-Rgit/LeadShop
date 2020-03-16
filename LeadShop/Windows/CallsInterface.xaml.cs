using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using LeadShop.EF;

namespace LeadShop.Windows
{
    /// <summary>
    /// Interaction logic for CallsInterface.xaml
    /// </summary>
    public partial class CallsInterface : Window
    {

        private Context _context = App.Current.Resources["Context"] as Context;
        private User _currentUser;

        public ObservableCollection<Call> Calls { get; set; }
        public ObservableCollection<User> Users { get; set; }
        public User CurrentUser
        {
            get => _currentUser;

            set
            {
                _currentUser = value;

                if(Calls!=null)
                 UpdateCalls();
            }
        }

        public CallsInterface(User currentUser) 
        {
            CurrentUser = currentUser;
            InitializeCollections();
            InitializeComponent();
        }

        private void InitializeCollections()
        {
            Calls = new ObservableCollection<Call>(CurrentUser.Calls);
            Users = new ObservableCollection<User>(_context.Users);
        }

        private void UpdateCalls()
        {
            Calls.Clear();

            foreach (var c in CurrentUser.Calls)
                Calls.Add(c);
        }

        private void ListViewItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            editMenu.IsOpen = true;
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            User selectedUser = view_calls.SelectedItem as User;
            EditCallWindow win = new EditCallWindow(selectedUser);
            win.ShowDialog();

            _context.Entry(selectedUser).Reload();
        }

        private void CreateCallClick(object sender, RoutedEventArgs e)
        {
            EditCallWindow win = new EditCallWindow();
            win.ShowDialog();

            if(win.DialogResult == true)
            {
                Calls.Add(_context.Calls.ToList().Last());
            }
        }
    }
}
