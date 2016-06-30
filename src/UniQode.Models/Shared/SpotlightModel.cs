using System.ComponentModel.DataAnnotations;
using UniQode.Entities.Data;

namespace UniQode.Models.Shared
{
    public class SpotlightModel
    {
        [Required]
        public SpotlightQuestionModel SpotlightQuestion { get; set; }

        [Required]
        public string Answer { get; set; }

        public static SpotlightModel FromDto(Spotlight dto)
        {
            if (dto == null)
                return null;

            return new SpotlightModel
            {
                SpotlightQuestion = SpotlightQuestionModel.FromDto(dto.SpotlightQuestion),
                Answer = dto.Answer
            };
        }
    }
}