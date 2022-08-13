using ASM_App_Dev.Models;
using Microsoft.AspNetCore.Http;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ASM_App_Dev.ViewModels
{
    public class BookCategoriesViewModel
    {
        public Book Book { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        [Display(Name = "File")]
        public IFormFile FormFile { get; set; }
    }
}


