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
using BetBoom.WindowFolder.DirectorFolder;

namespace BetBoom.WindowFolder.DirectorFolder
{
    /// <summary>
    /// Логика взаимодействия для StaffWindow.xaml
    /// </summary>
    public partial class StaffWindow : Window
    {
        public StaffWindow()
        {
            InitializeComponent();
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

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            AddStaffWindow staffWindow = new AddStaffWindow();
            staffWindow.Show();
            LoginDG.ItemsSource = DBEntities.GetContext().User.ToList().
                OrderBy(c => c.LoginUser);
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User user = LoginDG.SelectedItem as User;
                if (MBClass.QuestionMessage($"Удалить выбранный матч?"))
                {
                    DBEntities.GetContext().User.Remove(user);
                    DBEntities.GetContext().SaveChanges();
                    LoginDG.ItemsSource = DBEntities.GetContext().User.ToList().
                OrderBy(c => c.IdUser);
                }
            }
            catch (Exception ex)
            {
                MBClass.MBError(ex);
            }
        }

        private void ListRepBtn_Click(object sender, RoutedEventArgs e)
        {
            ReportsWindow reportsWindow = new ReportsWindow();
            reportsWindow.Show();
            this.Close();
        }
    }
}
