
namespace CSC.IO
{
    /// <summary>
    /// Load system that notifies listeners at start
    /// </summary>
    public class StartLoadSystem : LoadSystem
    {
        private void Start()
        {
            NotifyListeners();
        }
    }
}