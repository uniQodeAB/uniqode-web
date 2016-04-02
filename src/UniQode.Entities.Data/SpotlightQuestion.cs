using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniQode.Entities.Data.Core;

namespace UniQode.Entities.Data
{
    [Table("SpotlightQuestions")]
    public class SpotlightQuestion : UniqueEntity
    {
        [Required, MaxLength(512)]
        public string Text { get; set; }
    }
}