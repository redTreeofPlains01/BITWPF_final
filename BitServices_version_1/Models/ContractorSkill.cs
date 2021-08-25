﻿using BitServices_version_1.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitServices_version_1.Models
{
    public class ContractorSkill : INotifyPropertyChanged
    {
        private string _skillname;
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
            get { return _skillname; }
            set { _skillname = value;
                OnPropertyChanged("SkillName");
            }
        }
        public ContractorSkill()
        {
            _db = new SQLHelper("BS");
        }
        public ContractorSkill(DataRow dr)
        {
            SkillName = dr["skillname"].ToString();
        }
    }
}
