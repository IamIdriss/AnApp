using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace AnApp.Shared.Models
{
  public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string? Token { get; set; } = default!;
        public bool IsDeleting { get; set; } = default!;
        [JsonIgnore]
        public string? PasswordHash { get; set; }
    }
}
