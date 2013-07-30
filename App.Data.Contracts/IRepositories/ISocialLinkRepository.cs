using System.Collections.Generic;
using System.Linq;
using App.Model;

namespace App.Data.Contracts
{
    public interface ISocialLinkRepository : IRepository<SocialLink>
    {
        SocialLink GetSocialLinkByType(int userid, string socialname);
    }
}
