using System.Threading.Tasks;

namespace MoneyTracker.Interfaces {
    public interface IUoW {
        Task Complete();
    }
}
