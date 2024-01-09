using PeachTree.Services.OrderAPI.Models.DTO;

namespace PeachTree.Services.OrderAPI.Service.IService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
    }
}
