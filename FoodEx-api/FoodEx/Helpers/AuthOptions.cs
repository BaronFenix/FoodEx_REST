using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FoodEx.Helpers
{
    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer"; // издатель токена
        public const string AUDIENCE = "MyAuthClient"; // потребитель токена
        const string KEY = "th1s 1s my cust0m S3cr3t key f0r authentication";   // ключ для шифрации
        public const int LIFETIME = 30; // время жизни токена - в минутах
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
