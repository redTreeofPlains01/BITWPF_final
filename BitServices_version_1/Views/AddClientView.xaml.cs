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
    /// Interaction logic for AddClientView.xaml
    /// </summary>
    public partial class AddClientView : Page
    {
        private bool _confirm;

        public AddClientView()
        {
            InitializeComponent();
            this.DataContext = new AddClientViewModel();
        }

        private void btnBackToClientManagement_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Views/ClientManagement.xaml",
                UriKind.Relative));
        }

        private void btnAddNewClient_Click(object sender, RoutedEventArgs e)
        {
            _confirm = false;
            UpdateButtons();
        }
        private void UpdateButtons()
        {


            btnAddNewClient.IsEnabled = _confirm;

        }
    }
}
