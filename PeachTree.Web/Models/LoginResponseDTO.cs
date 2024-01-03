namespace PeachTree.Web.Models
{
	public class LoginResponseDTO
	{
		public ApplicationUserDTO User { get; set; }
        public string Token { get; set; }

    }
}
