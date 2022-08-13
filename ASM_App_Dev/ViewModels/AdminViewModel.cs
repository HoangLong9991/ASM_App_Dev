using ASM_App_Dev.Models;
using ASM_App_Dev.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ASM_App_Dev.ViewModels
{
    public class AdminViewModel
    {
        public List<ApplicationUser> Users { set; get; } = new List<ApplicationUser>();

        [BindProperty]
        public InputModel Input { get; set; }
        public SelectList RoleSelectList { get; set; }
        

        public class InputModel
        {
            
            public string Role { get; set; }


        }

    }
}
