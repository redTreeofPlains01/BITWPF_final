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
        private Skill _selectedSkill; 

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
            
            Skills allSkills = new Skills();
        
            Skills = new ObservableCollection<Skill>(allSkills);
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

        public void UpdateMethod()
        {
            string sqlStr = "update Skills set skillname= '" + SelectedSkill.SkillName +
               "', skilldescription = '" + SelectedSkill.SkillDescription +
               "' where skillname = " +
               SelectedSkill.SkillName;

            SQLHelper objHelper = new SQLHelper("BS");
            objHelper.ExecuteNonQuery(sqlStr);
        }
    }

}

