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
    public class Contractor : INotifyPropertyChanged
    {
        //Remember each Instructor has got multiple Preferred Suburbs
        //So we will need to bring a list of preferredSuburb
        private int _contractorId;
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
        private Single _score;

        private SQLHelper _db;
        private ContractorSkills _contractorSkills;
        public event PropertyChangedEventHandler PropertyChanged;

       
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null) 
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        public ContractorSkills ContractorSkills
        {
            get { return _contractorSkills; }
            set { _contractorSkills = value; }
        }
        public int ContractorId
        {
            get { return _contractorId; }
            set { _contractorId = value; }
        }
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
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
        public Single Score
        {
            get { return _score; }
            set
            {
                _score = value;
                OnPropertyChanged("Score");
            }
        }
        public Contractor()
        {
            _db = new SQLHelper("BS");
        }
        public Contractor(DataRow dr)
        {
            
            ContractorId = Convert.ToInt32(dr["contractorid"]);
            ContractorSkills = new ContractorSkills(ContractorId);
            FirstName = dr["firstname"].ToString();
            LastName = dr["lastname"].ToString();
            DOB = Convert.ToDateTime(dr["dob"]);
            Email = dr["email"].ToString();
            Address = dr["address"].ToString();
            Suburb = dr["suburb"].ToString();
            Phone = dr["phone"].ToString();
            PostCode = dr["postcode"].ToString();
            State = dr["state"].ToString();
            Status = dr["status"].ToString();
            Score = Convert.ToSingle(dr["score"]);

            _db = new SQLHelper("BS");

       

        }
    }
}
