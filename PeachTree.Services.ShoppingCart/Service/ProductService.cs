﻿using Newtonsoft.Json;
using PeachTree.Services.ShoppingCart.Models.Dto;
using PeachTree.Services.ShoppingCart.Models.DTO;
using PeachTree.Services.ShoppingCart.Service.IService;

namespace PeachTree.Services.ShoppingCart.Service
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ProductService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var client = _clientFactory.CreateClient("Product");

            var response = await client.GetAsync($"/api/product");

            var apiContent = await response.Content.ReadAsStringAsync();

            var resp = JsonConvert.DeserializeObject<ResponseDTO>(apiContent);

            if (resp.IsSuccess)
            {
                return JsonConvert.DeserializeObject<IEnumerable<ProductDTO>>(Convert
                    .ToString(resp.Result));
            }
            return new List<ProductDTO>();
        }
    }
}
