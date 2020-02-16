using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace IINTOS.Models
{
    /// <summary>
    /// Represents a Nationality
    /// </summary>
    public class Nationality
    {
        /// <summary>
        /// gets and set id
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// Gets and sets the name
        /// </summary>
        [Display(Name = "Nationality")]
        public string Name { get; set; }

    }
}
