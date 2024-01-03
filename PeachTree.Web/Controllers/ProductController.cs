using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PeachTree.Web.Models;
using PeachTree.Web.Service.IServices;
using System.Collections.Generic;

namespace PeachTree.Web.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
        {
			_productService = productService;
		}
        public async Task<IActionResult> ProductIndex()
		{
			List<ProductDTO>? list = new();

			ResponseDTO? response = await _productService.GetAllProductsAsync();

			if(response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<ProductDTO>>(Convert.ToString(response.Result));
			}
            else
            {
                TempData["error"] = response?.Message;
            }

			return View(list);
		}

		public async Task<IActionResult> CreateProduct()
		{
			return View();
		}

		[HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDTO productDTO)
        {
			if (ModelState.IsValid)
			{
                ResponseDTO? response = await _productService.CreateProductAsync(productDTO);

                if (response != null && response.IsSuccess)
                {
					TempData["success"] = "Product Created!!!";
					return RedirectToAction(nameof(ProductIndex));
                }

                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(productDTO);
        }

        public async Task<IActionResult> EditProduct(int productId)
        {
            ResponseDTO? response = await _productService.GetProductByIdAsync(productId);

            if (response != null && response.IsSuccess)
            {
                ProductDTO? model = JsonConvert.DeserializeObject<ProductDTO>(Convert.ToString(response.Result));
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct( ProductDTO productDTO)
        {
            ResponseDTO? response = await _productService.UpdateProductAsync( productDTO);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Product Updated!!!";
                return RedirectToAction(nameof(ProductIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(productDTO);
        }

        public async Task<IActionResult> DeleteProduct(int productId)
        {
            ResponseDTO? response = await _productService.GetProductByIdAsync(productId);

            if (response != null && response.IsSuccess)
            {
				ProductDTO? model = JsonConvert.DeserializeObject<ProductDTO>(Convert.ToString(response.Result));
				return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(ProductDTO productDTO)
        {
            ResponseDTO? response = await _productService.DeleteProductAsync(productDTO.ProductId);

            if (response != null && response.IsSuccess)
            {
				TempData["success"] = "Product Deleted!!!";
				return RedirectToAction(nameof(ProductIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(productDTO);
        }


    }
}
