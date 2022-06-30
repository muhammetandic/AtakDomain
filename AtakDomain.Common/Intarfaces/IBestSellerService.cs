using AtakDomain.Common.Models;

namespace AtakDomain.Common.Intarfaces
{
    public interface IBestSellerService
    {
        Response GetBestSellerProducts(string userId);
    }
}