using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using UniQode.Entities.Data;

namespace UniQode.Models.Shared
{
    public class EmployeeModel
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [Required, MaxLength(50)]
        public string Title { get; set; }
        
        [Required, MaxLength(50)]
        public string Email { get; set; }

        [Required, MaxLength(256)]
        public string ShortDescription { get; set; }

        [Required]
        public string Description { get; set; }
        
        public ProfilePictureModel ProfilePicture { get; set; }
        
        public ICollection<SpotlightModel> Spotlights { get; set; }
        
        public ICollection<ExternalReferenceModel> ExternalReferences { get; set; }

        public static EmployeeModel FromDto(Employee dto)
        {
            if (dto == null)
                return null;

            return new EmployeeModel
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Title = dto.Title,
                Email = dto.Email,
                ShortDescription = dto.ShortDescription,
                Description = dto.Description,
                ProfilePicture = ProfilePictureModel.FromDto(dto.ProfilePicture),
                ExternalReferences = dto.ExternalReferences.Select(ExternalReferenceModel.FromDto).ToList(),
                Spotlights = dto.Spotlights.Select(SpotlightModel.FromDto).ToList()
            };
        }
    }
}