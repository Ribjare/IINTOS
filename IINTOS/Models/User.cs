using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IINTOS.Models
{
    /// <summary>
    /// User of the platform
    /// Can be in this roles: Coordinatior, Professor, IIntosCoordinatior, IINTOSProfessor, Admin
    /// </summary>
    public class User: IdentityUser
    {
        /// <summary>
        /// gets and sets Name of the user
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// gets and sets A small introduction to the user
        /// </summary>
        public string? About { get; set; } = "";

        /// <summary>
        /// Get and sets the active property, 
        /// this is if is validated by system admin or the school cordinatior
        /// </summary>
        public bool? Active { get; set; } = false;


        //-------------- ForeignKey ----------

        /// <summary>
        /// FK of school
        /// </summary>
        [ForeignKey("School")]
        public int? SchoolId { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the nationality. </summary>
        ///
        /// <value> The identifier of the nationality. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [ForeignKey("Nationality")]
        public int NationalityId { get; set; }

        
        //--------------- Navigation Property --------------

        /// <summary>
        /// Navigation Property for the nationality
        /// </summary>
        public Nationality Nationality { get; set; }

    
        /// <summary>
        /// Navigation property fo the school
        /// </summary>
        public School? School { get; set; }

    }
}
