using BitServices_version_1.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitServices_version_1.Models
{
    public class SearchContractors : List<SearchContractor>
    {
        public SearchContractors(string firstname, string lastname)
        {
            string sqlStr = " select co.contractorid as contractorid, co.firstname as firstname, " +
                "co.lastname as lastname " +
                "from Contractor co " +

                "where co.firstname  like '" + firstname + "%' OR co.lastname like '"
                + lastname + "%'";

            SQLHelper objHelper = new SQLHelper("BS");
            DataTable searchTable = objHelper.ExecuteSQL(sqlStr);
            foreach (DataRow dr in searchTable.Rows)
            {
                //From Bookings>to Booking :This is going to Booking what was braught in from the dattabase 
                SearchContractor search = new SearchContractor(dr);
                this.Add(search);
            }
        }
    }
}
