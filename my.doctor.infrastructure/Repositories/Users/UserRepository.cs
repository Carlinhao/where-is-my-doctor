using System;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using my.doctor.domain.Interfaces.Repositories.Users;
using my.doctor.domain.Models;

namespace my.doctor.infrastructure.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly StringBuilder _stringBuilder;
        private readonly IDbConnection _dbConnection;

        public UserRepository(IDbConnection dbConnection)
        {
            _stringBuilder = new StringBuilder();
            _dbConnection = dbConnection;
        }

        public async Task<UserRequest> CanDoLogin(UserRequest request)
        {
            var pwd = ComputeHash(request.Password, new SHA256CryptoServiceProvider());
            _stringBuilder.Append($"SELECT U.Login, U.Password FROM Users as U WHERE Login = '{request.Name}' and Password = '{pwd}'");

            var result = await _dbConnection.QuerySingleAsync<UserRequest>(_stringBuilder.ToString());

            return result;
        }

        public async Task<string> ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashBytes = algorithm.ComputeHash(inputBytes);

            return await Task.FromResult(BitConverter.ToString(hashBytes));
        }

        public async Task RegisterUser(UserRequest request)
        {
            var pwd = ComputeHash(request.Password, new SHA256CryptoServiceProvider());
            _stringBuilder.Append($"INSERT INTO Users Values ");
            _stringBuilder.Append($"('{request.Name}', '{request.Login}', '{pwd}', '{request.Email}')");

            await _dbConnection.QueryAsync(_stringBuilder.ToString());
        }
    }
}
