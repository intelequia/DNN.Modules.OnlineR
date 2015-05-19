using System;
using System.Collections.Generic;
using System.Linq;

using DotNetNuke.Data;

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


        public IEnumerable<RegUsersOnLine> GetMaxUsersYear()
        {
            using (IDataContext ctx = DataContext.Instance())
            {
                return ctx.ExecuteQuery<RegUsersOnLine>(System.Data.CommandType.Text,"");
            }
        }
    }



}