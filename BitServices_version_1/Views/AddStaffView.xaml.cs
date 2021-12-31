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
    /// Interaction logic for AddStaffView.xaml
    /// </summary>
    public partial class AddStaffView : Page
    {
        public AddStaffView()
        {
            InitializeComponent();
            this.DataContext = new AddStaffViewModel();
        }

        private void btnBackToStaffManagement_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Views/StaffManagement.xaml",
                UriKind.Relative));
        }
    }
}
