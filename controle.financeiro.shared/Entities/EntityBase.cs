
using System;

namespace controle.financeiro.shared.Entities
{
    public abstract class EntityBase : ErrorTracker
    {
        public EntityBase()
        {
            Id = Guid.NewGuid();
            CreateAt = DateTime.Now;
        }
        public Guid Id { get; private set; }
        public DateTime CreateAt { get; private set; }
    }
}
