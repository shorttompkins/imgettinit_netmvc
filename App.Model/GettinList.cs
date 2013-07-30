using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Model
{
    public class Gettinlist
    {
        public int GettinlistId { get; set; }
        public int UserId { get; set; }
        public DateTime AddedTimestamp { get; set; }
        public int GameId { get; set; }
        public int VendorId { get; set; }
        public int ConsoleId { get; set; }
        public string Preordered { get; set; }

        public virtual Game Game { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual Console Console { get; set; }
        public virtual User User { get; set; }
    }
}
