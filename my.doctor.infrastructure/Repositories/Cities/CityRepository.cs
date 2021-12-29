using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using my.doctor.domain.Interfaces.Repositories.Cities;
using my.doctor.domain.Models;

namespace my.doctor.infrastructure.Repositories.Cities
{
    public class CityRepository : ICityRepository
    {
        private readonly IDbConnection _dbConnection;

        public CityRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Task Delete(object id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<City>> GetAll()
        {
            var query = "SELECT c.Name, c.IDCity From Cities as C WITH (NOLOCK)";
            return await _dbConnection.QueryAsync<City>(query);
        }

        public Task<City> GetById(object id)
        {
            throw new System.NotImplementedException();
        }

        public Task Insert(City obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(City obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
