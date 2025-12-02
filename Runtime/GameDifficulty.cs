using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CSC
{
    [Serializable]
    public struct DifficultyStage
    {
        public float StageTime;
        public float DifficultyMultiplier;
    }
    
    /// <summary>
    /// Kostyl that easilty allows you to make game difficulty.
    /// </summary>
    public class GameDifficulty : MonoBehaviour
    {
        [SerializeField] private bool IsStartCounterAtAwake;
        [SerializeField] private List<DifficultyStage> Stages;

        private float CurrentMultiplier;

        public static GameDifficulty Instance { get; private set; }

        public float Difficuly
        {
            get
            {
                return CurrentMultiplier;
            }
        }

        /// <summary>
        /// Start difficulty coutner
        /// </summary>
        public void StartCounter()
        {

            StartCoroutine(ChangeCoroutine());
        }

        private void Awake()
        {
            Instance = this;
            CurrentMultiplier = Stages[0].DifficultyMultiplier;
            if(IsStartCounterAtAwake) StartCounter();
        }

        private IEnumerator ChangeCoroutine()
        {
            foreach(var stage in Stages)
            {
                CurrentMultiplier = stage.DifficultyMultiplier;

                yield return new WaitForSeconds(stage.StageTime);
            }
        }
    }
}