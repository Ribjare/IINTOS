using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IINTOS.Models
{
    /// <summary>
    /// User of the platform
    /// Can be in this roles: School, Professor
    /// </summary>
    public class User: IdentityUser
    {
        /// <summary>
        /// gets and sets Name of the user
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// Get and sets the active property, 
        /// this is if is validated by system admin or the school cordinatior
        /// </summary>
        #nullable enable
        public String? About { get; set; }

        public bool? Active { get; set; } = false;
        
        /// <summary>
        /// Navigation Property for the nationality
        /// </summary>
        public Nationality Nationality { get; set; }

        /// <summary>
        /// FK of school
        /// </summary>
        public int SchoolId { get; set; }

        /// <summary>
        /// Navigation property fo the school
        /// </summary>
        public School School { get; set; }

    }
}
