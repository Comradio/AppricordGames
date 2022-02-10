using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }

        [Display(Name = "Имя")]
        [MinLength(2)]
        [Required(ErrorMessage = "Минимальная длина имени - 2 символа")]
        public string Name { get; set; }

        [Display(Name = "Фамилия")]
        [MinLength(2)]
        [Required(ErrorMessage = "Минимальная длина фамилии - 2 символа")]
        public string Surname { get; set; }

        [Display(Name = "Адрес")]
        [MinLength(10)]
        [Required(ErrorMessage = "Минимальная длина адреса - 10 символов")]
        public string Address { get; set; }

        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10)]
        [Required(ErrorMessage = "Длина номера телефона должна быть равна 10 символам")]
        public string Phone { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [MinLength(12)]
        [Required(ErrorMessage = "Минимальная длина Email - 12 символов")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)] //чтобы поле не отображалось даже в исходном коде
        public DateTime OrderTime { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

    }
}
