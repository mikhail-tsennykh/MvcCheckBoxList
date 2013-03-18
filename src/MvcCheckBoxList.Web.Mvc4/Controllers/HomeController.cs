using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcCheckBoxList.Web.Mvc4.Model;
using MvcCheckBoxList.Web.Mvc4.ViewModels;

namespace MvcCheckBoxList.Web.Mvc4.Controllers {
	public class HomeController : BaseController {

    public ActionResult Index(string[] cities, PostedCities postedCities) {
      return View(GetCitiesModel(cities, postedCities));
    }

		public ActionResult Examples(string[] cities, PostedCities postedCities) {
		  return View(GetCitiesModel(cities, postedCities));
		}

    public ActionResult Documentation() {
      return View();
    }
    
    public ActionResult Test(string[] cities, PostedCities postedCities) {
      return View(GetCitiesModel(cities, postedCities));
    }

    // todo: move to Data Service
    private CitiesViewModel GetCitiesModel(string[] cities, PostedCities postedCities) {
			// setup properties
			var model = new CitiesViewModel();
			var selectedCities = new List<City>();
			var postedCityIDs = new string[0];
			if (postedCities == null) postedCities = new PostedCities();

			// if an array of posted city ids exists and is not empty,
			// save selected ids
			if (cities != null && cities.Any()) {
				postedCityIDs = cities;
				postedCities.CityIDs = cities;
			}
			// if a view model array of posted city ids exists and is not empty,
			// save selected ids
			if (postedCities.CityIDs != null && postedCities.CityIDs.Any()) {
				postedCityIDs = postedCities.CityIDs;
				model.WasPosted = true;
			}
			// if there are any selected ids saved, create a list of cities
			if (postedCityIDs.Any())
				selectedCities = CityRepository.GetAll()
					.Where(x => postedCityIDs.Any(s => x.Id.ToString().Equals(s))).ToList();

			// setup a view model
			model.AvailableCities = CityRepository.GetAll().ToList();
			model.SelectedCities = selectedCities;
			model.PostedCities = postedCities;

      return model;
    }

	  public ActionResult Contributors() {
	    return View();
	  }

	}
}