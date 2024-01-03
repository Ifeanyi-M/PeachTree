using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeachTree.Services.CouponAPI.Data;
using PeachTree.Services.CouponAPI.Models;
using PeachTree.Services.CouponAPI.Models.Dto;

namespace PeachTree.Services.CouponAPI.Controllers
{
	[Route("api/coupon")]
	[ApiController]
	 [Authorize]
	public class CouponAPIController : ControllerBase
	{
		private readonly AppDbContext _db;
		private readonly IMapper _mapper;
		private ResponseDTO _response;

		public CouponAPIController(AppDbContext db, IMapper mapper)
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
				IEnumerable<Coupon> objList = _db.Coupons.ToList();
				_response.Result = _mapper.Map<IEnumerable<CouponDTO>>(objList);
			}
			catch(Exception ex)
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
				Coupon obj = _db.Coupons.First(u=>u.CouponId == id);

				
				 _response.Result = _mapper.Map<CouponDTO>(obj); 
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}


		[HttpGet]
		[Route("GetByCode/{code}")]
		public ResponseDTO GetByCode(string code)
		{
			try
			{
				Coupon obj = _db.Coupons.FirstOrDefault(u => u.CouponCode.ToLower() == code.ToLower());

				if(obj == null)
				{
					_response.IsSuccess = false;
				}
				_response.Result = _mapper.Map<CouponDTO>(obj);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}

		[HttpPost]
		[Authorize(Roles = "ADMIN")]
		public ResponseDTO Post([FromBody] CouponDTO couponDTO)
		{
			try
			{
				Coupon obj = _mapper.Map<Coupon>(couponDTO);
				_db.Coupons.Add(obj);
				
				_db.SaveChanges();

				_response.Result = _mapper.Map<CouponDTO>(obj);


			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}

		[HttpPut]
		[Route("{id:int}")]
		[Authorize(Roles = "ADMIN")]

		public ResponseDTO Put(int id, [FromBody] CouponDTO couponDTO)
		{
			try
			{

				var obj = _db.Coupons.FirstOrDefault(u => u.CouponId == id);

				if(obj == null)
				{
					_response.IsSuccess = false;
					
				}

				_mapper.Map(couponDTO, obj);

				_db.Coupons.Update(obj);

				_db.SaveChanges();

				_response.Result = _mapper.Map<CouponDTO>(obj);




				//Coupon obj = _mapper.Map<Coupon>(couponDTO);
				//_db.Coupons.Update(obj);

				//_db.SaveChanges();

				//_response.Result = _mapper.Map<CouponDTO>(obj);


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
		[Authorize(Roles = "ADMIN")]
		public ResponseDTO Delete(int id)
		{
			try
			{
				Coupon obj = _db.Coupons.First(u => u.CouponId == id);
				_db.Coupons.Remove(obj);

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
