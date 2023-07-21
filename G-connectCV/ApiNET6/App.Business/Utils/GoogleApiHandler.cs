using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Web;

namespace App.Business.Utils
{
    public class GoogleApiHandler
    {
        public IConfiguration Configuration;
        private IAuthorizationCodeFlow flow;
        private string Redirect_URI = "";//"http://localhost:3000/google-callback";
        string[] Scopes = { CalendarService.Scope.Calendar };
        public string ClientId = "";// "450454360503-ol598jkbdp5q85nok6uksbvkgbl8jab0.apps.googleusercontent.com";
        private string ClientSecret = "";//"J7yTh__oQeAZ0S-jZHSE7m3L";
        public GoogleApiHandler()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, true);
            var Configuration = configurationBuilder.Build();
            ClientId = Configuration.GetSection("Google")["ClientId"];
            ClientSecret = Configuration.GetSection("Google")["ClientSecret"];
            Redirect_URI = Configuration.GetSection("Google")["Redirect_URI"];

            flow =
            new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets()
                {
                    ClientId = ClientId,
                    ClientSecret = ClientSecret
                },
                Scopes = Scopes
            });
        }

        public CalendarService GetCalendarService(string refresh_token)
        {
            TokenResponse token = new TokenResponse
            {
                RefreshToken = refresh_token
            };
            UserCredential credential = new UserCredential(flow, "", token);
            credential.RefreshTokenAsync(CancellationToken.None);
            var calendarService = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential
            });
            
            return calendarService;
        }

        public TokenGoogle GetTokenGoogleByAuthcode(string authCode)
        {
            TokenGoogle token = new TokenGoogle();
            authCode = HttpUtility.UrlDecode(authCode);
            TokenResponse response = flow.ExchangeCodeForTokenAsync("", authCode, Redirect_URI, CancellationToken.None).Result;
            token.access_token = response.AccessToken;
            token.token_type = response.TokenType;
            token.expires_in = Convert.ToInt32(response.ExpiresInSeconds);
            token.refresh_token = response.RefreshToken;
            token.id_token = response.IdToken;
            return token;
        }
    }

    public class TokenGoogle
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
        public string id_token { get; set; }
    }
}
