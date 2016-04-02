using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using UniQode.Entities.Data;
using UniQode.Entities.Enums;

namespace UniQode.Models.Shared
{
    public class WorkFieldModel
    {
        [System.Web.Mvc.HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "A title is required"), MaxLength(32, ErrorMessage = "The title cannot be longer than 32 chars")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "A description is required"), MaxLength(256, ErrorMessage = "The description cannot be longer than 256 chars")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Bindable(false)]
        public AdminAction Action { get; set; }

        [Bindable(false)]
        public State State { get; set; }

        public static WorkFieldModel FromDto(WorkField dto)
        {
            return new WorkFieldModel
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description
            };
        }

        public WorkField ToDto()
        {
            return new WorkField
            {
                Id = this.Id,
                Title = this.Title,
                Description = this.Description
            };
        }
    }
}