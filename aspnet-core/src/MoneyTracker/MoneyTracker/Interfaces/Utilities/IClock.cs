using System;

namespace MoneyTracker.Interfaces.Utilities {
    public interface IClock {
        DateTime Now { get; }
    }
}
