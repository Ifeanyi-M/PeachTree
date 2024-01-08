using PeachTree.Web.Models;
using PeachTree.Web.Service.IServices;
using PeachTree.Web.Utility;
using static PeachTree.Web.Utility.SD;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace PeachTree.Web.Service
{
	public class ShoppingCartService : IShoppingCartService
	{
		private readonly IBaseService _baseService;

		public ShoppingCartService(IBaseService baseService)
        {
			_baseService = baseService;
		}

        public async Task<ResponseDTO?> ApplyCouponAsync(CartDTO cartDTO)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDTO,
                Url = SD.ShoppingCartBase + "/api/cart/ApplyCoupon"

            });
        }


		

        public async Task<ResponseDTO?> GetCartByUserIdAsync(string userId)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ShoppingCartBase + "/api/cart/GetCart/" + userId

            });
        }

     

	

        public async  Task<ResponseDTO?> RemoveFromCartAsync(int cartDetailsId)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDetailsId,
                Url = SD.ShoppingCartBase + "/api/cart/RemoveCart"

            });
        }

     

        public async Task<ResponseDTO?> UpsertCartAsync(CartDTO cartDTO)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDTO,
                Url = SD.ShoppingCartBase + "/api/cart/CartUpsert"

            });
        }

        public async Task<ResponseDTO?> EmailCart(CartDTO cartDto)
        {
            return await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDto,
                Url = SD.ShoppingCartBase + "/api/cart/EmailCartRequest"
            });
        }
    }
}
