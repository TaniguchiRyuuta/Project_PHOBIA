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
            if (target == null) return;

            target.gameObject.GetComponent<EventBehaviour>()?.OnInputAction(state);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
            {
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