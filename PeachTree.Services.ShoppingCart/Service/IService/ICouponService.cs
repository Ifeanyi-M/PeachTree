using PeachTree.Services.ShoppingCart.Models.Dto;
using PeachTree.Services.ShoppingCart.Models.DTO;

namespace PeachTree.Services.ShoppingCart.Service.IService
{
    public interface ICouponService
    {
        Task<CouponDTO> GetCoupon(string couponCode);
    }
}
