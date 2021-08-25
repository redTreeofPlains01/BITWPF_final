using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitServices_version_1.Models;

using System.Windows;
using BitServices_version_1.DataAccessLayer;

namespace BitServices_version_1.ViewModels
{
    public class AddClientViewModel
    {
        private Client _client;  //Model object
        private MyCommand _addCommand;


        public MyCommand AddCommand
        {
            get
            {
                if (_addCommand == null)//this is actually like a state, state is null meaning no command is running then run the Add()
                {
                    _addCommand = new MyCommand(this.AddMethod, true);
                }
                return _addCommand;
            }
            set
            {
                _addCommand = value;
            }
        }
        public void AddMethod()
        {
            //logic to add a new record
            string sqlStr = "insert into Client(Firstname, lastname, dob,  phone, email, address, suburb," +
                " postcode, state, status, password) "
                + " values('" + Client.FirstName + "', '" + Client.LastName + "', '" 
                + Client.DOB + "', '" +
                Client.Phone + "', '" + Client.Email + "', '" + Client.Address + "', '"
                + Client.Suburb + "', '" +
                Client.PostCode + "', '" + Client.State + "', 'Active', '"+ Client.Email + "') ";
            SQLHelper objHelper = new SQLHelper("BS");
            objHelper.ExecuteNonQuery(sqlStr);
            MessageBox.Show(String.Format("Client: {0} {1} Added", Client.FirstName, Client.LastName));

        }
        public AddClientViewModel()
        {
            _client = new Client();
        }
        public Client Client  //$$$$$_This is the name you use in our View
        {
            get { return _client; }
            set { _client = value; }
        }
    }
}
