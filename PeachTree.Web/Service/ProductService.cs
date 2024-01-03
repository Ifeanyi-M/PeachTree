using PeachTree.Web.Models;
using PeachTree.Web.Service.IServices;
using PeachTree.Web.Utility;

namespace PeachTree.Web.Service
{
	public class ProductService : IProductService
	{
		private readonly IBaseService _baseService;

		public ProductService(IBaseService baseService)
        {
			_baseService = baseService;
		}
        public async Task<ResponseDTO?> CreateProductAsync(ProductDTO productDTO)
		{
			return await _baseService.SendAsync(new RequestDTO()
			{
				ApiType = SD.ApiType.POST,
				Data=productDTO,
				Url = SD.ProductAPIBase + "/api/product" 

			});
		}

		public async Task<ResponseDTO?> DeleteProductAsync(int id)
		{
			return await _baseService.SendAsync(new RequestDTO()
			{
				ApiType = SD.ApiType.DELETE,
				Url = SD.ProductAPIBase + "/api/product/" + id

			});
		}

		public async Task<ResponseDTO?> GetAllProductsAsync()
		{
			return await _baseService.SendAsync(new RequestDTO()
			{
				ApiType = SD.ApiType.GET,
				Url = SD.ProductAPIBase + "/api/product"

			});

		}

		

		public async Task<ResponseDTO?> GetProductByIdAsync(int id)
		{
			return await _baseService.SendAsync(new RequestDTO()
			{
				ApiType = SD.ApiType.GET,
				Url = SD.ProductAPIBase + "/api/product/" + id

			});
		}

		public async Task<ResponseDTO?> UpdateProductAsync(ProductDTO productDTO)
		{
			return await _baseService.SendAsync(new RequestDTO()
			{
				ApiType = SD.ApiType.PUT,
				Data = productDTO,
				Url = SD.ProductAPIBase + "/api/coupon"

			});
		}
	}
}
