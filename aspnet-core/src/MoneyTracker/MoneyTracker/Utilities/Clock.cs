using MoneyTracker.Interfaces.Utilities;
using System;

namespace MoneyTracker.Utilities {
    public class Clock : IClock {
        public DateTime Now => DateTime.UtcNow;
    }
}
