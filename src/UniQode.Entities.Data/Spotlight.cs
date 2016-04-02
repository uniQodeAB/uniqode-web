using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniQode.Entities.Data.Core;

namespace UniQode.Entities.Data
{
    [Table("Spotlights")]
    public class Spotlight : UniqueEntity
    {
        [Required]
        public SpotlightQuestion SpotlightQuestion { get; set; }

        [Required]
        public Employee Employee { get; set; }

        [Required]
        public string Answer { get; set; }
    }
}