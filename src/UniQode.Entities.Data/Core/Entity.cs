using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniQode.Entities.Data.Core
{
    public abstract class Entity<T> : IEntity<T>
    {
        protected Entity()
        {

        }

        protected Entity(T id)
        {
            Id = id;
        }

        [Key]
        [Column(Order = 0)]
        public T Id { get; set; }
    }
}