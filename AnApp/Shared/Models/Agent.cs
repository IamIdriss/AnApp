using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnApp.Shared.Models
{
    public class Agent

    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = default!;
        [Required]
        public string LastName { get; set; } = default!;
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public string PhoneNumber { get; set; } = default!;
        [Required]
        public bool IsDeleting { get; set; } = default!;
        
        public Department Departments { get; set; }  
    }
}
