using BitServices_version_1.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitServices_version_1.Models;

namespace BitServices_version_1.ViewModels
{
    public class ClientViewModel
    {
        ObservableCollection<Client> _clients;
        private Client _selectedClient; //bring this functionality
                                            //To be able to react to a button click event
                                            //we must first of all  tell the applcation that 
                                            //an event is occured at the Windows (View) level

        //to the datagrid

        //Customers is the name of the collection that we are binding on our WPF
       
        public ObservableCollection<Client> Clients
        {
            get { return _clients; }
            set { _clients = value; }
        }
        public Client SelectedClient
        {
            get { return _selectedClient; }
            set { _selectedClient = value; }
        }
        public ClientViewModel()
        {
            //Generate the list of Customers from Database
            //Customers is still your list class and it is still you can all it as 
            //your Business Logic class
            Clients allClients = new Clients();
            //ObservableCollection<T> is a class that listens to the events
            Clients = new ObservableCollection<Client>(allClients);
        }
        //ViewModels can be inherited so its a good idea to add the methods as
        //virtual so that you can override them in future

        public virtual ObservableCollection<Client> GetAllClients()
        {
            Clients allClients = new Clients();
            //ObservableCollection<T> is a class that listens to the events
            Clients = new ObservableCollection<Client>(allClients);
            return Clients;
        }



        private MyCommand _updateCommand;
        public MyCommand UpdateCommand
        {
            get
            {
                if (_updateCommand == null)
                {
                    _updateCommand = new MyCommand(this.UpdateMethod, true);
                }
                return _updateCommand;
            }
            set
            {
                _updateCommand = value;
            }
        }
        //event handler - what to execute when the button Update is clicked
        public void UpdateMethod()
        {
            string sqlStr = "update Client " +
                "set " +
                "FirstName = '" + SelectedClient.FirstName +
               "', LastName = '" + SelectedClient.LastName +
               "', dob = '" + SelectedClient.DOB +
               "', Phone = '" + SelectedClient.Phone +
               "', Email = '" + SelectedClient.Email +
               "', Address = '" + SelectedClient.Address +
               "', Suburb = '" + SelectedClient.Suburb +
               "', Postcode = '" + SelectedClient.PostCode +
               "', State = '" + SelectedClient.State +
               "', Status = '" + SelectedClient.Status +
               "' where clientid = " +
               SelectedClient.ClientId;
            //then call the SQLHelper class to execute the update querystring
            SQLHelper objHelper = new SQLHelper("BS");
            objHelper.ExecuteNonQuery(sqlStr);
        }





    }
}
