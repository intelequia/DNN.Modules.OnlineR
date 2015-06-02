using System;
using System.Collections.Generic;
using System.Linq;

using DotNetNuke.Data;
// --------------------------------------- In developement --------------------------------
namespace Christoc.Modules.OnlineR.Components
{
    // Insert a record of the users online in this moment in the DB
    public class RegUsersOnLineController
    {
        
               
        public void CreateReg(RegUsersOnLine Regusers)
        { 
            using (var ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<RegUsersOnLine>();
                rep.Insert(Regusers);
            }
        }

        // Get the max users conected this year
        public IEnumerable<int> GetMaxUsersYear()
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                string lcSql = ("SELECT MAX(RegOnline)" +
                "FROM  {databaseOwner}[{objectQualifier}OnlineR_RegOnlineUsers]" +
                "WHERE DATEDIFF( yy, RegDate, GETDATE() ) = 0");
                return ctx.ExecuteQuery<int>(System.Data.CommandType.Text, lcSql);
            }
        }

        // Get the max users conected this month
        public IEnumerable<int> GetMaxUsersMonth()
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                string lcSql = ("SELECT MAX(RegOnline)" +
                  "FROM  {databaseOwner}[{objectQualifier}OnlineR_RegOnlineUsers]" +
                  "WHERE DATEDIFF(m, RegDate, GETDATE()) = 0"); 
                return ctx.ExecuteQuery<int>(System.Data.CommandType.Text, lcSql);
            }
        }

        // Get the max users conected this week
        public IEnumerable<int> GetMaxUsersWeek()
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                string lcSql = ("SELECT MAX(RegOnline)" +
                "FROM  {databaseOwner}[{objectQualifier}OnlineR_RegOnlineUsers]" +
                "WHERE DATEDIFF( ww, RegDate, GETDATE() ) = 0");
                return ctx.ExecuteQuery<int>(System.Data.CommandType.Text, lcSql);
            }
        }

        // Get the list of registers from this year
        public IEnumerable<RegUsersOnLine> GetUsersThisYear()
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                var rep = ctx.GetRepository<RegUsersOnLine>();
                return rep.Find("WHERE DATEDIFF( YEAR, RegDate, GETDATE() ) = 0", true);
            }
        }
    }
}