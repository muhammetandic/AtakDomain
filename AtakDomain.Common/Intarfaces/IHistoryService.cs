using AtakDomain.Common.Models;

namespace AtakDomain.Common.Intarfaces
{
    public interface IHistoryService
    {
        Response LastTenHistory(string id);
        Task RemoveHistoryAsync(string userId, string productId);
    }
}