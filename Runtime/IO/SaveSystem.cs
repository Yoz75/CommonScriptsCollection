using System;
using System.Collections;
using UnityEngine;

namespace CSC.IO
{
    public class SaveSystem : MonoBehaviour
    {
        public const string StandardSaveSystemTag = "StandardSaveSystem";
        public event Action SaveRequired;
        [SerializeField] private float TimeBetweenSaves;

        private void Start()
        {
            StartCoroutine(SaveTimout());
        }

        private IEnumerator SaveTimout()
        {
            while(true)
            {
                yield return new WaitForSecondsRealtime(TimeBetweenSaves);
                SaveRequired?.Invoke();
            }
        }
    }
}