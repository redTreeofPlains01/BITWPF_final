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
    /// Interaction logic for AddJobBookingView.xaml
    /// </summary>
    public partial class AddJobBookingView : Page

    {
        private bool _confirm;

        public AddJobBookingView()
        {
            InitializeComponent();
            this.DataContext = new AddJobBookingViewModel();
        }

        private void btnBackToJobBookingManagement_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Views/JobBookingManagement.xaml",
                UriKind.Relative));
        }

        private void btnFindSessions_Click(object sender, RoutedEventArgs e)
        {
            _confirm = true;
            UpdateButtons();
        }
        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            _confirm = false;
            UpdateButtons();
           
        }

        private void UpdateButtons()
        {
            
            
            btnConfirm.IsEnabled = _confirm;

        }

       
    }
}
