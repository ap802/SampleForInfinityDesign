using System;

namespace MySMA.Models
{
    /// <summary>
    /// Base class for model objects. Allows us to use a generic repository.
    /// </summary>
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
    }
}