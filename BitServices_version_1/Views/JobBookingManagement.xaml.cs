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
    /// Interaction logic for JobBookingManagement.xaml
    /// </summary>
    public partial class JobBookingManagement : Page
    {
        private bool _confirm;

        public JobBookingManagement()
        {
            InitializeComponent();
            this.DataContext = new JobBookingViewModel();
        }

        private void btnAddNewJobBooking_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Views/AddJobBookingView.xaml",
                UriKind.Relative));
        }

        private void btnUpdateJobBooking_Click(object sender, RoutedEventArgs e)
        {
            _confirm = false;
            UpdateButtons();
        }
        private void UpdateButtons()
        {


            btnUpdateJobBooking.IsEnabled = _confirm;

        }
    }
}
