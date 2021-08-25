using BitServices_version_1.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitServices_version_1.Models
{
    public class SearchClient : INotifyPropertyChanged
    {
        private int _clientid;
        private string _cFName;
        private string _cLName;
        private SQLHelper _db;
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null) //this is checking if we do have an event handler
            {
                //PropertyChanged() is a delegate that will call an EventHandler
                //depending on who is Subscribed to listen to this event
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public int ClientId
        {
            get { return _clientid; }
            set
            {
                _clientid = value;
                OnPropertyChanged("clientid");
            }
        }

        public string CFName
        {
            get { return _cFName; }
            set
            {
                _cFName = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string CLName
        {
            get { return _cLName; }
            set
            {
                _cLName = value;
                OnPropertyChanged("LastName");
            }
        }


        public SearchClient()
        {
            _db = new SQLHelper("BS");
        }
        public SearchClient(DataRow dr)
        {
            //fill in all the properties using dr["columnname"] 
            //$ummary: This is coming from Bookings

            ClientId = Convert.ToInt32(dr["clientid"]);
            CFName = dr["firstname"].ToString();
            CLName = dr["lastname"].ToString();

            _db = new SQLHelper("BS");

        }
    }
}
