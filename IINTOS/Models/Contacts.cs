using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IINTOS.Models
{
    /// <summary>
    /// Class responsable of the storage of the contact information
    /// </summary>
    public class Contacts
    {
        
        public int Id { get; set; }

        [Display(Name = "Phone Number")]
        //[Range(9, 9, ErrorMessage = "")]
        public int Phone { get; set; }

        public string Email { get; set; }


    }
}
