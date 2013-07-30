using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Model
{
    public class SocialLink
    {
        public int SocialLinkId { get; set; }
        public int UserId { get; set; }
        public string SocialName { get; set; }
        public string Token { get; set; }
        public string Secret { get; set; }
        public string SocialUserId { get; set; }

        public virtual User User { get; set; }
    }
}
