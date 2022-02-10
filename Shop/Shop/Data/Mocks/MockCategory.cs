using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.Data.Mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get 
            { 
                return new List<Category>
                {
                    new Category { CategoryName = "Электромобили", Description = "Современный вид танспорта"},
                    new Category { CategoryName = "Классические автомобили", Description = "Автомобиль с двигателем внутреннего сгорания"}
                }; 
            }
        }
    }
}
