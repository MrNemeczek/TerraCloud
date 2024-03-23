//using Microsoft.AspNetCore.Components.Authorization;
//using Microsoft.VisualBasic;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;

//namespace TerraCloud.Infrastructure.Auth
//{
//    public class MyAuthenticationStateProvider : AuthenticationStateProvider
//    {
//        private readonly ClaimsPrincipal _anonymous = new(new ClaimsIdentity());
//        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
//        {
//            try
//            {
//                if (String.IsNullOrEmpty(Constants.JWTTOKEN))
//                {
//                    return await Task.FromResult(new AuthenticationState(_anonymous));
//                }

//                var getUserClaims = DecryptToken(Constants.JWTTOKEN);
//                if (getUserClaims is null)
//                {
//                    return await Task.FromResult(new AuthenticationState(_anonymous));
//                }

//                var claimsPrincipal = SetClaimPrincipal(getUserClaims);
//                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
//            }
//            catch (Exception ex)
//            {
//                await Console.Out.WriteLineAsync(ex.ToString());

//                return await Task.FromResult(new AuthenticationState(_anonymous));
//            }
//        }

//        public static ClaimsPrincipal SetClaimPrincipal(CustomUserClaims claims)
//        {

//        }
//    }
//}
