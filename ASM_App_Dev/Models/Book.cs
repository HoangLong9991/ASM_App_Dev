using System;

namespace ASM_App_Dev.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string NameBook { get; set; }
        public int QuantityBook { get; set; }
        public int Price { get; set; }
        public string InformationBook { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
