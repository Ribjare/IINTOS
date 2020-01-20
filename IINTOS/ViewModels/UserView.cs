using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IINTOS.ViewModels
{
    public class UserView : PageModel
    {

        /// gets and sets Name of the user
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// gets and sets A small introduction to the user
        /// </summary>
        public string? About { get; set; } = "";

        /// <summary>
        /// Get and sets the active property
        /// </summary>
        public bool? Active { get; set; } = false;



    }
}
