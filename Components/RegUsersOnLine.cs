  using System;
  using DotNetNuke.ComponentModel.DataAnnotations;

namespace Christoc.Modules.OnlineR.Components
{
    public class RegUsersOnLine
    {

        [TableName("OnlineR_RegOnlineUsers")]

        // setup the primary key for table
        [PrimaryKey("RegId", AutoIncrement = true)]

        // configure caching using PetaPoco
        // [Cacheable("Messages", CacheItemPriority.Default, 20)]

        // scope the objects to the ModuleId of a module on a page (or copy of a module on a page)
        [Scope("ModuleId")]

        public class Message
        {
            /// <summary>
            /// Gets or sets the primary key
            /// </summary>
            public int RegId { get; set; }

            /// <summary>
            /// Gets or sets the date of the record
            /// </summary>
            public string RegDate { get; set; }

            /// <summary>
            /// Gets or sets the number of users online in that moment
            /// </summary>
            public string RegOnline { get; set; }
            }
        }
}