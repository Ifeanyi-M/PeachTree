using PeachTree.EmailAPI.Models.DTOs;

namespace PeachTree.EmailAPI.Services
{
    public interface IEmailService
    {
        Task EmailCartAndLog(CartDTO cartDto);
        Task RegisterUserEmailAndLog(string email);
    }
}
