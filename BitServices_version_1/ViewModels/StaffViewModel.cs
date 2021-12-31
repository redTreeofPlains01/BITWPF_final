using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitServices_version_1.Models;
using BitServices_version_1.DataAccessLayer;


namespace BitServices_version_1.ViewModels
{
    public class StaffViewModel
    {
        ObservableCollection<Staff> _staffs;
        private Staff _selectedStaff; 
       
        public ObservableCollection<Staff> Staffs
        {
            get { return _staffs; }
            set { _staffs = value; }
        }
        public Staff SelectedStaff
        {
            get { return _selectedStaff; }
            set { _selectedStaff = value; }
        }
        public StaffViewModel()
        {
            
            Staffs allStaffs = new Staffs();
   
            Staffs = new ObservableCollection<Staff>(allStaffs);
        }
        

        public virtual ObservableCollection<Staff> GetAllStaffs()
        {
            Staffs allStaffs = new Staffs();
            
            Staffs = new ObservableCollection<Staff>(allStaffs);
            return Staffs;
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
            string sqlStr = "update Client set FirstName = '" + _selectedStaff.FirstName +
               "', LastName = '" + _selectedStaff.LastName +
               "', dob = '" + _selectedStaff.DOB +
               "', Phone = '" + _selectedStaff.Phone +
               
               "', Email = '" + _selectedStaff.Email +
               "', Address = '" + _selectedStaff.Address +
           
               "', Suburb = '" + _selectedStaff.Suburb +
               "', Postcode = '" + _selectedStaff.PostCode +
               "', State = '" + _selectedStaff.State +
               "', Status = '" + _selectedStaff.Status +
               "' where staffid = " +
               SelectedStaff.StaffId;
            //then call the SQLHelper class to execute the update querystring
            SQLHelper objHelper = new SQLHelper("BS");
            objHelper.ExecuteNonQuery(sqlStr);
        }
    }





}
