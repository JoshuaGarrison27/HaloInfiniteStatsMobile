using HaloInfiniteMobileApp.Models;
using System.Threading.Tasks;

namespace HaloInfiniteMobileApp.Interfaces
{
    public interface IHaloInfiniteService
    {
        Task<NewsArticles> GetNewsArticles();
        Task<PlayerAppearance> GetPlayerAppearance(string gamertag);
        void InvalidateHaloCache();
    }
}
