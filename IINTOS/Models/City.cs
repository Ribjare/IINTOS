using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IINTOS.Models
{
    /// <summary>
    /// Class of a city
    /// </summary>
    public class City
    {
        /// <summary>
        /// Get and set of the id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Get and set of the name
        /// </summary>
        [Display(Name = "City")]
        public string Name { get; set; }

        /// <summary>
        /// Navigation Property for Country
        /// </summary>
        public Country Country { get; set; }
    }
}
