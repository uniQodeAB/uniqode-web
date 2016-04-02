using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniQode.Entities.Data.Core;

namespace UniQode.Entities.Data
{
    [Table("Accounts")]
    public class Account : UniqueEntity
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Index(IsUnique = true)]
        [Required, MaxLength(100)]
        public string Email { get; set; }

        [Required, MaxLength(200)]
        public string HashedPassword { get; set; }
    }
}