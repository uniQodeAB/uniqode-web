using System;
using System.ComponentModel.DataAnnotations;
using UniQode.Entities.Data;

namespace UniQode.Models.Shared
{
    public class SpotlightQuestionModel
    {
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "A text is required")] 
        [MaxLength(512, ErrorMessage = "The text cannot be longer than 512 chars")]
        [Display(Name = "Text")]
        public string Text { get; set; }

        public static SpotlightQuestionModel FromDto(SpotlightQuestion dto)
        {
            return new SpotlightQuestionModel
            {
                Id = dto.Id,
                Text = dto.Text
            };
        }

        public SpotlightQuestion ToDto()
        {
            return new SpotlightQuestion
            {
                Id = this.Id,
                Text = this.Text
            };
        }
    }
}