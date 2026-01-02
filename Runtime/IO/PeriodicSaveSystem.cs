using System;
using System.Collections;
using UnityEngine;

namespace CSC.IO
{
    public class PeriodicSaveSystem : SaveSystem
    {
        [SerializeField] private float TimeBetweenSaves;

        private void Start()
        {
            StartCoroutine(SaveTimout());
        }

        private IEnumerator SaveTimout()
        {
            while(true)
            {
                NotifyListeners();
            }
        }
    }
}