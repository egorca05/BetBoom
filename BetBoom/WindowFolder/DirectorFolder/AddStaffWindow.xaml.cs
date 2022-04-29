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

namespace BetBoom.WindowFolder.DirectorFolder
{
    /// <summary>
    /// Логика взаимодействия для AddStaffWindow.xaml
    /// </summary>
    public partial class AddStaffWindow : Window
    {
        public AddStaffWindow()
        {
            InitializeComponent();
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTB.Text == String.Empty)
            {
                MBClass.MBError("Введите логин");
            }
            else if (PasswordTB.Text == String.Empty)
            {
                MBClass.MBError("Введите пароль");
            }
            else
            {
                AddUser();
                MBClass.MBInformation("Пользователь зарегистрирован");
                this.Close();
            }
        }

        private void AddUser()
        {
            DBEntities.GetContext().User.Add(new User()
            {
                LoginUser = LoginTB.Text,
                PasswodUser = PasswordTB.Text,
                Balans = 0,
                IdRole = 1
            });
            DBEntities.GetContext().SaveChanges();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
