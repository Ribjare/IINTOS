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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the sort. </summary>
        ///
        /// <value> The short name of the Countries. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string SortName { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the phone code of the country. </summary>
        ///
        /// <value> The phone code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public String PhoneCode { get; set; }
    }
}
