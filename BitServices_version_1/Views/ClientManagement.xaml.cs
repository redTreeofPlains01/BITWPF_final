using BitServices_version_1.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BitServices_version_1.Views
{
    /// <summary>
    /// Interaction logic for ClientManagement.xaml
    /// </summary>
    public partial class ClientManagement : Page
    {
        public ClientManagement()
        {
            InitializeComponent();
            //this is where the contructor of Clients class is inititated and will then connect
            //to DB and bring all the customers in the form a list of Customers
            //allCustomers is a list of Customers
            //here we only want to set hte data context to a ViewModel Class
            //1 view : 1 View Model
            this.DataContext = new ClientViewModel();
            /* Clients allClients = new Clients();
             dgClients.ItemsSource = allClients;         */
        }
        //until now we made use of WPF pre made events under each of our WPF controls
        //a lot of connection information was written insider the event handler
        //the Grid selection changed
        private void btnAddNewClient_Click(object sender, RoutedEventArgs e)
        {
            //when this button is clicked we want to move to a new page inside the same
            //frame and display our Add new Client page
            this.NavigationService.Navigate(new Uri("Views/AddClientView.xaml",
                UriKind.Relative));
        }




    }
}
