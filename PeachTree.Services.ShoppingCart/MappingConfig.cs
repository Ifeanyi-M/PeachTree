using AutoMapper;
using PeachTree.Services.ShoppingCart.Models;
using PeachTree.Services.ShoppingCart.Models.DTO;

namespace PeachTree.Services.ShoppingCart
{
	public class MappingConfig
	{
		public static MapperConfiguration RegisterMaps()
		{
			var mappingConfig = new MapperConfiguration(config =>
			{
				config.CreateMap<CartHeader, CartHeaderDTO>().ReverseMap();
                config.CreateMap<CartDetails, CartDetailsDTO>().ReverseMap();

                //config.CreateMap<Product, ProductDTO>();
            }

			);
			return mappingConfig;
		}
	}
}
