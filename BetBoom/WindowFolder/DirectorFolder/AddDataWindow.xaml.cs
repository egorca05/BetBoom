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
using BetBoom.DataFolder;
using BetBoom.ClassFolder;
using BetBoom.WindowFolder.DirectorFolder;

namespace BetBoom.WindowFolder.DirectorFolder
{
    /// <summary>
    /// Логика взаимодействия для AddDataWindow.xaml
    /// </summary>
    public partial class AddDataWindow : Window
    {
        public AddDataWindow()
        {
            InitializeComponent();
        }

        private void NewStaffBtn_Click(object sender, RoutedEventArgs e)
        {
            AddStaffWindow addStaffWindow = new AddStaffWindow();
            addStaffWindow.Show();
        }

        private void NewTeamBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NewTeamTB.Text == String.Empty)
            {
                MBClass.MBError("Введите название команды");
                NewTeamTB.Focus();
            }
            else
            {
                AddTeam();
                MBClass.MBInformation("Команда успешно добавленна!");
            }
        }

        private void AddTeam()
        {
            //Добавление в первую команду
            DBEntities.GetContext().TeamOne.Add(new TeamOne()
            {
                NameTeamOne = NewTeamTB.Text
            });
            DBEntities.GetContext().SaveChanges();
            //Добавление в вторую команду
            DBEntities.GetContext().TeamTwo.Add(new TeamTwo()
            {
                NameTeamTwo = NewTeamTB.Text
            });
            DBEntities.GetContext().SaveChanges();
        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NewSportTB.Text == String.Empty)
            {
                MBClass.MBError("Введите новый вид спорта");
                NewSportTB.Focus();
            }
            else
            {
                AddSport();
                MBClass.MBInformation("Вид спорта успешно добавлен!");
            }
        }

        private void AddSport()
        {
            DBEntities.GetContext().Sport.Add(new Sport()
            {
                NameSport = NewSportTB.Text
            });
            DBEntities.GetContext().SaveChanges();
        }

        private void ListRepBtn_Click(object sender, RoutedEventArgs e)
        {
            ReportsWindow reportsWindow = new ReportsWindow();
            reportsWindow.Show();
            this.Close();
        }
    }
}
