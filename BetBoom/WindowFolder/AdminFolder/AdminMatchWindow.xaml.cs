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
            //var team2 = DBEntities.GetContext().Role
            //    .FirstOrDefault(s => s.IdRole == User.IdRole);
            //RoleTB.Text = role.NameRole;
            //var sport = DBEntities.GetContext().Role
            //    .FirstOrDefault(s => s.IdRole == User.IdRole);
            //RoleTB.Text = role.NameRole;
        }

        private void UserDG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
