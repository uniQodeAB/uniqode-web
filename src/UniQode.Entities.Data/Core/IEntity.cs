using System;

namespace UniQode.Entities.Data.Core
{
    public interface IEntity<T>
    {
        T Id { set; get; } 
    }
}