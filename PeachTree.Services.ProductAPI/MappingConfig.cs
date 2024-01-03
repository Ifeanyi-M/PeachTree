using AutoMapper;
using PeachTree.Services.ProductAPI.Models;
using PeachTree.Services.ProductAPI.Models.Dto;

namespace PeachTree.Services.ProductAPI
{
	public class MappingConfig
	{
		public static MapperConfiguration RegisterMaps()
		{
			var mappingConfig = new MapperConfiguration(config =>
			{
				config.CreateMap<ProductDTO, Product>().ReverseMap();
				//config.CreateMap<Product, ProductDTO>();
			}

			);
			return mappingConfig;
		}
	}
}
