using System.Collections.Generic;
using System.Linq;

namespace MvcCheckBoxListSampleApp.Model {
	public static class CityRepository {
		public static City Get(int id) {
			return GetAll().SingleOrDefault(x => x.Id.Equals(id));
		}
		public static IEnumerable<City> GetAll() {
			return new List<City> {
			                      	new City {Name = "Monroe", Id = 1},
			                      	new City {Name = "Moscow", Id = 2},
			                      	new City {Name = "New Orleans", Id = 3},
			                      	new City {Name = "Ottawa", Id = 4},
			                      	new City {Name = "Mumbai", Id = 5},
			                      	new City {Name = "Rome", Id = 6},
			                      	new City {Name = "Rio", Id = 7}
			                      };
		}
	}
}