using Baro.Database;
using Baro.Models;
using Baro.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Baro
{
   public static class Authentication
    {
      public  static async void SetPreferences(string email = null)
        {
            if (email == null)
            {
                User log = await UserService.GetUser(Preferences.Get("User", null).Split(':')[0]);
                Preferences.Set("User", $"{log.email}:{log.name}:{log.userId}:{log.password}");
                
            }
            else
            {
                Login(email, Preferences.Get("User", null).Split(':')[3]);
            }
        }
        public static async void Login(string email, string password)
        {
            string token = await AuthService.login(email, password);
            if (token != "")
            {
            Preferences.Set("Token", token);
            string jwtToken = Preferences.Get("Token", null);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken DToken = handler.ReadJwtToken(jwtToken);
            if (DToken != null)
            {
                User log = await UserService.GetUser(DToken.Subject);
                Preferences.Set("User", $"{log.email}:{log.name}:{log.userId}:{password}");
            }
                
                await Shell.Current.GoToAsync("//Home");
                Shell.SetFlyoutBehavior(Shell.Current, FlyoutBehavior.Flyout);
            }
        }
        public static async Task<string> Register(string name, string email, string password)
        {
            string token = await AuthService.signup(name, email, password);
            r eturn token;
        }
    }
}
