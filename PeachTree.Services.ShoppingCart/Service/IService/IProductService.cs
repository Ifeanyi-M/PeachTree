using PeachTree.Services.ShoppingCart.Models.DTO;

namespace PeachTree.Services.ShoppingCart.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
    }
}
