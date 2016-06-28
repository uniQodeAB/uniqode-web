using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniQode.Entities.Data.Core;
using UniQode.Entities.Enums;

namespace UniQode.Entities.Data
{
    [Table("ExternalReferences")]
    public class ExternalReference : UniqueEntity
    {
        [Required]
        public Employee Employee { get; set; }

        [Required, Index]
        public ExternalReferenceType Type { get; set; }

        [Required, MaxLength(256)]
        public string Url { get; set; }
    }
}