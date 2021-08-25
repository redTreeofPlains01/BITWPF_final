using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using BitServices_version_1.DataAccessLayer;
using BitServices_version_1.Models;

/*US: as as staff I would like to submit a new booking for a custoemer for greater client servce
1.key in all required details for new booking(Click find sessions after this- rememeber in FD a new booking row is not added yet)
2.find a contractor available and then confirm the booking with a contractor*/

namespace BitServices_version_1.ViewModels
{
    public class AddJobBookingViewModel : INotifyPropertyChanged
    {
        private JobBooking _jobbooking;
        ObservableCollection<AvailableSession> _availableSessions;

        private AvailableSession _selectedSession;
        private MyCommand _findCommand;
        private MyCommand _confirmCommand;
        private Client _client;
        ObservableCollection<SearchClient> _searchClients;
        private SearchClient _selectedClient;
        private MyCommand _searchCommand;


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        public AvailableSession SelectedSession
        {
            get { return _selectedSession; }
            set { _selectedSession = value; }
        }
        public MyCommand FindCommand
        {
            get
            {
                if (_findCommand == null)
                {
                    _findCommand = new MyCommand(this.FindMethod, true);
                }
                return _findCommand;
            }
            set
            {
                _findCommand = value;
            }
        }
        public MyCommand ConfirmCommand
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
        }
        public void AddMethod()


        {
            SQLHelper objHelper = new SQLHelper("BS");
            SqlParameter[] objParams = new SqlParameter[11];
            objParams[0] = new SqlParameter("@clientid", DbType.Int32);
            objParams[0].Value = Convert.ToInt32(JobBooking.ClientID);
            objParams[1] = new SqlParameter("@address", DbType.String);
            objParams[1].Value = JobBooking.Address;
            objParams[2] = new SqlParameter("@suburb", DbType.String);
            objParams[2].Value = JobBooking.Suburb;
            objParams[3] = new SqlParameter("@postcode", DbType.String);
            objParams[3].Value = JobBooking.PostCode;
            objParams[4] = new SqlParameter("@state", DbType.String);
            objParams[4].Value = JobBooking.State;
            objParams[5] = new SqlParameter("@contractorid", DbType.Int32);
            objParams[5].Value = Convert.ToInt32(SelectedSession.ContractorId);
            objParams[6] = new SqlParameter("@jobbookingdate", DbType.DateTime);
            objParams[6].Value = (JobBooking.JobBookingDate).ToString("yyyy-MM-dd");
            objParams[7] = new SqlParameter("@jobstarttime", DbType.Time);
            objParams[7].Value = JobBooking.JobStartTime;
            objParams[8] = new SqlParameter("@jobendtime ", DbType.Time);
            objParams[8].Value = JobBooking.JobEndTime;
            objParams[9] = new SqlParameter("@jobdescription", DbType.String);
            objParams[9].Value = JobBooking.JobDescription;
            objParams[10] = new SqlParameter("@skillname", DbType.String);
            objParams[10].Value = JobBooking.SkillName;

            objHelper.ExecuteSQL("AddNewLocAndBooking", objParams, true);








            /*
            //first we want to insert a row in booking table
            //second we want to update the availablitlty table
            string sqlStr1 = "insert into JobBooking(contractorid, jobbookingdate, jobstarttime, " +
                " jobendtime, clientid, jobdescription, status, kilometers, skillname) values('"
                + SelectedSession.ContractorId + "', '" +
             (JobBooking.JobBookingDate).ToString("yyyy-MM-dd") + "', '" +
             JobBooking.JobStartTime + "', '" +
             JobBooking.JobEndTime + "', '" +
             JobBooking.ClientID + "', '" +
             JobBooking.JobDescription + "', " +
             "'TBC', 0, " + "'" +
           
             JobBooking.SkillName + "')";

            

            /*+ "from JobBooking jb, Location l, " +
            "ContractorSkills cs, Client cl, Contractor co " +
               " where l.locationid = jb.locationid and " +
               " where jb.contractorid = co.contractorid and " +
               " where co.contractorid = cs.contractorid and " +
               " jb.clientid = cl.clientid";*/

            /*SQLHelper objHelper = new SQLHelper("BS");
            objHelper.ExecuteNonQuery(sqlStr1);

            //jobbookingid contractorid jobbookingdate jobstarttime     
             //   jobendtime clientid    jobdescription status          
             //   kilometers staffid     locationid skillname

            //********Need to insert into table Location of client 
            string sqlStr2 = "insert into Location(clientid, address, " +
                "suburb, postcode," +
             " state, phone_no) values('" + JobBooking.ClientID + "', '" +
             JobBooking.Address + "', '"
             + JobBooking.Suburb + "', '" + JobBooking.PostCode + "', '" + 
             JobBooking.State + "', 'TBC' ) ";

            //[locationid][clientid][address][suburb][postcode][state][phone_no]


            objHelper.ExecuteNonQuery(sqlStr2);

           
            /*string updateStr = "update Availability set status = 'NA' where availabilityid = " + SelectedSession.AvailableId;
            objHelper.ExecuteNonQuery(updateStr);*/
            

        }
        public void FindMethod()
        {
            //will briung in all available sessions in the grid
            //Grid is binded to the observable collection that this findMethod
            AvailableSessions allSessions = new AvailableSessions(JobBooking.JobBookingDate, 
                JobBooking.JobStartTime, JobBooking.JobEndTime, JobBooking.SkillName);
            AvailableSessions = new ObservableCollection<AvailableSession>(allSessions);
        }
        public ObservableCollection<AvailableSession> AvailableSessions
        {
            get { return _availableSessions; }
            set
            {
                _availableSessions = value;
                OnPropertyChanged("AvailableSessions");
            }
        }
        public AddJobBookingViewModel()
        {
            _jobbooking = new JobBooking();

            _selectedClient = new SearchClient();
        }


        public JobBooking JobBooking
        {
            get { return _jobbooking; }
            set { _jobbooking = value; }
        }

        public void SearchMethod()
        {
            //will briung in all available sessions in the grid
            //Grid is binded to the observable collection that this findMethod
            SearchClients allClients = new SearchClients(SelectedClient.CFName, SelectedClient.CLName);
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

        public Client Client
        {
            get { return _client; }
            set { _client = value; }
        }
    }
}
