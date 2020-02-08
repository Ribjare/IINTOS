using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IINTOS.Models
{
    /// <summary>
    ///  Class that Represents the State of a Country
    /// </summary>
    public class State
    {
        /// <summary>
        /// Get and Sets for the Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Get and set for the Name of the state
        /// </summary>
        public string Name { get; set; }


        //--------------------- Foreign keys ------------------------

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the country. </summary>
        ///
        /// <value> The identifier of the country. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [ForeignKey("Country")]
        public int CountryId { get; set; }

        //------------ Navigation Property --------------

        /// <summary>
        /// Get and Set for the Country
        /// </summary>
        public Country Country { get; set; }

    }
}
