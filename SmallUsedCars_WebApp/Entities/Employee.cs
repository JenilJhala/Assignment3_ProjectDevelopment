using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SmallUsedCars_WebApp.Entities
{
    public class Employee : IdentityUser
    {
        [Required]
        public string EmployeeName { get; set; }
    }
}
