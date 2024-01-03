using Newtonsoft.Json.Linq;
using PeachTree.Web.Service.IServices;
using PeachTree.Web.Utility;

namespace PeachTree.Web.Service
{
    public class TokenProvider : ITokenProvider
    {
        private readonly IHttpContextAccessor _httpContext;

        public TokenProvider(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
        public void ClearToken()
        {
            _httpContext.HttpContext?.Response.Cookies.Delete(SD.TokenCookie);
        }

        public string? GetToken()
        {
            string? token = null;

            bool? hasToken = _httpContext.HttpContext?.Request.Cookies.TryGetValue(SD.TokenCookie, out token);

            return hasToken is true ? token : null;
        }

        public void SetToken(string token)
        {
            _httpContext.HttpContext?.Response.Cookies.Append(SD.TokenCookie, token);
        }
    }
}
