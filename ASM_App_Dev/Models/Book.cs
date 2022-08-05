using System;
using System.ComponentModel.DataAnnotations;

namespace ASM_App_Dev.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string NameBook { get; set; }
        [Required]
        public int QuantityBook { get; set; }
        [Required]
        public int Price { get; set; }
        public string InformationBook { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
