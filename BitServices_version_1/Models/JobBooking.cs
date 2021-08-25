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
    public class JobBooking : INotifyPropertyChanged
    {
        private int _jobBookingId;
        private DateTime _jobBookingDate;
        private string _jobStartTime;
        private string _jobEndTime;
        private int _clientid;
        private int _contractorid;
        private int _staffid;
        private string _jobDescription;
        private string _clientFName;
        private string _clientLName;
        private string _contractorFName;
        private string _contractorLName;
        private string _address;
        private string _suburb;
        private string _postcode;
        private string _state;
        private string _status;
        private int _kilometers;
        private string _skillname;
        

        

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
        public int JobBookingId
        {
            get { return _jobBookingId; }
            set { _jobBookingId = value; }
        }
        public DateTime JobBookingDate //$$$$_This needs to match exactly to Binding in BookingManagemenbt.xaml
        {
            get { return _jobBookingDate; }
            set
            {
                _jobBookingDate = value;
                //when the firstname is set (once when it reads from database other, when
                //the firstname is changed to something else
                //   OnPropertyChanged("BookingDate");

                //You can comment Inotfypropertchabged if you donlt want it changed

            }
        }
        public string JobStartTime
        {
            get { return _jobStartTime; }
            set
            {
                _jobStartTime = value;
                //   OnPropertyChanged("BookingTime");
            }
        }
        public string JobEndTime
        {
            get { return _jobEndTime; }
            set
            {
                _jobEndTime = value;
                //   OnPropertyChanged("BookingTime");
            }
        }
        public int ClientID
        {
            get { return _clientid; }
            set
            {
                _clientid = value;
                // OnPropertyChanged("CustomerFName");
            }
        }
        public int ContractorID
        {
            get { return _contractorid; }
            set
            {
                _contractorid = value;
                // OnPropertyChanged("CustomerFName");
            }
        }
        public int StaffID
        {
            get { return _staffid; }
            set
            {
                _staffid = value;
                // OnPropertyChanged("CustomerFName");
            }
        }
        public string JobDescription
        {
            get { return _jobDescription; }
            set
            {
                _jobDescription = value;
                // OnPropertyChanged("CustomerFName");
            }
        }



        public string ClientFName
        {
            get { return _clientFName; }
            set
            {
                _clientFName = value;
                // OnPropertyChanged("CustomerFName");
            }
        }
        public string ClientLName
        {
            get { return _clientLName; }
            set
            {
                _clientLName = value;
                //  OnPropertyChanged("CustomerLName");
            }
        }
        public string ContractorFName
        {
            get { return _contractorFName; }
            set
            {
                _contractorFName = value;
                // OnPropertyChanged("DriverFName");
            }
        }
        public string ContractorLName
        {
            get { return _contractorLName; }
            set
            {
                _contractorLName = value;
                // OnPropertyChanged("DriverLName");
            }
        }
        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged("Address");//
            }
        }
        public string Suburb
        {
            get { return _suburb; }
            set
            {
                _suburb = value;
                //OnPropertyChanged("Suburb");
            }

        }
        public string PostCode
        {
            get { return _postcode; }
            set
            {
                _postcode = value;
                // OnPropertyChanged("PostCode");
            }
        }
        public string State
        {
            get { return _state; }
            set
            {
                _state = value;
                // OnPropertyChanged("State");
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
        public int Kilometers
        {
            get { return _kilometers; }
            set
            {
                _kilometers = value;
                OnPropertyChanged("Kilometers");
            }
        }
        public string SkillName
        {
            get { return _skillname; }
            set { _skillname = value;
                OnPropertyChanged("SkillName");
            }
        }
        public JobBooking()
        {
            _db = new SQLHelper("BS");
        }
        public JobBooking(DataRow dr)
        {
            //fill in all the properties using dr["columnname"] 
            //$ummary: This is coming from Bookings
            JobBookingId = Convert.ToInt32(dr["jobbookingid"]);
            JobBookingDate = Convert.ToDateTime(dr["jobbookingdate"].ToString());
            JobStartTime = dr["jobstarttime"].ToString();
            JobEndTime = dr["jobendtime"].ToString();
            ClientID = Convert.ToInt32(dr["clientid"]);
            ClientFName = dr["clientfname"].ToString();
            ClientLName = dr["clientlname"].ToString();
            ContractorID = Convert.ToInt32(dr["contractorid"]);
            //StaffID = Convert.ToInt32(dr["staffid"]);
            ContractorFName = dr["contractorfname"].ToString();
            ContractorLName = dr["contractorlname"].ToString();
            Address = dr["address"].ToString();
            Suburb = dr["suburb"].ToString();
            PostCode = dr["postcode"].ToString();
            State = dr["state"].ToString();
            Status = dr["status"].ToString();
            Kilometers = Convert.ToInt32(dr["kilometers"]);
            SkillName = dr["skillname"].ToString();
            //JobDescription = dr["jobdescription"].ToString();
            _db = new SQLHelper("BS");

        }
    }
}
