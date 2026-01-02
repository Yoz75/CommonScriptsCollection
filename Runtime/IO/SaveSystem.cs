using System;
using System.Collections;
using UnityEngine;

namespace CSC.IO
{
    public abstract class SaveSystem : MonoBehaviour
    {
        public const string StandardSaveSystemTag = "StandardSaveSystem";
        public event Action SaveRequired;

        protected void NotifyListeners()
        {            
            SaveRequired?.Invoke();            
        }
    }
}