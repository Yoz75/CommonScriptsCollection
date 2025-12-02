
namespace CSC.IO
{
	/// <summary>
	/// Load system that notifies listeners when you call <see cref="Load"/>
	/// </summary>
	public class ManualLoadSystem : LoadSystem
	{
		/// <summary>
		/// Notify listeners that they need to load self
		/// </summary>
		public void Load()
		{
			NotifyListeners();
		}
	}
}