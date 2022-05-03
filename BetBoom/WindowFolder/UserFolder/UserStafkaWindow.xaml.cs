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
using BetBoom.WindowFolder.UserFolder;


namespace BetBoom.WindowFolder.UserFolder
{
    /// <summary>
    /// Логика взаимодействия для UserStafkaWindow.xaml
    /// </summary>
    public partial class UserStafkaWindow : Window
    {
        public UserStafkaWindow(Match Match)
        {
            InitializeComponent();
            DataContext = Match;
        }

        private void BetTeam1Btn_Click(object sender, RoutedEventArgs e)
        {
            User user = Context.user as User;
            if (BetTb.Text == String.Empty)
            {
                MBClass.MBError("Введите ставку");
            }
           else if (user.Balans < Convert.ToDecimal(BetTb.Text))
            {
                MBClass.MBError("На вашем балансе не достаточно денег");
            }
            else
            {
                Random random = new Random();
                int win = random.Next(2);
                if (win == 1)
                {
                    user.Balans = user.Balans * Convert.ToDecimal(kof.Text);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.MBInformation("Поздравляем, вы выйграли!");

                    UserMatchWindow userMatchWindow = new UserMatchWindow();
                    userMatchWindow.Show();
                    this.Close();
                }
                else
                {

                    user.Balans = user.Balans - Convert.ToDecimal(BetTb.Text);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.MBInformation("К сожелению вы проиграли");

                    UserMatchWindow userMatchWindow = new UserMatchWindow();
                    userMatchWindow.Show();
                    this.Close();
                }
            }
        }

        private void BetTeam2Btn_Click(object sender, RoutedEventArgs e)
        {
            User user = Context.user as User;
            if (BetTb.Text == String.Empty)
            {
                MBClass.MBError("Введите ставку");
            }
            else if (user.Balans < Convert.ToDecimal(BetTb.Text))
            {
                MBClass.MBError("На вашем балансе не достаточно денег");
            }
            else
            {
                Random random = new Random();
                int win = random.Next(2);
                if (win == 1)
                {
                    user.Balans = user.Balans * Convert.ToDecimal(kof.Text);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.MBInformation("Поздравляем, вы выйграли!");

                    UserMatchWindow userMatchWindow = new UserMatchWindow();
                    userMatchWindow.Show();
                    this.Close();
                }
                else
                {

                    user.Balans = user.Balans - Convert.ToDecimal(BetTb.Text);
                    DBEntities.GetContext().SaveChanges();

                    MBClass.MBInformation("К сожелению вы проиграли");

                    UserMatchWindow userMatchWindow = new UserMatchWindow();
                    userMatchWindow.Show();
                    this.Close();
                }
            }
        }
    }
}
