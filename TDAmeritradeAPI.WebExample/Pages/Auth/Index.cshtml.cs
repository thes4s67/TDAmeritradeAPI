using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TDAmeritradeAPI.Client;
using TDAmeritradeAPI.WebExample.Data.IRepository;
using TDAmeritradeAPI.WebExample.Models;

namespace TDAmeritradeAPI.WebExample.Pages.Auth
{
    public class IndexModel : PageModel
    {
        private const string clientId = "STREAMERBOT";
        private const string redirectUri = "https://localhost:44361/auth?handler=Callback";
        public void OnGet()
        {

        }
        private readonly IUnitOfWork _unitOfWork;
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult OnPostGetAccessToken()
        {
            return Redirect($"https://auth.tdameritrade.com/oauth?client_id={clientId}@AMER.OAUTHAP&response_type=code&redirect_uri={redirectUri}");
        }

        public async Task<IActionResult> OnGetCallbackAsync(string returnUrl = null, string remoteError = null)
        {
            var code = this.HttpContext.Request.QueryString.Value.Replace("?handler=Callback&code=", "");
            code = HttpUtility.UrlDecode(code);
            var accessToken = TDAuth.GetAccessToken(clientId, code, redirectUri);
            var token = new TDAccessToken
            {
                access_token = accessToken.access_token,
                expires_in = accessToken.expires_in,
                refresh_token = accessToken.refresh_token,
                refresh_token_expires_in = accessToken.refresh_token_expires_in,
                scope = accessToken.scope,
                token_type = accessToken.token_type
            };

            if (!_unitOfWork.AccessToken.GetAll().Any())
            {
                _unitOfWork.AccessToken.Add(token);
            }
            else
            {
                token.Id = 1;
                _unitOfWork.AccessToken.Update(token);
            }
            
            _unitOfWork.Save();
            return RedirectToPage("/examples/index");
        }
    }
}