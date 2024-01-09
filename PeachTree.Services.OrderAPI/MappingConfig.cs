using AutoMapper;


namespace PeachTree.Services.OrderAPI
{
	public class MappingConfig
	{
		public static MapperConfiguration RegisterMaps()
		{
			var mappingConfig = new MapperConfiguration(config =>
			{
				
                //config.CreateMap<Product, ProductDTO>();
            }

			);
			return mappingConfig;
		}
	}
}
