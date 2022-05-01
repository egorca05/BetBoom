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
    /// Логика взаимодействия для AdminEditMatchWindow.xaml
    /// </summary>
    public partial class AdminEditMatchWindow : Window
    {
        public AdminEditMatchWindow(Match Match)
        {
            InitializeComponent();
            DataContext = Match;
            Team1CB.ItemsSource = DBEntities.GetContext()
                .TeamOne.ToList();
            Team2CB.ItemsSource = DBEntities.GetContext()
                .TeamTwo.ToList();
            SportCB.ItemsSource = DBEntities.GetContext()
                .Sport.ToList();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Team1CB.SelectedItem == null)
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
                Team1CB.Focus();
                Team2CB.Focus();
            }
            else
            {
                Match match = DBEntities.GetContext().Match
                .FirstOrDefault(s => s.IdMatch == VariableClass.IdMatch);
                match.TeamOne.NameTeamOne = Team1CB.Text;
                match.TeamTwo.NameTeamTwo = Team2CB.Text;
                match.Sport.NameSport = SportCB.Text;
                match.Coefficient = Convert.ToInt32(KofTB.Text);

                DBEntities.GetContext().SaveChanges();
                MBClass.MBInformation("Успешно");
                this.Close();
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {           
            this.Close();
        }
    }
}
