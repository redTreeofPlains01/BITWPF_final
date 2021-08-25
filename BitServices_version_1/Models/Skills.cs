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
            //write a query to bring all the bookings with booking date, client id and name,
            //contractor's id and name and start time (Booking, Availability, TimeSlot, Client, Instructor)
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
                //From Bookings>to Booking :This is going to Booking what was braught in from the dattabase 
                Skill skill = new Skill(dr);
                this.Add(skill);
            }
        }
    }
}
