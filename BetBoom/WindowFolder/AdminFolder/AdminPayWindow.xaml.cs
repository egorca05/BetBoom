using BetBoom.ClassFolder;
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
            User user = LoginDG.SelectedItem as User;
            user.Balans += Convert.ToDecimal(BalansTb.Text);

            DBEntities.GetContext().SaveChanges();
            MBClass.MBInformation("Успешно");
            LoginDG.ItemsSource = DBEntities.GetContext().User.ToList().
                OrderBy(c => c.LoginUser);
        }

        private void LoginTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                LoginDG.ItemsSource = DBEntities.GetContext().User.Where(u => u.LoginUser.StartsWith(LoginTb.Text)).ToList();
                if (LoginDG.Items.Count <= 0)
                {
                    MBClass.MBError("пользователь не найден");
                }
            }
            catch (Exception ex)
            {
                MBClass.MBError(ex);
            }
        }

        private void ListBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminUserWindow adminUserWindow = new AdminUserWindow();
            adminUserWindow.Show();
            this.Close();
        }

        private void MatchBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminMatchWindow adminMatchWindow = new AdminMatchWindow();
            adminMatchWindow.Show();
            this.Close();
        }
    }
}
