using Servise.Database;
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

namespace Servise.View
{
    /// <summary>
    /// Логика взаимодействия для Autho.xaml
    /// </summary>
    public partial class Autho : Window
    {
        public TechnoServiceEntities Entities { get; set; }
        private Database.User user;
        public Autho()
        {
            InitializeComponent();
            Entities = new Database.TechnoServiceEntities();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string nameU = TBlogin.Text.Trim();
            string passwordU = TBpassword.Text.Trim();


            user = Entities.Users.Where(u => u.NameU == nameU && u.PasswordU == passwordU).FirstOrDefault();
            if (user == null)
            {
                MessageBox.Show("Некорректное имя и(или) пароль");
                return;
            }
            else {
                switch (user.RoleU)
                {
                    case 1:
                        PageOrder page = new PageOrder();
                        page.Owner = this;
                        page.Show();
                        Hide();
                        break;
                    case 2:
                        break;
                    case 3:
                        PageOrder pageO = new PageOrder();
                        pageO.Owner = this;
                        pageO.Show();
                        Hide();
                        break;
                }
               
            }

        }
    }
}
