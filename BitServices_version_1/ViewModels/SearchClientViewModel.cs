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
    public class SearchClientViewModel : INotifyPropertyChanged
    {
        private Client _client;
        ObservableCollection<SearchClient> _searchClients;
        private SearchClient _selectedClient;
        private MyCommand _searchCommand;
        //private MyCommand _confirmCommand;


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        public SearchClient SelectedClient
        {
            get { return _selectedClient; }
            set { _selectedClient = value; }
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


        /*        public MyCommand ConfirmCommand
                {
                    get
                    {
                        if (_confirmCommand == null)
                        {
                            _confirmCommand = new MyCommand(this.AddMethod, true);
                        }
                        return _confirmCommand;
                    }
                    set
                    {
                        _confirmCommand = value;
                    }
                }*/


        /*        public void AddMethod()
                {
                    //first we want to insert a row in booking table
                    //second we want to update the availablitlty table
                    string sqlStr = "insert into Booking(availabilityid, customerid, address, suburb, postcode," +

                     " state, status, kilometers) values(" + SelectedSession.AvailableId + ", " +

                     Booking.CustomerID + ", '"

                     + Booking.Address + "', '" + Booking.Suburb + "', '" + Booking.PostCode + "', '" +

                     Booking.State + "', 'Booked', 0) ";

                    SQLHelper objHelper = new SQLHelper("FD");
                    objHelper.ExecuteNonQuery(sqlStr);
                    string updateStr = "update Availability set status = 'NA' where availabilityid = " + SelectedSession.AvailableId;
                    objHelper.ExecuteNonQuery(updateStr);
                }*/
        public void SearchMethod()
        {
            //will briung in all available sessions in the grid
            //Grid is binded to the observable collection that this findMethod
            SearchClients allClients = new SearchClients(Client.FirstName, Client.LastName);
            SearchClients = new ObservableCollection<SearchClient>(allClients);
        }
        public ObservableCollection<SearchClient> SearchClients
        {
            get { return _searchClients; }
            set
            {
                _searchClients = value;
                OnPropertyChanged("SearchClients");
            }
        }
        /*       public AddBookingViewModel()
               {
                   _booking = new Booking();
               }
        */

        public Client Client
        {
            get { return _client; }
            set { _client = value; }
        }
    }
}
