using my.doctor.domain.Models;

namespace my.doctor.test.Utils
{
    internal class CityBuilder
    {
        private int _id;
        private string _name;

        public static CityBuilder Novo()
        {
            return new CityBuilder();
        }

        public CityBuilder WithId(int id)
        {
            _id = id;
            return this;
        }

        public CityBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public City Build()
        {
            return new City { Id = _id, Name = _name };
        }
    }
}
