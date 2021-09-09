using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimeTracking.Models
{
    public class User
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано имя")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        public string Surname { get; set; }
        public string Patronymic { get; set; }
       
        [Remote(action: "CheckEmail", controller: "Home", ErrorMessage = "Email уже используется")]
        [Required(ErrorMessage = "Не указан электронный адрес")]
        [EmailAddress(ErrorMessage = "Некорректный электронный адрес")]
        public string Email { get; set; }

        

    }
}
