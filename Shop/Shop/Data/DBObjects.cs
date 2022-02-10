using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent Content)
        {
            if (!Content.Category.Any())
                Content.Category.AddRange(Categories.Select(c => c.Value));

            if (!Content.Car.Any())
            {
                Content.AddRange(
                    new Car
                    {
                        Name = "Tesla Model S",
                        ShortDescriprion = "Быстрый электромобиль.",
                        LongDescription = "Красивый, быстрый и очень тихий электромобиль компании Tesla.",
                        Image = "/image/Tesla Model S.jpg",
                        Price = 2500000,
                        IsFavourite = true,
                        Available = true,
                        Category = Categories["Электромобили"]
                    },
                    new Car
                    {
                        Name = "Ford Fiesta",
                        ShortDescriprion = "Компактный хэтчбек Ford Fiesta B-класса.",
                        LongDescription = "Компактный хэтчбек Ford Fiesta относится к B-классу, однако салон его спроектирован так, чтобы быть максимально большим и наполненным полезными функциями, при этом не в ущерб изящности отделки.",
                        Image = "/image/Ford Fiesta.jpg",
                        Price = 850000,
                        IsFavourite = false,
                        Available = true,
                        Category = Categories["Классические автомобили"]
                    },
                    new Car
                    {
                        Name = "BMW M3",
                        ShortDescriprion = "Атлетичные пропорции и классический четырехдверный трехобъемный дизайн.",
                        LongDescription = "Автомобили M BMW 3 серии сочетают в себе атлетичные пропорции и классический четырехдверный трехобъемный дизайн с фирменной спортивностью M. Возглавляет пару эффектных седанов BMW M3 Competition с феноменальными 510 л.с. и 650 Нм крутящего момента.",
                        Image = "/image/BMW M3.jpg",
                        Price = 8110000,
                        IsFavourite = true,
                        Available = false,
                        Category = Categories["Классические автомобили"]
                    },
                    new Car
                    {
                        Name = "Mercedes C class",
                        ShortDescriprion = "Мир безмятежного комфорта, гармонии пропорций, ярких эмоций и элегантной спортивности.",
                        LongDescription = "Новый Mercedes-Benz C-Класс седан ― это мир безмятежного комфорта, гармонии пропорций, ярких эмоций и элегантной спортивности. Уровень технической оснащенности впечатлит самого искушенного автолюбителя.",
                        Image = "/image/Mercedes C class.jpg",
                        Price = 3660000,
                        IsFavourite = false,
                        Available = false,
                        Category = Categories["Классические автомобили"]
                    },
                    new Car
                    {
                        Name = "Nissan Leaf",
                        ShortDescriprion = "Передовые технологии в новом Nissan LEAF.",
                        LongDescription = "Новый Nissan LEAF предлагает улучшенный до 378 км диапазон на одной зарядке, что в сочетании с расширенной европейской сетью быстрой зарядки CHAdeMO позволяет водителю наслаждаться более продолжительными поездками.",
                        Image = "/image/Nissan Leaf.jpg",
                        Price = 3350000,
                        IsFavourite = true,
                        Available = true,
                        Category = Categories["Классические автомобили"]
                    },
                    new Car
                    {
                        Name = "Audi Skysphere",
                        ShortDescriprion = "Электромобиль, способный превращаться из спортивного родстера в беспилотный \"гран-турер\".",
                        LongDescription = "Экспериментальный электрический автомобиль под названием Skysphere, отличительными чертами которого стала раздвижная колесная база и система автоматического управления. Таким образом, путем нажатия кнопки автомобиль может превращаться из спортивного родстера длиной 4,94 м в комфортабельный «гран-турер» длиной 5,19 метра.",
                        Image = "/image/Audi Skysphere.jpg",
                        Price = 25000000,
                        IsFavourite = true,
                        Available = false,
                        Category = Categories["Электромобили"]
                    });
            }

            Content.SaveChanges();
        }

        private static Dictionary<string, Category> Category;
        public static Dictionary<string, Category> Categories {
            get
            {
                if(Category == null)
                {
                    var List = new Category[]
                    {
                        new Category { CategoryName = "Электромобили", Description = "Современный вид танспорта"},
                        new Category { CategoryName = "Классические автомобили", Description = "Автомобиль с двигателем внутреннего сгорания"}
                    };

                    Category = new Dictionary<string, Category>();
                    foreach (Category Element in List)
                        Category.Add(Element.CategoryName, Element);
                }
                return Category;
            } 
        }
    }
}
