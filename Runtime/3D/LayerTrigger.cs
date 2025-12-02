
using UnityEngine;
using UnityEngine.Events;

namespace CSC._3D
{
    public class LayerTrigger : MonoBehaviour
    {
        [SerializeField] private UnityEvent ObjectEnterTrigger;

        [Tooltip("Activate trigger if object with such layer entered it")]
        [SerializeField] private int TriggeredLayer;

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
            if(other.gameObject.layer == TriggeredLayer)
            {
                ObjectEnterTrigger?.Invoke();
            }
        }
    }
}