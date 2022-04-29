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
using BetBoom.WindowFolder.UserFolder;

namespace BetBoom.WindowFolder.UserFolder
{
    /// <summary>
    /// Логика взаимодействия для UserMatchWindow.xaml
    /// </summary>
    public partial class UserMatchWindow : Window
    {
        public UserMatchWindow()
        {
            InitializeComponent();
            UserMathDG.ItemsSource = DBEntities.GetContext().Match.ToList().
                OrderBy(c => c.IdMatch);
        }

        private void GoBtn_Click(object sender, RoutedEventArgs e)
        {
            if (UserMathDG.SelectedItem == null)
            {
                MBClass.MBError("Не выбран матч для ставки");
            }
            else
            {
                Match match = UserMathDG.SelectedItem as Match;
                VariableClass.IdMatch = match.IdMatch;
                new UserStafkaWindow(UserMathDG.SelectedItem as Match).Show();
                UserMathDG.ItemsSource = DBEntities.GetContext().Match.ToList().OrderBy(c => c.IdMatch);
            }
        }
    }
}
