using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CSC._3D
{
    /// <summary>
    /// Activates trigger when an object from list enters it.
    /// </summary>
    [RequireComponent(typeof(BoxCollider))]
    public class WhitelistTrigger : MonoBehaviour, ITrigger
    {
        [SerializeField] private UnityEvent ObjectEnterTrigger;

        [Tooltip("Activate trigger if one of these objects entered it")]
        [SerializeField] private List<GameObject> TriggeredObjects;

        private BoxCollider Collider;

        public void AddListener(UnityAction action)
        {
            ObjectEnterTrigger.AddListener(action);
        }

        private void Start()
        {
            Collider = GetComponent<BoxCollider>();

            Collider.isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(TriggeredObjects.Contains(other.gameObject))
            {
                ObjectEnterTrigger?.Invoke();
            }
        }
    }
}