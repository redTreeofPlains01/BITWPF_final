using BitServices_version_1.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BitServices_version_1.Models
{
    public class AvailableSession
    {
        private int _contractorid;
        private string _contFName;
        private string _contLName;
        //private DateTime _jobbookingdate;
        //private string _startTime;
        //private string _endTime;
        private double _score;
        
        
        private SQLHelper _db;


        public int ContractorId
        {
            get { return _contractorid; }
            set { _contractorid = value; }
        }
        public string ContFName
        {
            get { return _contFName; }
            set { _contFName = value; }
        }
        public string ContLName
        {
            get { return _contLName; }
            set { _contLName = value; }
        }

        /*public DateTime JobBookingDate
        {
            get { return _jobbookingdate; }
            set { _jobbookingdate = value; }
        }
        public string StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }
        public string EndTime
        {
            get { return _endTime; }
            set { _endTime = value; }
        }*/

        public Double Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public AvailableSession()
        {
            _db = new SQLHelper("BS");
        }
        public AvailableSession(DataRow dr)
        {
            //fill in all the properties using dr["columnname"] 
            //$ummary: This is coming from Bookings
    
            //StartTime = (dr["starttime"].ToString());
            //EndTime = (dr["endtime"].ToString());
            //JobBookingDate = Convert.ToDateTime(dr["jobBookingDate"]);

            ContractorId = Convert.ToInt32(dr["contractorid"]);
            ContFName = dr["FirstName"].ToString();
            ContLName = dr["LastName"].ToString();
            Score = Convert.ToDouble(dr["score"]);

            _db = new SQLHelper("BS");

        }
    }
}
