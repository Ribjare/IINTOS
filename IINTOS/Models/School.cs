using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IINTOS.Models
{
    /// <summary>
    /// Represents a School
    /// </summary>
    public class School
    {
        /// <summary>
        /// Gets and sets Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Get and set name
        /// </summary>
        [Display(Name = "School")]
        public string Name { get; set; }

        /// <summary>
        /// Gets and sets Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets and sets Website
        /// </summary>
        public string? Website { get; set; }

        /// <summary>
        /// Navigation Property for the City
        /// </summary>
        public City City { get; set; }
        
        /// <summary>
        /// Navigation property for the coordinator user
        /// </summary>
        public User? Coordinator { get; set; }

    }
}
