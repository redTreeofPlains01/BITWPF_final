using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;
using BitServices_version_1.DataAccessLayer;

namespace BitServices_version_1.Models
{
    public class Staff : INotifyPropertyChanged
    { 
        private int _staffId;
        private string _firstName;
        private string _lastName;
        private DateTime _dob;
        private string _phone;
        private string _email;
        private string _address;
        private string _suburb;
        private string _postcode;
        private string _state;
        private string _password;
        private string _status;

        private SQLHelper _db;
        public event PropertyChangedEventHandler PropertyChanged;

        //this part is the magic code for your models to become Event oriented so
        //that you can now bypass WPF controls Event Handlers and due to that
        //avoid the code behind event handlers
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null) //this is checking if we do have an event handler
            {
                //PropertyChanged() is a delegate that will call an EventHandler
                //depending on who is Subscribed to listen to this event
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }

        }


        public int StaffId
        {
            get { return _staffId; }
            set { _staffId = value; }
        }
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                //when the firstname is set (once when it reads from database other, when
                //the firstname is changed to something else
                OnPropertyChanged("FirstName");
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public DateTime DOB
        {
            get { return _dob; }
            set
            {
                _dob = value;
                OnPropertyChanged("DOB");
            }
        }
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged("Phone");
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged("Address");
            }
        }
        public string Suburb
        {
            get { return _suburb; }
            set
            {
                _suburb = value;
                OnPropertyChanged("Suburb");
            }
        }
        public string PostCode
        {
            get { return _postcode; }
            set
            {
                _postcode = value;
                OnPropertyChanged("PostCode");
            }
        }
        public string State
        {
            get { return _state; }
            set
            {
                _state = value;
                OnPropertyChanged("State");
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }

        public Staff()
        {
            _db = new SQLHelper("BS");
        }
        public Staff(DataRow dr)
        {
            //we will build up the object using the dr and its index
            StaffId = Convert.ToInt32(dr["staffId"]);
            FirstName = dr["firstname"].ToString();
            LastName = dr["lastname"].ToString();
            DOB = Convert.ToDateTime(dr["dob"]);//dateformat can be changed here.
            Email = dr["email"].ToString();
            Address = dr["address"].ToString();
            Suburb = dr["suburb"].ToString();
            Phone = dr["phone"].ToString();
            PostCode = dr["postcode"].ToString();
            State = dr["state"].ToString();
            Status = dr["status"].ToString();


            _db = new SQLHelper("BS");

        }

    }
}
