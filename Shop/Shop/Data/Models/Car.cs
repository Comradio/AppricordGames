namespace Shop.Data.Models
{
    public class Car
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string ShortDescriprion { get; set; }
        public string LongDescription { get; set; }
        public string Image { get; set; } //URL-адрес
        public uint Price { get; set; }
        public bool IsFavourite { get; set; } //true - отображается на главной странице, false - не отображается на главной странице
        public bool Available { get; set; } //доступен ли товар и сколько единиц осталось на складе
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}
