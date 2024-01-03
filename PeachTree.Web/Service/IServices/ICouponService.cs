﻿using PeachTree.Web.Models;

namespace PeachTree.Web.Service.IServices
{
	public interface ICouponService
	{
		Task<ResponseDTO?> GetCouponAsync(string couponCode);
		Task<ResponseDTO?> GetAllCouponsAsync();
		Task<ResponseDTO?> GetCouponByIdAsync(int id);
		Task<ResponseDTO?> CreateCouponAsync(CouponDTO couponDTO);
		Task<ResponseDTO?> UpdateCouponAsync(CouponDTO couponDTO);
		Task<ResponseDTO?> DeleteCouponAsync(int id);


	}
}
