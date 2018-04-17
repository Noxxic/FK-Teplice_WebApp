using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using FKTeplice.Data;
using Microsoft.AspNetCore.Http;

namespace FKTeplice.Models.PlayerViewModels
{
    public class UpdateStorePlayerModel {
        
        public int? Id { get; set; }

        [Required]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        public IFormFile Photo { get; set; }
        public int? TeamId { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Fat { get; set; }
        public string School { get; set; }

        public ICollection<Team> Teams { get; set; }
    }
}