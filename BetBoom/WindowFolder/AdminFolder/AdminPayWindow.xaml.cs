using BetBoom.DataFolder;
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

namespace BetBoom.WindowFolder.AdminFolder
{
    /// <summary>
    /// Логика взаимодействия для AdminPayWindow.xaml
    /// </summary>
    public partial class AdminPayWindow : Window
    {
        public AdminPayWindow()
        {
            InitializeComponent();
            LoginDG.ItemsSource = DBEntities.GetContext().User.ToList().
                OrderBy(c => c.LoginUser);
        }

        private void GoPayBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoginTb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
