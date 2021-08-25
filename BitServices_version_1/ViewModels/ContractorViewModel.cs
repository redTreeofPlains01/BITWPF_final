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
    public class ContractorViewModel
    {
        private ObservableCollection<Contractor> _contractors;
        private Contractor _selectedContractor;
        public ObservableCollection<Contractor> Contractors
        {
            get { return _contractors; }
            set { _contractors = value; }
        }
        public Contractor SelectedContractor
        {
            get { return _selectedContractor; }
            set { _selectedContractor = value; }
        }
        public ContractorViewModel()
        {
            Contractors allContractors = new Contractors();
            Contractors = new ObservableCollection<Contractor>(allContractors);
        }

        public virtual ObservableCollection<Contractor> GetAllContractors()
        {
            Contractors allContractors = new Contractors();
            //ObservableCollection<T> is a class that listens to the events
            Contractors = new ObservableCollection<Contractor>(allContractors);
            return Contractors;
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
            string sqlStr = "update Contractor set FirstName = '" + SelectedContractor.FirstName +
               "', LastName = '" + SelectedContractor.LastName +
               "', Phone = '" + SelectedContractor.Phone +
               "', dob = '" + SelectedContractor.DOB +
               "', Email = '" + SelectedContractor.Email +
               "', Address = '" + SelectedContractor.Address +
               "', Suburb = '" + SelectedContractor.Suburb +
               "', Postcode = '" + SelectedContractor.PostCode +
               "', State = '" + SelectedContractor.State +
               "', Status = '" + SelectedContractor.Status +
               "' where conractorid = " +
               SelectedContractor.ContractorId;
            //then call the SQLHelper class to execute the update querystring
            SQLHelper objHelper = new SQLHelper("BS");
            objHelper.ExecuteNonQuery(sqlStr);
        }






    }
}
