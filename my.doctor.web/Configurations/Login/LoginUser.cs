using System.Text.Json;
using my.doctor.domain.Models;
using my.doctor.web.Configurations.Session;

namespace my.doctor.web.Configurations.Login
{
    public class LoginUser
    {
        private readonly string _key = "Login.User";
        private readonly SessionConfig _sesseion;

        public LoginUser(SessionConfig sesseion)
        {
            _sesseion = sesseion;
        }

        public void PostUser(UserModel costumer)
        {
            var value = JsonSerializer.Serialize(costumer);

            _sesseion.Create(_key, value);
        }

        public UserModel GetUser()
        {
            if (_sesseion.Exist(_key))
            {
                return JsonSerializer.Deserialize<UserModel>(_sesseion.Search(_key));
            }
            return null;
        }

        public void Logout()
        {
            _sesseion.RemoveAll();
        }
    }
}
