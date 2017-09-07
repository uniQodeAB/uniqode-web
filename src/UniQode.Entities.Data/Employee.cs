using Newtonsoft.Json;
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
        [JsonProperty("Id")]
        public Guid EmpId => base.Id;

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
        [JsonIgnore]
        public string ShortDescription { get; set; }

        [Required]
        [JsonIgnore]
        public string Description { get; set; }

        [Required]
        public virtual ProfilePicture ProfilePicture { get; set; }

        [Required]
        public virtual ICollection<Spotlight> Spotlights { get; set; }

        [Required]
        public virtual ICollection<ExternalReference> ExternalReferences { get; set; }
    }
}