using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FKTeplice.Models
{
    public class Injury
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        public int PlayerId { get; set; }

        [ForeignKey("PlayerId")]
        public virtual Player Player { get; set; }

        // TODO: přidat klasifikaci
    }
}
