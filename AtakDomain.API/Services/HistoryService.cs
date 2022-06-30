using AtakDomain.Common.Entities;
using AtakDomain.Common.Intarfaces;
using AtakDomain.Common.Models;

namespace AtakDomain.API.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly IGenericRepositoryAsync<History> _repository;

        public HistoryService(IGenericRepositoryAsync<History> repository)
        {
            _repository = repository;
        }

        public Response LastTenHistory(string id)
        {
            var history = _repository.Table.Where(x => x.UserId == id).OrderByDescending(x => x.TimeStamp).ToList();
            if (history.Count == 0)
            {
                throw new KeyNotFoundException();
            }

            history = history.DistinctBy(x => x.ProductId).Take(10).ToList();
            var products = history.ConvertAll(x => x.ProductId);
            return new Response
            {
                UserId = id,
                Products = products.Count >= 5 ? products : new List<string>(),
                Type = "personalized"
            };
        }

        public async Task RemoveHistoryAsync(string userId, string productId)
        {
            var history = await _repository.FindAsync(x => x.UserId == userId && x.ProductId == productId);

            if (history.Count == 0)
            {
                throw new KeyNotFoundException();
            }
            foreach (var h in history)
            {
                await _repository.DeleteAsync(h);
            }
        }
    }
}