using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Model
{
    public class ActivityLog
    {
        public int ActivityLogId { get; set; }
        public DateTime ActivityTimestamp { get; set; }
        public string ActivityAction { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }        
        public int ConsoleId { get; set; }
        public int? VendorId { get; set; }

        public virtual User User { get; set; }
        public virtual Game Game { get; set; }
        public virtual Console Console { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
