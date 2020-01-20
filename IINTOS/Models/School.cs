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
        /// gets and sets Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Get and set name
        /// </summary>
        [Display(Name = "School")]
        public string Name { get; set; }

        /// <summary>
        /// gets and sets Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// gets and sets Website
        /// </summary>
        public string? Website { get; set; }

        /// <summary>
        /// Navigation Property fot the City
        /// </summary>
        public City City { get; set; }
        
    }
}
