using PeachTree.Services.AuthAPI.Models;

namespace PeachTree.Services.AuthAPI.Services.IServices
{
	public interface IJwtTokenGenerator
	{
		string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
	}
}
