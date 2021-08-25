using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitServices_version_1.Models;

namespace BitServices_version_1.ViewModels
{
    public class SearchContractorViewModel : INotifyPropertyChanged
    {
        private Contractor _contractor;
        ObservableCollection<SearchContractor> _searchContractors;
        private SearchContractor _selectedContractor;
        private MyCommand _searchCommand;
        //private MyCommand _confirmCommand;
        public SearchContractorViewModel()
        {
            SelectedContractor = new SearchContractor();
            Contractor = new Contractor();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        public SearchContractor SelectedContractor
        {
            get { return _selectedContractor; }
            set { _selectedContractor = value; }
        }
        public MyCommand SearchCommand
        {
            get
            {
                if (_searchCommand == null)
                {
                    _searchCommand = new MyCommand(this.SearchMethod, true);
                }
                return _searchCommand;
            }
            set
            {
                _searchCommand = value;
            }
        }



        public void SearchMethod()
        {
            //will briung in all available sessions in the grid
            //Grid is binded to the observable collection that this findMethod
            SearchContractors allContractors = new SearchContractors(SelectedContractor.ContFName, SelectedContractor.ContLName);
            SearchContractors = new ObservableCollection<SearchContractor>(allContractors);
        }
        public ObservableCollection<SearchContractor> SearchContractors
        {
            get { return _searchContractors; }
            set
            {
                _searchContractors = value;
                OnPropertyChanged("SearchContractors");
            }
        }
        

        public Contractor Contractor
        {
            get { return _contractor; }
            set { _contractor = value; }
        }
    }
}
