using System;

namespace MoneyTracker.Utilities {
    public static class Guard {
        public static void AssertNotNull(object value) {
            if (value == null)
                throw new NullReferenceException();
        }
    }
}
