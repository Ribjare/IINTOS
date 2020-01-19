using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IINTOS.Models
{
    /// <summary>
    ///     Representation of a news
    /// </summary>
    public class Newsletter
    {
        /// <summary>
        /// Get and sets the ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets and sets the title
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Title { get; set; }

        /// <summary>
        /// Gets and sets the description
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Description { get; set; }

        /// <summary>
        /// Get and sets the date
        /// </summary>
        public DateTime date { get; set; }//--ver como se mete automaticamente o atual

        //files

        //images

        
    }
}
