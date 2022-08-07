using ASM_App_Dev.Models;
using System.Collections.Generic;

namespace ASM_App_Dev.ViewModels
{
    public class BookCategoriesViewModel
    {
        public Book Book { get; set; }
        public IEnumerable<Category> Categories { get; set; } 
    }
}
