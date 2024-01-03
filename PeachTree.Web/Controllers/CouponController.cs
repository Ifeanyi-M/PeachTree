using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PeachTree.Web.Models;
using PeachTree.Web.Service.IServices;
using System.Collections.Generic;

namespace PeachTree.Web.Controllers
{
	public class CouponController : Controller
	{
		private readonly ICouponService _couponService;

		public CouponController(ICouponService couponService)
        {
			_couponService = couponService;
		}
        public async Task<IActionResult> CouponIndex()
		{
			List<CouponDTO>? list = new();

			ResponseDTO? response = await _couponService.GetAllCouponsAsync();

			if(response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<CouponDTO>>(Convert.ToString(response.Result));
			}
            else
            {
                TempData["error"] = response?.Message;
            }

			return View(list);
		}

		public async Task<IActionResult> CreateCoupon()
		{
			return View();
		}

		[HttpPost]
        public async Task<IActionResult> CreateCoupon(CouponDTO couponDTO)
        {
			if (ModelState.IsValid)
			{
                ResponseDTO? response = await _couponService.CreateCouponAsync(couponDTO);

                if (response != null && response.IsSuccess)
                {
					TempData["success"] = "Coupon Created!!!";
					return RedirectToAction(nameof(CouponIndex));
                }

                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(couponDTO);
        }


        public async Task<IActionResult> DeleteCoupon(int couponId)
        {
            ResponseDTO? response = await _couponService.GetCouponByIdAsync(couponId);

            if (response != null && response.IsSuccess)
            {
				CouponDTO? model = JsonConvert.DeserializeObject<CouponDTO>(Convert.ToString(response.Result));
				return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCoupon(CouponDTO couponDTO)
        {
            ResponseDTO? response = await _couponService.DeleteCouponAsync(couponDTO.CouponId);

            if (response != null && response.IsSuccess)
            {
				TempData["success"] = "Coupon Deleted!!!";
				return RedirectToAction(nameof(CouponIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(couponDTO);
        }


    }
}
