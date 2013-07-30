using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data;
using System.Linq;
using App.Data.Contracts;
using App.Model;

namespace App.Data
{
    public class SocialLinkRepository : EFRepository<SocialLink>, ISocialLinkRepository
    {
        public SocialLinkRepository(DbContext context): base(context) {  }


        public SocialLink GetSocialLinkByType(int userid, string socialname)
        {
            return DbContext.Set<SocialLink>().FirstOrDefault(sl => sl.UserId == userid && sl.SocialName == socialname);
        }
    }
}
