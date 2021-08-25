using BitServices_version_1.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BitServices_version_1.Models
{
    public class AvailableSessions : List<AvailableSession>
    {
        public AvailableSessions(DateTime date, string desiredstarttime, string desiredendtime, string skillname)
        {



           // string sqlAvailSession = "AllAvailableContrSessions(@desireddate,@desiredstartime," +
            //    "@desiredendTime,@skillname)";


            SQLHelper objHelper = new SQLHelper("BS");
            SqlParameter[] objParams = new SqlParameter[4];
            objParams[0] = new SqlParameter("@desireddate", DbType.DateTime);
            objParams[0].Value = date;
            objParams[1] = new SqlParameter("@desiredstarttime", DbType.Time);
            objParams[1].Value = desiredstarttime;
            objParams[2] = new SqlParameter("@desiredendtime", DbType.Time);
            objParams[2].Value = desiredendtime;
            objParams[3] = new SqlParameter("@skillname", DbType.String);
            objParams[3].Value = skillname;


            DataTable sessionsTable = objHelper.ExecuteSQL("AllAvailableContrSessions", objParams,true);
            foreach (DataRow dr in sessionsTable.Rows)
            {
                //From Bookings>to Booking :This is going to Booking what was braught in from the dattabase 
                AvailableSession session = new AvailableSession(dr);
                this.Add(session);
            }

















            /*string sqlStr = " select t.timeslotid as timeslotid, t.starttime as starttime, a.availabilityid as availabilityid, a.availabledate as availableDate, i.instructorid as instructorid , i.firstname as firstname, i.lastname as lastname " +
                "from timeslot t, Availability a, Instructor i , PreferredSuburbs ps " +

                "where t.timeslotid =  a.timeslotid and i.instructorid =  a.instructorid and i.instructorid = ps.instructorid " +
                "and a.availabledate = '" + date.ToString("yyyy-MM-dd") + 
                "' and t.starttime = '" + time + "' and " + "ps.suburb = '" + suburb + "' " +
                " and a.status = 'Available'";

            string sqlAvailSession = "SELECT a.contractorid, c.FirstName, c.LastName " +
                "FROM[AVAILABILITY] as a , Contractor as c, JobBooking as jb, " +
                "ContractorSkills as cs, RejectedBooking as rj WHERE " +
                "a.contractorid = c.contractorid " +
                "AND c.contractorid = jb.contractorid " +
                "AND c.contractorid = cs.contractorid " +
                "AND c.contractorid = rj.contractorid " +

                "AND a.WeekDayName = DATENAME(DW, @date)" +
                "AND @desiredstarttime >= a.StartTime " +
                "AND @desiredfinishtime <= a.FinishTime " +

                "AND a.contractorid not in (SELECT * FROM JobBooking as jb WHERE " +
                "jb.jobbookingdate = @date AND" +
                "((@desiredstarttime < jb.jobstarttime AND @desiredfinishtime > jb.jobstarttime) OR" +
                "(@desiredstarttime < jb.jobstarttime AND @desiredfinishtime > jobendtime) OR " +
                "(@desiredstarttime = jb.jobstarttime AND @desiredfinishtime = jobendtime) OR " +
                "(@desiredstarttime > jb.jobstarttime AND @desiredfinishtime < jobendtime) OR " +
                "(@desiredstarttime > jb.jobstarttime AND @desiredfinishtime > jobendtime))) " +

                "AND a.contractorid IN " +
                "(Select* FROM ContractorSkills as cs WHERE @skill = cs.skillname) " +

                "AND a.contractorid IN " +
                "(Select* FROM Contractor as cs WHERE cs.status = 'Active'); " 

                 ;*/

        }
    }
}
