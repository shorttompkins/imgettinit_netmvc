using System.Collections.Generic;
using System.Linq;
using App.Model;


namespace App.Data.Contracts
{
    public interface IActivityLogRepository : IRepository<ActivityLog>
    {
        ICollection<ActivityLog> GetActivityByUser(int userid, bool hidefriends);
    }
}
