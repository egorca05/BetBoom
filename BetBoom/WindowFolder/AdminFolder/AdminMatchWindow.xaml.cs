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
using BetBoom.WindowFolder.AdminFolder;

namespace BetBoom.WindowFolder.AdminFolder
{
    /// <summary>
    /// Логика взаимодействия для AdminMatchWindow.xaml
    /// </summary>
    public partial class AdminMatchWindow : Window
    {
        public AdminMatchWindow()
        {
            InitializeComponent();
            MatchDG.ItemsSource = DBEntities.GetContext().Match.ToList().
                OrderBy(c => c.IdMatch);
        }

        private void UserDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddMatchWindow addMatchWindow = new AddMatchWindow();
            addMatchWindow.ShowDialog();
            MatchDG.ItemsSource = DBEntities.GetContext().Match.ToList().
               OrderBy(c => c.IdMatch);
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Match match = MatchDG.SelectedItem as Match;
                if (MBClass.QuestionMessage($"Удалить выбранный матч?"))
                {
                    DBEntities.GetContext().Match.Remove(match);
                    DBEntities.GetContext().SaveChanges();
                    MatchDG.ItemsSource = DBEntities.GetContext().Match.ToList().
                OrderBy(c => c.IdMatch);
                }
            }
            catch (Exception ex)
            {
                MBClass.MBError(ex);
            }
        }
    }
}
