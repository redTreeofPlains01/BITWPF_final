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
    public class SkillViewModel
    {
        ObservableCollection<Skill> _skills;
        private Skill _selectedSkill; //bring this functionality
                                      //To be able to react to a button click event
                                      //we must first of all  tell the applcation that 
                                      //an event is occured at the Windows (View) level

        //to the datagrid

        //Customers is the name of the collection that we are binding on our WPF

        public ObservableCollection<Skill> Skills
        {
            get { return _skills; }
            set { _skills = value; }
        }
        public Skill SelectedSkill
        {
            get { return _selectedSkill; }
            set { _selectedSkill = value; }
        }
        public SkillViewModel()
        {
            //Generate the list of Customers from Database
            //Customers is still your list class and it is still you can all it as 
            //your Business Logic class
            Skills allSkills = new Skills();
            //ObservableCollection<T> is a class that listens to the events
            Skills = new ObservableCollection<Skill>(allSkills);
        }
        //ViewModels can be inherited so its a good idea to add the methods as
        //virtual so that you can override them in future






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
            string sqlStr = "update Skills set skillname= '" + SelectedSkill.SkillName +
               "', skilldescription = '" + SelectedSkill.SkillDescription +
               "' where skillname = " +
               SelectedSkill.SkillName;
            //then call the SQLHelper class to execute the update querystring
            SQLHelper objHelper = new SQLHelper("BS");
            objHelper.ExecuteNonQuery(sqlStr);
        }
    }

}

