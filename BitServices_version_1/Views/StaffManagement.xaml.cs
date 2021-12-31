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
    /// Interaction logic for StaffManagement.xaml
    /// </summary>
    public partial class StaffManagement : Page
    {
        public StaffManagement()
        {
            InitializeComponent();
            this.DataContext = new StaffViewModel();
        }
        private void btnAddNewStaff_Click(object sender, RoutedEventArgs e)
        {
            //when this button is clicked we want to move to a new page inside the same
            //frame and display our Add new Client page
            this.NavigationService.Navigate(new Uri("Views/AddStaffView.xaml",
                UriKind.Relative));
        }
    }
}
