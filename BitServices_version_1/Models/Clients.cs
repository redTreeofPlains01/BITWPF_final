using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BitServices_version_1.DataAccessLayer;

namespace BitServices_version_1.Models
{ /* We will maintain a list class called Clients
     * that maintains the list of Clients that is why we inherit this class
     * from List class (.NET Framework class, List<T>, T stands for any C# class/Type)
     */
    public class Clients : List<Client>//becuase Clients class has been inherited from List class
     //it is already a empty list of type client
    {
        public Clients()
        {
            SQLHelper db = new SQLHelper("BS");
            string sql = "select clientid, firstname, lastname, dob , phone, email, " +
                "address, suburb, postcode, state, status from Client";
            DataTable clientsTable = db.ExecuteSQL(sql);
            foreach (DataRow dr in clientsTable.Rows)
            {
                Client client = new Client(dr);
                this.Add(client);//adding Clients to the list 

            }

        }

    }
}
