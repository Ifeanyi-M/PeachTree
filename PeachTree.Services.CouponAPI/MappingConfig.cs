using AutoMapper;
using PeachTree.Services.CouponAPI.Models;
using PeachTree.Services.CouponAPI.Models.Dto;

namespace PeachTree.Services.CouponAPI
{
	public class MappingConfig
	{
		public static MapperConfiguration RegisterMaps()
		{
			var mappingConfig = new MapperConfiguration(config =>
			{
				config.CreateMap<CouponDTO, Coupon>();
				config.CreateMap<Coupon, CouponDTO>();
			}

			);
			return mappingConfig;
		}
	}
}
