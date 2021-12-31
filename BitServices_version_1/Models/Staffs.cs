using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BitServices_version_1.DataAccessLayer;

namespace BitServices_version_1.Models
{
    public class Staffs : List<Staff>                 
    {
        public Staffs()
        {
            SQLHelper db = new SQLHelper("BS");
            string sql = "select staffid, firstname, lastname, dob , phone, email, " +
                "address, suburb, postcode, state, status from Staff";
            DataTable staffsTable = db.ExecuteSQL(sql);
            foreach (DataRow dr in staffsTable.Rows)
            {
                Staff staff = new Staff(dr);
                this.Add(staff);//adding Clients to the list 

            }

        }
    }
}
