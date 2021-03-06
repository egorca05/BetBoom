using BetBoom.ClassFolder;
using BetBoom.DataFolder;
using BetBoom.WindowFolder.AdminFolder;
using BetBoom.WindowFolder.UserFolder;
using System;
using System.Linq;
using System.Windows;

namespace BetBoom.WindowFolder.NoRoleWindow
{
    /// <summary>
    /// Логика взаимодействия для AutorizationWindow.xaml
    /// </summary>
    public partial class AutorizationWindow : Window
    {
        public AutorizationWindow()
        {
            InitializeComponent();
        }

        private void InBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LoginTb.Text))
            {
                MBClass.MBError("Введите логин");
                LoginTb.Focus();
            }
            if (string.IsNullOrEmpty(PasswordPB.Password))
            {
                MBClass.MBError("Введите пароль");
                PasswordPB.Focus();
            }
            else
            {
                try
                {
                    var user = DBEntities.GetContext().User.FirstOrDefault
                        (u => u.LoginUser == LoginTb.Text);
                    if (user == null)
                    {
                        MBClass.MBError("Пользователь не найден");
                        LoginTb.Focus();
                        return;
                    }
                    if (user.PasswodUser != PasswordPB.Password)
                    {
                        MBClass.MBError("Введен не правильный пароль");
                        PasswordPB.Focus();
                        return;
                    }
                    else
                    {
                        Context.user = user;
                        switch (user.IdRole)
                        {
                            case 1:
                                AdminMatchWindow adminMatchWindow = new AdminMatchWindow();
                                adminMatchWindow.Show();
                                this.Close();
                                break;
                            case 2:
                                UserMatchWindow userMatchWindow =
                                    new UserMatchWindow();
                                userMatchWindow.Show();
                                this.Close();
                                break;
                            case 3:
                                DirectorFolder.StaffWindow
                                    staffWindow =
                                    new DirectorFolder.StaffWindow();
                                staffWindow.Show();
                                this.Close();
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MBClass.MBError(ex);
                }
            }
        }
    }
}
