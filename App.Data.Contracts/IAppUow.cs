using App.Model;

namespace App.Data.Contracts
{
    /// <summary>
    /// Interface for the Site "Unit of Work"
    /// </summary>
    public interface IAppUow
    {
        // Save pending changes to the data store.
        void Commit();

        // Repositories
        IActivityLogRepository ActivityLog { get; }
        IFollowRepository Follow { get; }
        IGameRepository Game { get; }
        IGettinListRepository GettinList { get; }
        ISocialLinkRepository SocialLink { get; }
        IUserRepository User { get; }
        IVendorRepository Vendor { get; }
    }
}