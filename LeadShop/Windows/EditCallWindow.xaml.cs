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
using System.Windows.Shapes;
using LeadShop.EF;

namespace LeadShop.Windows
{
    /// <summary>
    /// Interaction logic for EditCallWindow.xaml
    /// </summary>
    public partial class EditCallWindow : Window
    {
        private bool _isToUpdate = false;

        public Call Call { get; set; }

        public EditCallWindow()
        {
            InitializeComponent();
        }

        public EditCallWindow(Call call) : this()
        {
            _isToUpdate = true;
            Call = call;
        }
    }
}
