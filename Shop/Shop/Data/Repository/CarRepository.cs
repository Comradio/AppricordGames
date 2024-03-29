﻿using Microsoft.EntityFrameworkCore;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Data.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly AppDBContent appDBContent;
        public CarRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Car> Cars => appDBContent.Car.Include(c => c.Category);

        public IEnumerable<Car> GetFavouriteCars => appDBContent.Car.Where(p => p.IsFavourite).Include(c => c.Category);

        public Car GetObjectCar(int carId) => appDBContent.Car.FirstOrDefault(p => p.id == carId);
    }
}
