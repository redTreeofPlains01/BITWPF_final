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
    public class Skill : INotifyPropertyChanged
    {

        private string _skillName;
        private string _skillDescription;

        private SQLHelper _db;
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null) //this is checking if we do have an event handler
            {
                //PropertyChanged() is a delegate that will call an EventHandler
                //depending on who is Subscribed to listen to this event
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }


        public string SkillName
        {
            get { return _skillName; }
            set
            {
                _skillName = value;
                OnPropertyChanged("SkillName");
            }
        }
        public string SkillDescription
        {
            get { return _skillDescription; }
            set
            {
                _skillDescription = value;
                OnPropertyChanged("SkillDescription");
            }
        }
        public Skill()
        {
            _db = new SQLHelper("BS");
        }
        public Skill(DataRow dr)
        {
            //fill in all the properties using dr["columnname"] 
            //$ummary: This is coming from Bookings
           
            SkillName = dr["skillName"].ToString();
            SkillDescription = dr["skillDescription"].ToString();
            _db = new SQLHelper("BS");

        }
    }
}
