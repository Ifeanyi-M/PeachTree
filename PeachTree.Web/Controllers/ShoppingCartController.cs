using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PeachTree.Web.Models;
using PeachTree.Web.Service.IServices;
using System.IdentityModel.Tokens.Jwt;

namespace PeachTree.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _cartService;

        public ShoppingCartController(IShoppingCartService cartService)
        {
            _cartService = cartService;
        }

        [Authorize]
        public async Task<IActionResult> CartIndex()
        {
            return View(await LoadCartBasedOnLoggedInUser());
        }

        public async Task<IActionResult> Remove(int cartDetailsId)
        {
            var userId = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Sub)?
               .FirstOrDefault()?.Value;

            ResponseDTO? response = await _cartService.RemoveFromCartAsync(cartDetailsId);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Cart Updated successfully";
                return RedirectToAction(nameof(CartIndex));
            }
            return  View();

        }

        [HttpPost]
        public async Task<IActionResult> ApplyCoupon(CartDTO cartDTO)
        {
         

            ResponseDTO? response = await _cartService.ApplyCouponAsync(cartDTO);

            if (response != null &  response.IsSuccess)
            {
                TempData["success"] = "Cart Updated successfully";
                return RedirectToAction(nameof(CartIndex));
            }
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> RemoveCoupon(CartDTO cartDTO)
        {

            cartDTO.CartHeader.CouponCode = "";
            ResponseDTO? response = await _cartService.ApplyCouponAsync(cartDTO);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Cart Updated successfully";
                return RedirectToAction(nameof(CartIndex));
            }
            return View();

        }

        private async Task<CartDTO> LoadCartBasedOnLoggedInUser()
        {
            var userId = User.Claims.Where(u => u.Type == JwtRegisteredClaimNames.Sub)?
                .FirstOrDefault()?.Value;

            ResponseDTO? response = await _cartService.GetCartByUserIdAsync(userId);

            if(response != null && response.IsSuccess)
            {
                CartDTO cartDTO = JsonConvert.DeserializeObject<CartDTO>(Convert
                    .ToString(response.Result));

                return cartDTO;
            }
            return new CartDTO();
        }
    }
}
