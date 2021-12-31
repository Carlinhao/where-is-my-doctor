using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Logging;
using my.doctor.domain.Interfaces.Repositories.Doctors;
using my.doctor.domain.Models;

namespace my.doctor.infrastructure.Repositories.Doctors
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly IDbConnection _dbConnection;
        private readonly ILogger<DoctorRepository> _logger;
        private readonly StringBuilder _stringBuilder;

        public DoctorRepository(IDbConnection dbConnection,
                                ILogger<DoctorRepository> logger)
        {
            _dbConnection = dbConnection;
            _logger = logger;
            _stringBuilder = new StringBuilder();
        }
               

        public async Task<IEnumerable<Doctor>> GetAll()
        {
            _stringBuilder.Append($"SELECT D.IDDoctors, ");
            _stringBuilder.Append($"D.CRM, ");
            _stringBuilder.Append($"D.Name, ");
            _stringBuilder.Append($"D.Address, ");
            _stringBuilder.Append($"D.Neighborhood, ");
            _stringBuilder.Append($"D.Email, ");
            _stringBuilder.Append($"D.WebsiteBlog, ");
            _stringBuilder.Append($"D.AttendsByConvenience, ");
            _stringBuilder.Append($"D.HasClinic, ");
            _stringBuilder.Append($"D.IDCity, ");
            _stringBuilder.Append($"D.IDSpecialty ");
            _stringBuilder.Append($"FROM Doctors as D WITH (NOLOCK) ");
            _stringBuilder.Append($"JOIN Cities as C ON c.IDCity = D.IDCity ");
            _stringBuilder.Append($"JOIN Specialties as S ON S.IDSpecialty = D.IDSpecialty");

            return await _dbConnection.QueryAsync<Doctor>(_stringBuilder.ToString());
        }

        public async Task Delete(object id)
        {
            _stringBuilder.Append($"DELETE Doctors WHERE IDDoctors = {id}");
            await _dbConnection.QueryAsync(_stringBuilder.ToString());
        }

        public async Task<Doctor> GetById(object id)
        {
            var query = $"SELECT * FROM Doctors WHERE IDDoctors = {id}";
            return await _dbConnection.QuerySingleAsync<Doctor>(query);            
        }

        public async Task Insert(Doctor request)
        {
            _stringBuilder.Append($"INSERT INTO Doctors Values");
            _stringBuilder.Append($"('{request.Crm}', ");
            _stringBuilder.Append($"'{request.Name}', ");
            _stringBuilder.Append($"'{request.Address}', ");
            _stringBuilder.Append($"'{request.Neighborhood}', ");
            _stringBuilder.Append($"'{request.Email}', ");
            _stringBuilder.Append($"'{request.AttendsByConvenience}', ");
            _stringBuilder.Append($"'{request.HasClinic}', ");
            _stringBuilder.Append($"'{request.WebsiteBlog}', ");
            _stringBuilder.Append($"{request.IdCity}, ");
            _stringBuilder.Append($"{request.IdSpecilist})");
            await _dbConnection.ExecuteAsync(_stringBuilder.ToString());
        }

        public async Task Update(Doctor request)
        {
            _stringBuilder.Append($"UPDATE Doctors SET ");
            _stringBuilder.Append($"CRM = '{request.Crm}', ");
            _stringBuilder.Append($"Name = '{request.Name}', ");
            _stringBuilder.Append($"Address = '{request.Address}', ");
            _stringBuilder.Append($"Neighborhood = '{request.Neighborhood}', ");
            _stringBuilder.Append($"Email = '{request.Email}', ");
            _stringBuilder.Append($"AttendsByConvenience = '{request.AttendsByConvenience}', ");
            _stringBuilder.Append($"HasClinic = '{request.HasClinic}', ");
            _stringBuilder.Append($"WebsiteBlog = '{request.WebsiteBlog}', ");
            _stringBuilder.Append($"IDCity = {request.IdCity}, ");
            _stringBuilder.Append($"IDSpecialty =  {request.IdSpecilist} where IDDoctors = {request.Id}");
            await _dbConnection.ExecuteAsync(_stringBuilder.ToString());
        }
    }
}
