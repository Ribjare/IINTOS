using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IINTOS.ViewModels
{
    /// <summary>
    ///     View model for the creation of a professor
    /// </summary>
    public class UserCreateViewModel
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
        /// Get and set of the password
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password{get;set;}

        /// <summary>
        /// Get and set of the confirmed password
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match. Did you already forgot the pw?")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// gets and sets A small introduction to the user
        /// </summary>
        [DataType(DataType.MultilineText)]
        public string? About { get; set; }

        /// <summary>
        /// Get and set of the phone number
        /// </summary>
        [DataType(DataType.PhoneNumber)]
        [Phone(ErrorMessage = "Don't you all have phones!?")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Get and set of the nationality name
        /// </summary>
        [Required]
        [Display(Name = "Nationality")]
        public int Nationality { get; set; }

        /// <summary>
        /// Get and set of the School name
        /// </summary>
        [Required]
        [Display(Name = "School")]
        public int School { get; set; }

    }
}
