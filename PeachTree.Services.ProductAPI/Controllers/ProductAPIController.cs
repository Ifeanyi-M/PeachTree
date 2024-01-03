using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeachTree.Services.ProductAPI.Data;
using PeachTree.Services.ProductAPI.Models;
using PeachTree.Services.ProductAPI.Models.Dto;


namespace PeachTree.Services.ProductAPI.Controllers
{
	[Route("api/product")]
	[ApiController]
	//[Authorize]
	public class ProductAPIController : ControllerBase
	{
		private readonly AppDbContext _db;
		private readonly IMapper _mapper;
		private ResponseDTO _response;

		public ProductAPIController(AppDbContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
			_response = new ResponseDTO();
		}

		[HttpGet]

		public ResponseDTO Get()
		{
			try
			{
				IEnumerable<Product> objList = _db.Products.ToList();
				_response.Result = _mapper.Map<IEnumerable<ProductDTO>>(objList);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}


		[HttpGet]
		[Route("{id:int}")]
		public ResponseDTO Get(int id)
		{
			try
			{
				Product obj = _db.Products.First(u => u.ProductId == id);


				_response.Result = _mapper.Map<ProductDTO>(obj);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}


		
		[HttpPost]
		//[Authorize(Roles = "ADMIN")]
		public ResponseDTO Post([FromBody] ProductDTO ProductDTO)
		{
			try
			{
				Product obj = _mapper.Map<Product>(ProductDTO);
				_db.Products.Add(obj);

				_db.SaveChanges();

				_response.Result = _mapper.Map<ProductDTO>(obj);


			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}

		[HttpPut]
		
		//[Authorize(Roles = "ADMIN")]

		public ResponseDTO Put( [FromBody] ProductDTO ProductDTO)
		{
			try
			{

				//            Product product = _mapper.Map<Product>(ProductDTO);


				//            if (product == null)
				//{
				//	_response.IsSuccess = false;

				//}



				//_db.Products.Update(product);

				//_db.SaveChanges();

				//_response.Result = _mapper.Map<ProductDTO>(product);




				Product obj = _mapper.Map<Product>(ProductDTO);
				_db.Products.Update(obj);

				_db.SaveChanges();

				_response.Result = _mapper.Map<ProductDTO>(obj);


			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}

		[HttpDelete]
		[Route("{id:int}")]
		//[Authorize(Roles = "ADMIN")]
		public ResponseDTO Delete(int id)
		{
			try
			{
				Product obj = _db.Products.First(u => u.ProductId == id);
				_db.Products.Remove(obj);

				_db.SaveChanges();




			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}
	}
}
