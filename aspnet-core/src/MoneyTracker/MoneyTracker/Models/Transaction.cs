using System.Collections.Generic;
using MoneyTracker.Models.BaseEntities;
using System.Collections.ObjectModel;

namespace MoneyTracker.Models {
    public class Transaction : FullAuditedEntity {
        public string Name { get; set; }
        public bool Repeat { get; set; }
        public decimal Amount { get; set; }
        public ICollection<Category> Categories { get; set; }

        public Transaction() {
            Categories = new Collection<Category>();
        }
    }
}
