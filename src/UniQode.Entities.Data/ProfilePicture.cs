using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniQode.Entities.Data.Core;

namespace UniQode.Entities.Data
{
    [Table("ProfilePictures")]
    public class ProfilePicture : UniqueEntity
    {
        [Required]
        public Employee Employee { get; set; }

        [Required, MaxLength(256)]
        public string OriginalUrl { get; set; }

        [Required, MaxLength(256)]
        public string SquareUrl { get; set; }
    }
}