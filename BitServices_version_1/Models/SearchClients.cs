using BitServices_version_1.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitServices_version_1.Models
{//This will have a method that brings in all serached customers using 1 parameter -name in searchbox
    public class SearchClients : List<SearchClient>
    {
        public SearchClients(string firstname, string lastname)
        {
            string sqlStr = " select c.clientid as clientid, c.firstname as firstname, " +
                "c.lastname as lastname " +
                "from Client c " +

                "where c.firstname  like '" + firstname + "%' OR c.lastname like '" 
                + lastname + "%'";

            SQLHelper objHelper = new SQLHelper("BS");
            DataTable searchTable = objHelper.ExecuteSQL(sqlStr);
            foreach (DataRow dr in searchTable.Rows)
            {
                //From Bookings>to Booking :This is going to Booking what was braught in from the dattabase 
                SearchClient search = new SearchClient(dr);
                this.Add(search);
            }
        }
    }
}
