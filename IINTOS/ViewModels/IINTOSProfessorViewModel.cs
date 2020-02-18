using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IINTOS.ViewModels
{
    public class IINTOSProfessorViewModel
    {


        /// <summary>
        /// Gets and sets Name of the user
        /// </summary>
        /// 
        [Required]
        [StringLength(100, ErrorMessage = "You must have a name don't you?", MinimumLength = 1)]
        public String Name { get; set; }

        /// <summary>
        /// Gets and sets of the Email
        /// </summary>
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// Get and set of the nationality name
        /// </summary>
        [Required]
        [Display(Name = "Nationality")]
        public int Nationality { get; set; }

    }
}
