using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IINTOS.Models
{
    /// <summary>
    /// Represents a Country
    /// </summary>
    public class Country
    {
        /// <summary>
        /// Get and sets of the id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Get and set of the name of the country
        /// </summary>
        [Display(Name = "Country")]
        public string Name { get; set; }
    }
}
