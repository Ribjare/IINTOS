using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IINTOS.ViewModels
{
    public class CoordinatiorSchoolViewModel
    {
        /// <summary>
        /// Gets and sets Name of the user
        /// </summary>
        /// 
        [Required]
        [StringLength(100, ErrorMessage = "You must have a name don't you?", MinimumLength = 1)]
        public string Name { get; set; }

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
        public string Password { get; set; }

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
        public string Nationality { get; set; }

        //School Inputs Zone

        [Required]
        [Display(Name = "School Name")]
        public string SchoolName { get; set; }

        [Required]
        [Display(Name = "School Address")]
        public string SchoolAddress { get; set; }

        [Display(Name = "School Website")]
        public string SchoolWebsite { get; set; }

        [Required]
        [Display(Name = "School City")]
        public string SchoolCity { get; set; }



    }
}
