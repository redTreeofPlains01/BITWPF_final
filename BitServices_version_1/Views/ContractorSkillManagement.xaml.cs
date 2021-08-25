using BitServices_version_1.Models;
using BitServices_version_1.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BitServices_version_1.Views
{
    /// <summary>
    /// Interaction logic for ContractorSkillManagement.xaml
    /// </summary>
    public partial class ContractorSkillManagement : Page
    {
        public ContractorSkillManagement()
        {
            InitializeComponent();
            this.DataContext = new ContractorSkillViewModel();

        }

    

        private void btNSaveContractorSkills_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = new ContractorSkillViewModel();

            
        }

        private void SearchContractor_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = new SearchContractorViewModel();
        }
    }
}
