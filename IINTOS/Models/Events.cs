using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IINTOS.Models
{
    /// <summary>
    /// Represents an event
    /// </summary>
    public class Events
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Subjetct { get; set; }
        public string TransversalSkill { get; set; }
        public string EducationTopic { get; set; }
        public int AgeRangeStart { get; set; }
        public int AgeRangeEnd { get; set; }
        public DateTime Date { get; set; }



        public Language Language { get; set; }

        public School School { get; set; }
    }
}
