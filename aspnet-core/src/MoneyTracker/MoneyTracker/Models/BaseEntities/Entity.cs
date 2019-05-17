using MoneyTracker.Models.BaseEntities.Interfaces;

namespace MoneyTracker.Models.BaseEntities {
    public class Entity<T> : IEntity {
        public T Id { get; set; }
    }
}
