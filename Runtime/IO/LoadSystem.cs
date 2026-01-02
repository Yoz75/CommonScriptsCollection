using System;
using UnityEngine;

namespace CSC.IO
{
    /// <summary>
    /// class that notifies listeners that they need to load
    /// </summary>
    public abstract class LoadSystem : MonoBehaviour
    {
        public const string StandardLoadSystemTag = "StandardLoadSystem";
        public event Action LoadRequired;

        protected void NotifyListeners() => LoadRequired?.Invoke();
    }
}
