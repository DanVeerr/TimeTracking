using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeTracking.Models;

namespace TimeTracking.ViewModels
{
    public class ReportsViewModel
    {
        public IEnumerable<Report> Reports { get; set; }
        public IEnumerable<UserModel> Users { get; set; }
    }
}
