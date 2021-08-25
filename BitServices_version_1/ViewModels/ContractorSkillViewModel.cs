using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using BitServices_version_1.DataAccessLayer;
using BitServices_version_1.Models;

namespace BitServices_version_1.ViewModels
{
    public class ContractorSkillViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Contractor> _contractors;
        private Contractor _selectedContractor;


        private ObservableCollection<Skill> _skills;
        private Skill _selectedSkill;

        private ObservableCollection<ContractorSkill> _contractorSkills;
        //private ContractorSkill _selectedContractorSkill;
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


        private MyCommand _addSkillCommand;


        private Contractor _contractor;


        public Contractor Contractor
        {
            get { return _contractor; }
            set { _contractor = value;
                OnPropertyChanged("Contractor");
            }
        }
        public ObservableCollection<Contractor> Contractors
        {
            get { return _contractors; }
            set { _contractors = value;
                OnPropertyChanged("Contractors");
            }
        }
        public Contractor SelectedContractor
        {
            get { return _selectedContractor; }
            set { _selectedContractor = value;
                OnPropertyChanged("SelectedContractor");
            }
        }

        public ObservableCollection<ContractorSkill> ContractorSkills
        {
            get { return _contractorSkills; }

            set { _contractorSkills = value;
                OnPropertyChanged("ContractorSkills");
            }
        }
        public Skill SelectedSkill
        {
            get { return _selectedSkill; }
            set
            {
                _selectedSkill = value;
                OnPropertyChanged("SelectedSkill");
            }
        }

        public ObservableCollection<Skill> Skills
        {
            get { return _skills; }
            set { _skills = value;
                OnPropertyChanged("Skills");
            }
        }


        public ContractorSkillViewModel()
        {
            Contractors allContractors = new Contractors();
            Contractors = new ObservableCollection<Contractor>(allContractors);
            Skills allSkills = new Skills();
            Skills = new ObservableCollection<Skill>(allSkills);
            SelectedSkill = new Skill();
            _selectedContractor = new Contractor();


            //ContractorSkills allContractorSkills = new ContractorSkills(SelectedContractor.ContractorId);
            //ContractorSkills = new ObservableCollection<ContractorSkill>(allContractorSkills);
            
        }





        public MyCommand AddSkillCommand
        {
            get
            {
                if (_addSkillCommand == null)
                {
                    _addSkillCommand = new MyCommand(this.AddskillMethod, true);
                }
                return _addSkillCommand;
            }
            set
            {
                _addSkillCommand = value;
            }
        }


        public void AddskillMethod()
        {
            //first we want to insert a row in booking table
            //second we want to update the availablitlty table

            //s.SkillName = "---Select a Skill---";

            //string skill = cboSkillsList.SelectedValue.ToString();



            if (SelectedSkill.SkillName  == "---Select a Skill---")
            {
                string message = "Please select a skill!";
                string title = "Wrong Selection";

                MessageBox.Show(message, title);
            }
            else
            {
                
                MessageBox.Show(String.Format("Skill {0}, will be added", SelectedSkill.SkillName));
                SQLHelper objHelper = new SQLHelper("BS");
                SqlParameter[] objParams = new SqlParameter[2];
                objParams[0] = new SqlParameter("@contractorid", DbType.Int32);
                objParams[0].Value = SelectedContractor.ContractorId;
                objParams[1] = new SqlParameter("@skillname", DbType.String);
                objParams[1].Value = SelectedSkill.SkillName;              
                

                objHelper.ExecuteSQL("AddSkill", objParams, true);
                ContractorSkills allSkillsC = new ContractorSkills(SelectedContractor.ContractorId);
                ContractorSkills = new ObservableCollection<ContractorSkill>(allSkillsC);


                RefreshMethod();

                /*string sqlStr = "if not exists (select * from ContractorSkills where contractorid = " +
                SelectedContractor.ContractorId +
                " AND skillname = '" +
                SelectedSkill.SkillName +
                "') insert into ContractorSkills(contractorid, skillname) " +
                "values(" + SelectedContractor.ContractorId + ", '" +
                 SelectedSkill.SkillName  + "') ";

                SQLHelper objHelper = new SQLHelper("BS");
                objHelper.ExecuteNonQuery(sqlStr);*/
            }

            

        }


        public void RefreshMethod()
        {
            ContractorSkills allSkillsC = new ContractorSkills(SelectedContractor.ContractorId);
            ContractorSkills = new ObservableCollection<ContractorSkill>(allSkillsC);
        }

        /*private void LoadSkillsListComboBox()
    {
        cboSkillsList.DisplayMemberPath = "JobSkill_Type";
        cboSkillsList.SelectedValuePath = "JobSkill_ID";

        //set the itemsource to the Datattable
        //First display a messgae--select a skil---
        DataRow drSelectMsg;
        drSelectMsg = _dtSkillsList.NewRow();
        drSelectMsg["JobSkill_ID"] = "0";
        drSelectMsg["JobSkill_Type"] = "--Select a Skill--";
        _dtSkillsList.Rows.InsertAt(drSelectMsg, 0);
        cboSkillsList.ItemsSource = _dtSkillsList.DefaultView;
        cboSkillsList.SelectedIndex = 0;
    }*/

    }
}
