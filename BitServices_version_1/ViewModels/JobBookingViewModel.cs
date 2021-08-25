using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitServices_version_1.DataAccessLayer;
using BitServices_version_1.Models;

namespace BitServices_version_1.ViewModels
{
    public class JobBookingViewModel
    {
        private ObservableCollection<JobBooking> _jobbookings;
        private JobBooking _selectedJobBooking;
        public ObservableCollection<JobBooking> JobBookings
        {
            get { return _jobbookings; }
            set { _jobbookings = value; }
        }
        public JobBooking SelectedJobBooking
        {
            get { return _selectedJobBooking; }
            set { _selectedJobBooking = value; }
        }
        public JobBookingViewModel()
        {
            JobBookings allJobBookings = new JobBookings();
            JobBookings = new ObservableCollection<JobBooking>(allJobBookings);
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
            string sqlStr = "update JobBooking " +
                "set " +
                "status = '" + SelectedJobBooking.Status +
               
               "' where jobbookingid = " +
               SelectedJobBooking.JobBookingId;
            //then call the SQLHelper class to execute the update querystring
            SQLHelper objHelper = new SQLHelper("BS");
            objHelper.ExecuteNonQuery(sqlStr);
        }

    }
}
