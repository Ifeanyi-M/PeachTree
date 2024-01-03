using PeachTree.Web.Models;

namespace PeachTree.Web.Service.IServices
{
	public interface IAuthService
	{
		Task<ResponseDTO?> LoginAsync(LoginRequestDTO loginRequestDTO);

		Task<ResponseDTO?> RegisterAsync(RegistrationRequestDTO registrationRequestDTO);
		Task<ResponseDTO?> AssignRoleAsync(RegistrationRequestDTO registrationRequestDTO);

	}
}
