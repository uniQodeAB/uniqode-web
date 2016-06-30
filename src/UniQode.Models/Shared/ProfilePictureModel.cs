using System.ComponentModel.DataAnnotations;
using UniQode.Entities.Data;

namespace UniQode.Models.Shared
{
    public class ProfilePictureModel
    {
        [Required, MaxLength(256)]
        public string OriginalUrl { get; set; }

        [Required, MaxLength(256)]
        public string SquareUrl { get; set; }

        public static ProfilePictureModel FromDto(ProfilePicture dto)
        {
            if (dto == null)
                return null;

            return new ProfilePictureModel
            {
                OriginalUrl = dto.OriginalUrl,
                SquareUrl = dto.SquareUrl
            };
        }
    }
}