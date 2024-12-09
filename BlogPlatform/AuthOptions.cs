using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BlogPlatform
{
    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer"; // издатель токена
        public const string AUDIENCE = "MyAuthClient"; // потребитель токена
        const string KEY = "mysupersecret_secretkey!1231111111111111111111111111111111111111111";   // ключ который применяется для создания токена 
        public const int LIFETIME = 1; // время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()  // константа создается при запуске приложения и относитмся к классу а не к экзепляру, не можеи менять 
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }

        //public IConfiguration Configuration { get; }

        //// Конструктор
        //public AuthOptions(IConfiguration configuration)
        //{
        //    Configuration = configuration; // Сохраняем конфигурацию
        //}

        //public void ConfigureServices(IServiceCollection services)
        //{
        //    // Пример получения строки подключения
        //    var connectionString = Configuration.GetConnectionString("DefaultConnection");

        //    // Пример получения конфигурации JWT
        //    var jwtKey = Configuration["Jwt:Key"];
        //    var jwtIssuer = Configuration["Jwt:Issuer"];
        //    var jwtAudience = Configuration["Jwt:Audience"];

        //    // Здесь вы можете добавлять другие сервисы
        //}
    }
}
