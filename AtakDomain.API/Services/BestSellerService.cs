using AtakDomain.Common.Intarfaces;
using AtakDomain.Common.Models;
using AtakDomain.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AtakDomain.API.Services
{
    public class BestSellerService : IBestSellerService
    {
        private readonly AppDbContext _context;

        public BestSellerService(AppDbContext context)
        {
            _context = context;
        }

        public Response GetBestSellerProducts(string userId)
        {
            var history = _context.Histories.Include("Product").Where(x => x.UserId == userId).ToList();
            if (history.Count == 0)
            {
                var nonPersonalizedBestSellers = (from oi in _context.OrderItems
                                                  group oi by oi.ProductId into g
                                                  orderby g.Count() descending
                                                  select new { g.Key }).Take(10).ToList();
                var nonPersonalizedProducts = nonPersonalizedBestSellers.ConvertAll(x => x.Key);
                return new Response
                {
                    UserId = userId,
                    Products = nonPersonalizedProducts.Count >= 5 ? nonPersonalizedProducts : new List<string>(),
                    Type = "non-personalized"
                };
            }

            var topCategories = history.DistinctBy(x => x.Product.CategoryId).Select(x => x.Product.CategoryId).Take(3).ToList();
            var personalizedProducts = (from oi in _context.OrderItems
                                        where topCategories.Contains(oi.Product.CategoryId)
                                        group oi by oi.ProductId into g
                                        orderby g.Count() descending
                                        select new { g.Key }).Take(10).ToList().ConvertAll(x => x.Key);
            return new Response
            {
                UserId = userId,
                Products = personalizedProducts.Count >= 5 ? personalizedProducts : new List<string>(),
                Type = "personalized"
            };
        }
    }
}