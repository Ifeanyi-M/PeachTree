using Microsoft.AspNetCore.Identity;
using PeachTree.Services.AuthAPI.Models.DTOs;

namespace PeachTree.Services.AuthAPI.Services.IServices
{
	public interface IAuthService
	{
		Task<string> Register(RegistrationRequestDTO registrationRequestDTO);
		Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);

		Task<bool> AssignRole(string email, string roleName);

		Task<List<IdentityRole>> GetAllRoles();

    }
}
