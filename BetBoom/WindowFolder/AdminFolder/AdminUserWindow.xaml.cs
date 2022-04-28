﻿using System;
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
using BetBoom.ClassFolder;
using BetBoom.DataFolder;

namespace BetBoom.WindowFolder.AdminFolder
{
    /// <summary>
    /// Логика взаимодействия для AdminUserWindow.xaml
    /// </summary>
    public partial class AdminUserWindow : Window
    {
        public AdminUserWindow()
        {
            InitializeComponent();
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Match match = LoginDG.SelectedItem as Match;
                if (MBClass.QuestionMessage($"Удалить выбранного пользателя?"))
                {
                    DBEntities.GetContext().Match.Remove(match);
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

        private void MatchBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminMatchWindow adminMatchWindow = new AdminMatchWindow();
            adminMatchWindow.Show();
            this.Close();
        }

        private void PayBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminPayWindow adminPayWindow = new AdminPayWindow();
            adminPayWindow.Show();
            this.Close();
        }
    }
}