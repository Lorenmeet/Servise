using Servise.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Window
    {
        public TechnoServiceEntities entities { get; set; }
     
        public ObservableCollection<Request> requests;
        private Database.Request Addrequest = new Database.Request();


        public AddOrder()
        {
            InitializeComponent();
            entities = new TechnoServiceEntities();
        }

        private void Button_Click_Create(object sender, RoutedEventArgs e)
        {
            var technican = entities.Users.Where(g => g.NameU.Equals(TBTechnician.Text)).FirstOrDefault();
            var requestDate = TBRequestDate.SelectedDate.GetValueOrDefault();
            var endDate = TBEndDate.SelectedDate.GetValueOrDefault();
            var equipmentType = TBEquipmentType.Text.Trim();
            var client = entities.Users.Where(g => g.NameU.Equals(TBClientName.Text)).FirstOrDefault();
            Request request = new Request()
            {
                ClientName = client.UserID,
                EquipmentType = equipmentType,
                RequestDate = requestDate,
                EndData = endDate,
                Technician = technican.UserID,
                StatusR = "В ожидании"
            };
            Addrequest = request;
            entities.Requests.Add(Addrequest);
            entities.SaveChanges();
            MessageBox.Show("Заказ добавлен успешно");

            PageOrder page = new PageOrder();
            page.Owner = this;
            page.Show();
            Hide();


        }

        private void Button_Click_Back(object sender, RoutedEventArgs e)
        {
            PageOrder page = new PageOrder();
            page.Owner = this;
            page.Show();
            Hide();
        }
        

    }
}
