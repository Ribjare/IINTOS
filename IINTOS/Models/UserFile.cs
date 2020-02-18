using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IINTOS.Models
{
    public class UserFile
    {
        public int Id { get; set; }

        public string FileName { get; set; }
        public string ContentType { get; set; }

        public FileType FileType {get;set;}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the content. This Variable is 
        ///             where the file is stored
        /// </summary>
        ///
        /// <value> The content. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public byte[] Content { get; set; }
    }
}
