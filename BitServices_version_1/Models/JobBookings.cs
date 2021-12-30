using BitServices_version_1.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitServices_version_1.Models
{
    public class JobBookings : List<JobBooking>
    {
        public JobBookings()
        {
            //write a query to bring all the bookings with booking date, client id and name,
            //contractor's id and name and start time (Booking, Availability, TimeSlot, Client, Instructor)
            SQLHelper db = new SQLHelper("BS");
            string sqlStr = "select jb.jobbookingid ,jb.jobbookingdate , jb.jobstarttime , " +
                "jb.jobendtime, co.contractorid, co.firstname as contractorfname, " +
                "co.lastname as contractorlname, cl.clientid, cl.firstname as clientfname, " +
                "cl.lastname as clientlname, l.address, l.suburb , l.postcode, l.state, " +
                "jb.status, jb.kilometers, jb.skillname, jb.jobdescription " +
                "from JobBooking jb, Location l, Client cl, Contractor co " +
                "where l.locationid = jb.locationid " +
                "and co.contractorid = jb.contractorid " +
                "and cl.clientid = jb.clientid ";


            /*string sqlStr = " select jb.jobbookingid ,jb.jobbookingdate , jb.jobstarttime , " +
                "jb.jobendtime, co.contractorid, co.firstname as contractorfname, " +
                "co.lastname as contractorlname, cl.clientid, cl.firstname as clientfname, " +
                "cl.lastname as clientlname, l.address, l.suburb , l.postcode, l.state, " +
                "jb.status, jb.kilometers, jb.skillname, jb.jobdescription, s.staffid " +
                "from JobBooking jb, Location l, Client cl, Contractor co,  Staff s, " +
                "ContractorSkills cs " +
                "where " +
                "l.locationid = jb.locationid and " +
                "jb.contractorid = co.contractorid and " +
                "cs.contractorid = jb.contractorid " +
                "and jb.staffid = s.staffid " +
                "and cs.skillname = jb.skillname" +
                "  and jb.clientid = cl.clientid";*/


            //****Need to use locationid
            //*******possible dummy for asp.net

            DataTable jobBookingsTable = db.ExecuteSQL(sqlStr);
            foreach (DataRow dr in jobBookingsTable.Rows)
            {
                //From Bookings>to Booking :This is going to Booking what was brought in from the dattabase 
                JobBooking jobbooking = new JobBooking(dr);
                this.Add(jobbooking);
            }
        }
    }
}
