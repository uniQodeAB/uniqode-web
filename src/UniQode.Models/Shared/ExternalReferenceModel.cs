using System.ComponentModel.DataAnnotations;
using UniQode.Entities.Data;

namespace UniQode.Models.Shared
{
    public class ExternalReferenceModel
    {
        [Required]
        public string Type { get; set; }

        [Required, MaxLength(256)]
        public string Url { get; set; }

        public static ExternalReferenceModel FromDto(ExternalReference dto)
        {
            if (dto == null)
                return null;

            return new ExternalReferenceModel
            {
                Type = dto.Type.ToString(),
                Url = dto.Url
            };
        }
    }
}