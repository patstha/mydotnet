using System;

namespace hellolib
{
    public abstract class Entity
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
    }
}