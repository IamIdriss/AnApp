using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnApp.Shared.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = default!;
        [Required]
        public string Description { get; set; } = default!; 
        public ICollection<Agent> Agents { get; set; }
    }
}
