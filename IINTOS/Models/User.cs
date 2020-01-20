﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IINTOS.Models
{
    /// <summary>
    /// User of the platform
    /// Can be in this roles: School, Professor
    /// </summary>
    public class User: IdentityUser
    {
        /// <summary>
        /// gets and sets Name of the user
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// gets and sets A small introduction to the user
        /// </summary>
        public string? About { get; set; } = "";

        /// <summary>
        /// Get and sets the active property
        /// </summary>
        public bool? Active { get; set; } = false;
        
        /// <summary>
        /// Navigation Property for the nationality
        /// </summary>
        public Nationality Nationality { get; set; }

    }
}
