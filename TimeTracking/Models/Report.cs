using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimeTracking.Models
{
    public class Report
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "Не указано примечание")]
        public string Notes { get; set; }
        [Range(1, 10, ErrorMessage = "Количество часов может быть от 1 до 10")] 
        [Required(ErrorMessage = "Не указано количество часов")]
        public int Hours { get; set; }
        public int OwnerId { get; set; }
        
        [Remote(action: "CheckDate", controller: "Tracking", ErrorMessage = "Некорректная дата")]
        [Required(ErrorMessage = "Не указана дата")]
        public DateTime Date { get; set; }
    }
}
