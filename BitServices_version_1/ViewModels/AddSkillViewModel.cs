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
    public class AddSkillViewModel
    {
        private Skill _skill;  //Model object
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
            string sqlStr = "insert into Skills(skillname, skilldescription) "
                + " values('" + Skill.SkillName + "', '" + Skill.SkillDescription + "') ";

            //****Check duplicate skillname

            SQLHelper objHelper = new SQLHelper("BS");
            objHelper.ExecuteNonQuery(sqlStr);
            MessageBox.Show(string.Format("Skill {0} Added", Skill.SkillName));

        }
        public AddSkillViewModel()
        {
            _skill = new Skill();
        }
        public Skill Skill  //$$$$$_This is the name you use in our View
        {
            get { return _skill; }
            set { _skill = value; }
        }
    }
}
