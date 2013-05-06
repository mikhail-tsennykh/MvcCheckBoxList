using System.Collections.Generic;
using MvcCheckBoxList.Web.Mvc4.Model;

namespace MvcCheckBoxList.Web.Mvc4.ViewModels {
	public class CitiesViewModel {
	  public object CustomListName;
	  public bool WasPosted { get; set; }
		public IList<City> AvailableCities { get; set; }
		public IList<City> SelectedCities { get; set; }
		public PostedCities PostedCities { get; set; }
	}
	public class PostedCities {
		// this array will be used to POST values from the form to the controller
		public string[] CityIDs { get; set; }
	}
}