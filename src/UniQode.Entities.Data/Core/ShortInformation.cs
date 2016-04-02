using System.ComponentModel.DataAnnotations;

namespace UniQode.Entities.Data.Core
{
    public abstract class ShortInformation : UniqueEntity
    {
        [Required, MaxLength(32)]
        public string Title { get; set; }

        [Required, MaxLength(1024)]
        public string Description { get; set; }
    }
}