using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitServices_version_1.Models;

using System.Windows;
using BitServices_version_1.DataAccessLayer;

namespace BitServices_version_1.ViewModels
{
    public class AddStaffViewModel
    {
        
        
        private Staff _staff;  //Model object
        private MyCommand _addCommand;


        public MyCommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new MyCommand(this.AddMethod, true);
                }
                return _addCommand;
            }
            set
            {
                _addCommand = value;
            }
        }
        public void AddMethod()
        {
            //logic to add a new record
            string sqlStr = "insert into Staff(Firstname, lastname, dob,  phone, email, address, " +
                "suburb, postcode, state, status, password) "
                + " values('" + Staff.FirstName + "', '" + Staff.LastName + "', '"
                + Staff.DOB + "', '" +
                Staff.Phone + "', '" + Staff.Email + "', '" + Staff.Address + "', '"
                + Staff.Suburb + "', '" +
                Staff.PostCode + "', '" + Staff.State + "', 'Active', '" + Staff.Email + "') ";
            SQLHelper objHelper = new SQLHelper("BS");
            objHelper.ExecuteNonQuery(sqlStr);
            MessageBox.Show(String.Format("Client: {0} {1} Added", Staff.FirstName, Staff.LastName));

        }
        public AddStaffViewModel()
        {
            _staff = new Staff();
        }
        public Staff Staff 
        {
            get { return _staff; }
            set { _staff = value; }
        }
    }
}
