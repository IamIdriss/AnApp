using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnApp.Shared.Models
{
    public class Upload
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FileName { get; set; } = default!;
        public DateTime UploadTimestamp { get; set; } = default!;
        public DateTime? ProcessedTimestamp { get; set; } = default!;

        [Required]
        public string FileContent { get; set; } = default!;
    }
}
