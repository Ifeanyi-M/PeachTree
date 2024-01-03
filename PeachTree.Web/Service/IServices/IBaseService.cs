using PeachTree.Web.Models;

namespace PeachTree.Web.Service.IServices
{
	public interface IBaseService
	{
		Task<ResponseDTO?> SendAsync(RequestDTO requestDTO, bool withBearer = true);
	}
}
