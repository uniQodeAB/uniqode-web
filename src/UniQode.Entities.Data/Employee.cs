using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniQode.Entities.Data.Core;

namespace UniQode.Entities.Data
{
    [Table("Employees")]
    public class Employee : UniqueEntity
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [Required, MaxLength(50)]
        public string Title { get; set; }

        [Index(IsUnique = true)]
        [Required, MaxLength(50)]
        public string Email { get; set; }

        [Required, MaxLength(256)]
        public string ShortDescription { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public virtual ProfilePicture ProfilePicture { get; set; }

        [Required]
        public virtual ICollection<Spotlight> Spotlights { get; set; }

        [Required]
        public virtual ICollection<ExternalReference> ExternalReferences { get; set; }
    }
}