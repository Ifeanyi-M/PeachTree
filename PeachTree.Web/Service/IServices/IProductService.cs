using PeachTree.Web.Models;

namespace PeachTree.Web.Service.IServices
{
	public interface IProductService
	{
		//Task<ResponseDTO?> GetProductAsync(string couponCode);
		Task<ResponseDTO?> GetAllProductsAsync();
		Task<ResponseDTO?> GetProductByIdAsync(int id);
		Task<ResponseDTO?> CreateProductAsync(ProductDTO productDTO);
		Task<ResponseDTO?> UpdateProductAsync(ProductDTO productDTO);
		Task<ResponseDTO?> DeleteProductAsync(int id);


	}
}
