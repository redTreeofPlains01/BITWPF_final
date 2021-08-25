using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;
using BitServices_version_1.DataAccessLayer;

namespace BitServices_version_1.Models
{   //we want our models to listen and react to the observable collection object
    //Publishing of some events here
    //Ideally both our ASP.NET as well as WPF should be interacting with the same
    //Model classes
    public class Client : INotifyPropertyChanged, IDataErrorInfo
    {
        private int _clientId;
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

        public string Error { get { return null; } } //on WPF this Error message does not implement well, so
        //just implment get to return null
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();
        public string this[string propertyName]
        {
            get
            {
                string result = null;
                switch (propertyName)
                {
                    case "FirstName":
                        if (string.IsNullOrWhiteSpace(FirstName))
                        {
                            result = "First name cannot be left empty!";
                        }
                        /*if (FirstName.Length <= 1 )
                        {
                            result = "First name cannot One character only!";
                        }*/
                        break;
                    case "LastName":
                        if (string.IsNullOrWhiteSpace(LastName))
                        {
                            result = "Last Name cannot be left empty!";
                        }
                        /*if (LastName.Length <= 1)
                        {
                            result = "Last name cannot One character only!";
                        }*/
                        break;
                        /*case "Email":
                            if (Email.Contains("@"))
                            {
                                result = "Email should contain @";
                            }

                            break;*/


                }
                if (result != null)
                {
                    ErrorCollection.Add(propertyName, result);
                }
                OnPropertyChanged("ErrorCollection");
                return result;
            }
        }



        public int ClientId
        {
            get { return _clientId; }
            set { _clientId = value; }
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

        public Client()
        {
            _db = new SQLHelper("BS");
        }
        public Client(DataRow dr)
        {
            //we will build up the object using the dr and its index
            ClientId = Convert.ToInt32(dr["clientid"]);
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
