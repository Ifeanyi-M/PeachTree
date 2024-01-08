using PeachTree.Web.Models;

namespace PeachTree.Web.Service.IServices
{
	public interface IShoppingCartService
    {
		Task<ResponseDTO?> GetCartByUserIdAsync(string userId);
		Task<ResponseDTO?> UpsertCartAsync(CartDTO cartDTO);
        Task<ResponseDTO?> RemoveFromCartAsync(int  cartDetailsId);

        Task<ResponseDTO?>ApplyCouponAsync(CartDTO cartDTO);
        Task<ResponseDTO?> EmailCart(CartDTO cartDto);




    }
}
