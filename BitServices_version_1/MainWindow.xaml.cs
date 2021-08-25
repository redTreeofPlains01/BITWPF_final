using BitServices_version_1.DataAccessLayer;
using BitServices_version_1.Views;
using System;
using System.Collections.Generic;
using System.Data;
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


//using BitServices_version_1.Views;//include the View folder to access your views/pages

namespace BitServices_version_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnClient.IsEnabled = true;
            btnContractors.IsEnabled = true;
            btnContractorSkills.IsEnabled = true;
            btnSkillsManagement.IsEnabled = true;
            btnJobBookings.IsEnabled = true;
            btnStaff.IsEnabled = true;
        }

        private void btnClient_Click(object sender, RoutedEventArgs e)
        {
            //new object of type CustomerManagement and link that up as a content for the contentFrame
            //then we should be able to see the the page
            contentFrame.Content = new ClientManagement();
        }

        private void btnStaff_Click(object sender, RoutedEventArgs e)
        {
            //when the Staff button is clicked we will link up the content for StaffMangement() page
            contentFrame.Content = new StaffManagement();
        }

        private void btnContractors_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Content = new ContractorManagement();

        }

        private void btnContractorSkills_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Content = new ContractorSkillManagement();
        }

        private void btnSkillsManagement_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Content = new SkillManagement();
        }

        private void btnJobBookings_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Content = new JobBookingManagement();
        }
        private void contentFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
        /*public void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //same logic you used in ASP.NET for checking if the user exists in Staff table
            //and then 
            string sqlStaff = "select staffid, email from Staff where email = '"
                    + txtUsername.Text +
                    "' and " + "password = '" + txtPassword.Text + "'";
            SQLHelper helper = new SQLHelper("BS");
            DataTable staffRecordsRead = helper.ExecuteSQL(sqlStaff);

            if (staffRecordsRead.Rows.Count >= 1) //means the login details are 
                                                  //from Instructor
            {

                MessageBox.Show("Welcome to BIT Services");
                btnClient.IsEnabled = true;
                btnContractors.IsEnabled = true;
                btnContractorSkills.IsEnabled = true;
                btnSkillsManagement.IsEnabled = true;
                btnJobBookings.IsEnabled = true;
                btnStaff.IsEnabled = true;
                contentFrame.Content = new ClientManagement();


            }
            else
            {
                MessageBox.Show("USername or password incorrect please try again....");
            }




        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            btnClient.IsEnabled = false;
            btnContractors.IsEnabled = false;
            btnContractorSkills.IsEnabled = false;
            btnSkillsManagement.IsEnabled = false;
            btnJobBookings.IsEnabled = false;
            btnStaff.IsEnabled = false;
            
        }

        */
    }
}
