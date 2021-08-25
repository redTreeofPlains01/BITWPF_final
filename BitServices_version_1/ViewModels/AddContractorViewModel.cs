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
    public class AddContractorViewModel
    {
        
        private Contractor _contractor;  //Model object
        private MyCommand _addCommand;


        public MyCommand AddCommand
        {
            get
            {
                if (_addCommand == null)//this is actually like a state, state is null meaning no command is running then run the Add()
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
            string sqlStr = "insert into Contractor(Firstname, lastname, dob,  phone, email, " +
                "address, suburb, postcode, state, status, password) "
                + " values('" + Contractor.FirstName + "', '" + Contractor.LastName + "', '"
                + Contractor.DOB + "', '" +
                Contractor.Phone + "', '" + Contractor.Email + "', '" + Contractor.Address + "', '"
                + Contractor.Suburb + "', '" +
                Contractor.PostCode + "', '" + Contractor.State + "', 'Active', '" + Contractor.Email + "') ";
            SQLHelper objHelper = new SQLHelper("BS");
            objHelper.ExecuteNonQuery(sqlStr);
            MessageBox.Show(String.Format("Client: {0} {1} Added", Contractor.FirstName, Contractor.LastName));

        }
        public AddContractorViewModel()
        {
            _contractor = new Contractor();
        }
        public Contractor Contractor  //$$$$$_This is the name you use in our View
        {
            get { return _contractor; }
            set { _contractor = value; }
        }
    }
}
