using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FKTeplice.Models
{
    public class Document 
    {
        [Key]
        public int Id { get; set; }

        [MinLength(3)]
        [Required]
        public string Name { get; set; }

        [Required]
        public byte[] Content { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime UploadDate { get; set; }

        [Required]
        public string EntityTable { get; set; }

        [Required]
        public int EntityId { get; set; }

    }
}