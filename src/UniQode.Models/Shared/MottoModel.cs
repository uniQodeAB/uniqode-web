using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using UniQode.Entities.Data;
using UniQode.Entities.Enums;

namespace UniQode.Models.Shared
{
    public class MottoModelList
    {
        public MottoModelList()
        {
            Items = new List<MottoModel>();
        }
        public MottoModelList(ICollection<MottoModel> items)
        {
            Items = items;
        }
        public ICollection<MottoModel> Items { get; set; }
    }

    public class MottoModel //: IValidatableObject
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

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    var results = new List<ValidationResult>();

        //    Validator.TryValidateProperty(this.Id,
        //        new ValidationContext(this, null, null) { MemberName = "Id" },
        //        results);
        //    Validator.TryValidateProperty(this.Title,
        //        new ValidationContext(this, null, null) { MemberName = "Title" },
        //        results);
        //    Validator.TryValidateProperty(this.Description,
        //        new ValidationContext(this, null, null) { MemberName = "Description" },
        //        results);

        //    return results;
        //}
    }
}