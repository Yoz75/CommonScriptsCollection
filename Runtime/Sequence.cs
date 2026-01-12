using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CSC
{
    [Serializable]
    public struct SequenceItem
    {
        public UnityEvent Event;
        public float Delay;
    }

    public class Sequence : MonoBehaviour
    {
        public bool IsPlaying
        {
            get; private set; 
        }

        [SerializeField] private List<SequenceItem> Items;

        public void Play()
        {
            StartCoroutine(PlayCoroutine());
        }

        private IEnumerator PlayCoroutine()
        {
            IsPlaying = true;

            foreach(var item in Items)
            {
                item.Event?.Invoke();

                yield return new WaitForSeconds(item.Delay);
            }

            IsPlaying = false;
        }
    }
}