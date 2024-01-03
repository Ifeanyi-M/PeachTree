using Newtonsoft.Json;
using PeachTree.Services.ShoppingCart.Models.Dto;
using PeachTree.Services.ShoppingCart.Service.IService;

namespace PeachTree.Services.ShoppingCart.Service
{
    public class CouponService : ICouponService
    {
        private readonly IHttpClientFactory _clientFactory;

        public CouponService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<CouponDTO> GetCoupon(string couponCode)
        {
            var client = _clientFactory.CreateClient("Coupon");

            var response = await client.GetAsync($"/api/coupon/GetByCode/{couponCode}");

            var apiContent = await response.Content.ReadAsStringAsync();

            var resp = JsonConvert.DeserializeObject<ResponseDTO>(apiContent);

            if (resp!=null && resp.IsSuccess)
            {
                return JsonConvert.DeserializeObject<CouponDTO>(Convert
                    .ToString(resp.Result));
            }
            return new CouponDTO();
        }
    }
}
