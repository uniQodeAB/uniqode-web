using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using UniQode.Entities.Data;
using UniQode.Entities.Enums;

namespace UniQode.Models.Shared
{
    public class MottoModel
    {
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        [Required]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "A title is required")]
        [MaxLength(32, ErrorMessage = "The title cannot be longer than 32 chars")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "A description is required")]
        [MaxLength(1024, ErrorMessage = "The description cannot be longer than 1024 chars")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public State State { get; set; }

        [Bindable(false)]
        public AdminAction Action { get; set; }

        public static MottoModel FromDto(Motto dto)
        {
            return new MottoModel
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description
            };
        }

        public Motto ToDto()
        {
            return new Motto
            {
                Id = this.Id,
                Title = this.Title,
                Description = this.Description
            };
        }
    }
}