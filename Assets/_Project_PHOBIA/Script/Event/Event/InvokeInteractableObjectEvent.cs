using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJ_PHOBIA
{
    public class InvokeInteractableObjectEvent : EventBehaviour
    {
        private Collider target;
        public override void OnEvent()
        {
            if (target == null) return;
            
            target.gameObject.GetComponent<EventBehaviour>()?.OnEvent();
        }

        public override void OnInputAction(InputButton state)
        {
            Debug.Log("[InvokeInteractableObjectEvent] target:" + target);
            if (target == null) return;
            Debug.Log("[InvokeInteractableObjectEvent] OnInputAction:"+state);
            target.gameObject.GetComponent<EventBehaviour>()?.OnInputAction(state);
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("[InvokeInteractableObjectEvent] ê⁄êG");
            if (other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
            {
                Debug.Log("[InvokeInteractableObjectEvent] Interactableê⁄êG");
                target = other;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
            {
                target = null;
            }
        }
    }
}