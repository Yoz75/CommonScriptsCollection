using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

namespace CSC._2D
{
	[RequireComponent(typeof(BoxCollider2D))]
	public class Trigger2D: MonoBehaviour, ITrigger
	{
		[SerializeField] private UnityEvent ObjectEnterTrigger;
		
		[Tooltip("Activate trigger if one of these objects entered it")]
        [SerializeField] private List<GameObject> TriggeredObjects;
		
		private BoxCollider2D Collider;
		
		private void Start()
		{
			Collider = GetComponent<BoxCollider2D>();
			Collider.isTrigger = true;
		}
		
        public void AddListener(UnityAction action)
        {
            ObjectEnterTrigger.AddListener(action);
        }
		
		private void OnTriggerEnter2D(Collider2D other)
        {
            if(TriggeredObjects.Contains(other.gameObject))
            {
                ObjectEnterTrigger?.Invoke();
            }
        }
	}
}