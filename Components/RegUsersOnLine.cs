using System;
using DotNetNuke.ComponentModel.DataAnnotations;

namespace Christoc.Modules.OnlineR.Components
{
    // --------------------------------------- In developement --------------------------------
    [TableName("OnlineR_RegOnlineUsers")]

    // setup the primary key for table
    [PrimaryKey("RegId", AutoIncrement = true)]

    // configure caching using PetaPoco
    //[Cacheable("RegUsersOnLine", CacheItemPriority.Default, 20)]

    // scope the objects to the ModuleId of a module on a page (or copy of a module on a page)
    [Scope("ModuleId")]

    public class RegUsersOnLine
    {
        /// <summary>
        /// Gets or sets the primary key
        /// </summary>
        public int RegId { get; set; }

        /// <summary>
        /// Gets or sets the date of the record
        /// </summary>
        public DateTime RegDate { get; set; }

        /// <summary>
        /// Gets or sets the number of users online in that moment
        /// </summary>
        public string RegOnline { get; set; }
    }
}