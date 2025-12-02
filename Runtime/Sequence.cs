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
        [SerializeField] private List<SequenceItem> Items;

        public void Play()
        {
            StartCoroutine(PlayCoroutine());
        }

        private IEnumerator PlayCoroutine()
        {
            foreach(var item in Items)
            {
                item.Event?.Invoke();

                yield return new WaitForSeconds(item.Delay);
            }
        }
    }
}