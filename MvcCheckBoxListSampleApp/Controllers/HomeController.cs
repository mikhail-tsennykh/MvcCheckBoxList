using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcCheckBoxListSampleApp.Model;
using MvcCheckBoxListSampleApp.ViewModels;

namespace MvcCheckBoxListSampleApp.Controllers {
	public class HomeController : Controller {

		public ActionResult Index() {
			return RedirectToAction("SelectListBased");
		}

		public ActionResult SelectListBased(string[] cities) {
			// setup properties
			var model = new CitiesViewModel();
			var selectedCities = new List<City>();

			// if an array of posted city ids exists and is not empty,
			// save selected ids
			if (cities != null && cities.Any()) {
				selectedCities = CityRepository.GetAll()
					.Where(x => cities.Any(s => x.Id.ToString().Equals(s))).ToList();
				model.WasPosted = true;
			}

			// setup a view model
			//model.AvailableCities = CityRepository.GetAll();
			model.SelectedCities = selectedCities;

			return View(model);
		}

		public ActionResult ModelBased(string[] cities, PostedCities postedCities) {
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
			model.AvailableCities = CityRepository.GetAll();
			model.SelectedCities = selectedCities;
			model.PostedCities = postedCities;

			return View(model);
		}

	}
}