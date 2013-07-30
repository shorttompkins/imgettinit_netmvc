using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace App.Model
{
    public class User
    {
        public int UserId { get; set; }
        public DateTime RegisteredTimestamp { get; set; }
        public DateTime LastLoginTimestamp { get; set; }
        public DateTime LastViewedActivityFeed { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string Avatar { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Game> Games { get; set; }
        public virtual ICollection<Follow> Following { get; set; }
        public virtual ICollection<SocialLink> SocialLinks { get; set; }
        public virtual ICollection<Gettinlist> GettinLists { get; set; }
        public virtual ICollection<ActivityLog> ActivityLogs { get; set; }
    }
}
