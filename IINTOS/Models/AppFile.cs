using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IINTOS.Models
{
    /// <summary>
    /// Normal File, just a fancy name
    /// </summary>
    public class BufferedSingleFileUploadDbModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
 
    }
}