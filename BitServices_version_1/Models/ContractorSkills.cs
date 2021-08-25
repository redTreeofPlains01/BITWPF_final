using BitServices_version_1.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitServices_version_1.Models
{
    public class ContractorSkills : List<ContractorSkill>
    {
        public ContractorSkills(int contractorID)
        {
            SQLHelper db = new SQLHelper("BS");
            string sqlStr = "select skillname from ContractorSkills where " +
                "contractorid = " + contractorID;
            DataTable skillsTable = db.ExecuteSQL(sqlStr);
            foreach (DataRow dr in skillsTable.Rows)
            {
                ContractorSkill contractorSkill = new ContractorSkill(dr);
                this.Add(contractorSkill);
            }


        }
    }
}
