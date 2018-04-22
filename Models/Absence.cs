using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FKTeplice.Models
{
    public class Absence
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime From { get; set; }

        [DataType(DataType.Date)]
        public DateTime To { get; set; }

        public int DaysCount { get; set; }

        public int PlayerId { get; set; }

        [ForeignKey("PlayerId")]
        public virtual Player Player { get; set; }
    }
}
