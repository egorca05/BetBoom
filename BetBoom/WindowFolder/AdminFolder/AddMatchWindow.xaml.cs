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

namespace BetBoom.WindowFolder.AdminFolder
{
    /// <summary>
    /// Логика взаимодействия для AddMatchWindow.xaml
    /// </summary>
    public partial class AddMatchWindow : Window
    {
        public AddMatchWindow()
        {
            InitializeComponent();
            Team1CB.ItemsSource = DBEntities.GetContext()
                .TeamOne.ToList();
            Team2CB.ItemsSource = DBEntities.GetContext()
                .TeamTwo.ToList();
            SportCB.ItemsSource = DBEntities.GetContext()
                .Sport.ToList();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            if(Team1CB.SelectedItem == null)
            {
                MBClass.MBError("Выберите первую команду");
                Team1CB.Focus();
            }
            else if (Team2CB.SelectedItem == null)
            {
                MBClass.MBError("Выберите вторую команду");
                Team2CB.Focus();
            }
            else if (SportCB.SelectedItem == null)
            {
                MBClass.MBError("Выберите вид спорта");
                SportCB.Focus();
            }
            else if (KofTB.Text == String.Empty)
            {
                MBClass.MBError("Введите коэффициент");
                KofTB.Focus();
            }
            else if (Team1CB.SelectedValue.ToString() == Team2CB.SelectedValue.ToString())
            {
                MBClass.MBError("Команды не могут совпадать");
            }
            else
            {
                AddMatch();
                MBClass.MBInformation("Матч успешно создан");
                this.Close();
            }
        }

        private void AddMatch()
        {
            DBEntities.GetContext().Match.Add(new Match()
            {
                IdTeamOne = Int32.Parse(Team1CB.SelectedValue.ToString()),
                IdTeamTwo = Int32.Parse(Team2CB.SelectedValue.ToString()),
                IdSport = Int32.Parse(SportCB.SelectedValue.ToString()),
                Coefficient = Int32.Parse(KofTB.Text),              
            }); ;
            DBEntities.GetContext().SaveChanges();
        }
    }
}
