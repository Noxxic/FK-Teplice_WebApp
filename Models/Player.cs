using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FKTeplice.Models {
    public class Player {

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        public string LastName { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode=true)]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        public byte[] Photo { get; set; }

        public string School { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode=true)]
        [DataType(DataType.Date)]
        public DateTime ContractFrom { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode=true)]
        [DataType(DataType.Date)]
        public DateTime ContractTo { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; }

        public double Fat { get; set; }

        public int? TeamId { get; set; }

        [ForeignKey("TeamId")]
        public virtual Team Team { get; set; }
        // TODO: Rodné číslo, rodinná anamnéza, post, alt post (tabulka)

        public virtual ICollection<Absence> Absences { get; set; } = new HashSet<Absence>();

        public virtual ICollection<PlayerMatch> PlayerMatch { get; set; } = new HashSet<PlayerMatch>();

        [NotMapped]
        public virtual List<Match> Matches => PlayerMatch.Select(x => x.Match).ToList();

        [NotMapped]
        public virtual string FullName => $"{FirstName} {LastName}";

        [NotMapped]
        public List<Document> Contracts { get; set; }
        
    }
}