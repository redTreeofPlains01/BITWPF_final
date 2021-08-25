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
    public class SearchContractor//: INotifyPropertyChanged
    {
        private int _contractorid;
        private string _contFName;
        private string _contLName;
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

        public int ContractorId
        {
            get { return _contractorid; }
            set
            {
                _contractorid = value;
                OnPropertyChanged("contractorid");
            }
        }

        public string ContFName
        {
            get { return _contFName; }
            set
            {
                _contFName = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string ContLName
        {
            get { return _contLName; }
            set
            {
                _contLName = value;
                OnPropertyChanged("LastName");
            }
        }


        public SearchContractor()
        {
            _db = new SQLHelper("BS");
        }
        public SearchContractor(DataRow dr)
        {
            //fill in all the properties using dr["columnname"] 
            //$ummary: This is coming from Bookings

            ContractorId = Convert.ToInt32(dr["contractorid"]);
            ContFName = dr["firstname"].ToString();
            ContLName = dr["lastname"].ToString();

            _db = new SQLHelper("BS");

        }
    }
}
