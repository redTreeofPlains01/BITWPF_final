using BitServices_version_1.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitServices_version_1.Models
{
    public class Contractors : List<Contractor>//becuase Customers class has been inherited from List class
                                        //it is already a empty list of type client
    {
        public Contractors(string firstname = null, string lastname = null)
        {
            if (firstname == null && lastname == null)
            {
                SQLHelper db = new SQLHelper("BS");
                string sql = "select contractorid, firstname, lastname, dob , phone, email, " +
                    "address, suburb, postcode, state, status, score  from Contractor";
                DataTable ContractorsTable = db.ExecuteSQL(sql);
                foreach (DataRow dr in ContractorsTable.Rows)
                {
                    Contractor contractor = new Contractor(dr);
                    this.Add(contractor);
                }
            } else
            {
                SQLHelper db = new SQLHelper("BS");
                string sql = "select contractorid, firstname, lastname, dob , phone, email, " +
                    "address, suburb, postcode, state, status, score  from Contractor where firstname like " + firstname;
                DataTable ContractorsTable = db.ExecuteSQL(sql);
                foreach (DataRow dr in ContractorsTable.Rows)
                {
                    Contractor contractor = new Contractor(dr);
                    this.Add(contractor);
                }

            }
        }
      /*  public Contractors(string firstname, string lastname)
        {
            SQLHelper db = new SQLHelper("BS");
            string sql = "select contractorid, firstname, lastname, dob , phone, email, " +
                "address, suburb, postcode, state, status, score  from Contractor where firstname like " + firstname;
            DataTable ContractorsTable = db.ExecuteSQL(sql);
            foreach (DataRow dr in ContractorsTable.Rows)
            {
                Contractor contractor = new Contractor(dr);
                this.Add(contractor);
            }
        } */


    }
}
