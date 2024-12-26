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
using System.Xml.Linq;

namespace Servise.View
{
    /// <summary>
    /// Логика взаимодействия для PageOrder.xaml
    /// </summary>
    public partial class PageOrder : Window
    {
        public TechnoServiceEntities entities { get; set; }
        public ObservableCollection<Request> orders {  get; set; }
        public ObservableCollection<User> users { get; set; }
        public PageOrder()
        {
            InitializeComponent();
           

         
            entities = new TechnoServiceEntities();
            orders = new ObservableCollection<Request>(entities.Requests);
            users = new ObservableCollection<User>(entities.Users);
            var Orders = entities.Requests.ToList();
            LVOrder.ItemsSource = Orders;
          
           
            CBStatus.Items.Add("В ожидании");
            CBStatus.Items.Add("В процессе");
            CBStatus.Items.Add("Завершено");
          


        }

        private void LVOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            
            var Item = LVOrder.SelectedItem as Request;
            Edit edit = new Edit(Item);        
            edit.Owner = this;
            edit.Show();
            Hide();
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            AddOrder addOrder = new AddOrder();
            addOrder.Owner = this;
            addOrder.Show();
            Hide();
        }

        private void Status_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            var selectS = CBStatus.SelectedItem;
          
            var SelectedStatus = entities.Requests.Where(u => u.StatusR == selectS).ToList();
            LVOrder.ItemsSource = SelectedStatus;
            
        }

        private void Button_Click_Date(object sender, RoutedEventArgs e)
        {
         
            var date =  DPDateStart.SelectedDate;
            var SelectDate = entities.Requests.Where(u => u.RequestDate == date).ToList();
            LVOrder.ItemsSource = SelectDate;
        }
    }
}
