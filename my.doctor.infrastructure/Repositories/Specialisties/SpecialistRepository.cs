using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using my.doctor.domain.Interfaces.Repositories.Specialisties;
using my.doctor.domain.Models;
using Dapper;

namespace my.doctor.infrastructure.Repositories.Specialisties
{
    public class SpecialistRepository : ISpecialistRepository
    {
        private readonly IDbConnection _dbConnection;

        public SpecialistRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Task Delete(object id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Specialist>> GetAll()
        {
            var query = "SELECT s.Name, s.IDSpecialty FROM Specialties as S WITH (NOLOCK)";
            return await _dbConnection.QueryAsync<Specialist>(query);
        }

        public Task<Specialist> GetById(object id)
        {
            throw new System.NotImplementedException();
        }

        public Task Insert(Specialist obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Specialist obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
