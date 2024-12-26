using Servise.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;

namespace Servise.View
{
    /// <summary>
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        TechnoServiceEntities entities {  get; set; }
        public ObservableCollection<Request> requests;
        private SqlConnection connect = null;

        public void OpenConnection(string connectionString)
        {
            connect = new SqlConnection(connectionString);
            connect.Open();
        }

        public void CloseConnection()
        {
            connect.Close();
        }
        public Edit(Request Item)
        {
            InitializeComponent();
            entities = new TechnoServiceEntities();
             
            
            tbType.Text = Item.EquipmentType;
            tbСlientName.Text = Item.ClientName.ToString();
            tbStartDate.Text = Item.RequestDate.ToString();
            tbEndDate.Text = Item.EndData.ToString();
            tbStatus.Text = Item.StatusR;
            tbTecno.Text = Item.Technician.ToString();
            

           

        }

        private void InProcess_Click(object sender, RoutedEventArgs e)
        {

            entities.SaveChanges();
            PageOrder page = new PageOrder();
            page.Owner = this;
            page.Show();
            Hide();


        }

        private void TheEnd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
