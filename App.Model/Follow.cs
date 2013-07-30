using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Model
{
    public class Follow
    {
        public int FollowId { get; set; }
        public DateTime FollowedTimestamp { get; set; }

        public virtual User User { get; set; }
        public virtual User FollowedUser { get; set; }
    }
}
