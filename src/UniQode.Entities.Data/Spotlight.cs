using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniQode.Entities.Data.Core;

namespace UniQode.Entities.Data
{
    [Table("Spotlights")]
    public class Spotlight : UniqueEntity
    {
        [Required]
        [JsonIgnore]
        public virtual SpotlightQuestion SpotlightQuestion { get; set; }

        [Required]
        [JsonIgnore]
        public Employee Employee { get; set; }

        public string Question { get { return SpotlightQuestion.Text; } }

        [Required]
        public string Answer { get; set; }
    }
}