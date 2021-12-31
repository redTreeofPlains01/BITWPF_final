using BitServices_version_1.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitServices_version_1.Models
{
    public class Skills : List<Skill>
    {
        public Skills()
        {
            
            SQLHelper db = new SQLHelper("BS");
            string sqlStr = "select skillname, skilldescription  " +
                " from Skills ";
            DataTable jobBookingsTable = db.ExecuteSQL(sqlStr);


            /*Skill s = new Skill();
            //s.SkillId = -1;
            //s.SkillName = "---Select a Skill---";
            s.SkillName = "---Select a Skill---";
            //s.SkillDescription = "---Select a Skill---";
            this.Add(s);*/


            foreach (DataRow dr in jobBookingsTable.Rows)
            {
                 
                Skill skill = new Skill(dr);
                this.Add(skill);
            }
        }
    }
}
