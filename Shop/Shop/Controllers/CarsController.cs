using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;

        public CarsController(IAllCars iAllCars, ICarsCategory iCarsCategory)
        {
            _allCars = iAllCars;
            _allCategories = iCarsCategory;
        }

        [Route("Cars/ListCars")]
        [Route("Cars/ListCars/{category}")]
        public ViewResult ListCars(string category, string searchString)
        {
            string _category = category;
            IEnumerable<Car> cars = null;
            string currentCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                cars = _allCars.Cars.OrderBy(i => i.id);
                currentCategory = "Все автомобили";
            }
            else
            {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.CategoryName.Equals("Электромобили")).OrderBy(i => i.id);
                }
                else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.CategoryName.Equals("Классические автомобили")).OrderBy(i => i.id);
                }

                currentCategory = cars.FirstOrDefault().Category.CategoryName;

            }

            // Поиск по всем автомобилям или по категории
            if (!string.IsNullOrEmpty(searchString))
            {
                cars = cars.Where(i => i.Name.Contains(searchString));
            }

            var carObject = new CarsListViewModel
            {
                AllCars = cars,
                CurrentCategory = currentCategory
            };

            return View(carObject);
        }
    }
}
