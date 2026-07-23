using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJ_PHOBIA
{
    public class PlayerAction : MonoBehaviour
    {
        private Collider interactButton;
        [SerializeField] EventBehaviour[] rightHandActions;

        private void Update()
        {
            InputAction();
        }
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("[PlayerAction] ê⁄êG");
            ActionTriggerEvent(other,TriggerState.Enter);
            if (other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
            {
                Debug.Log("[PlayerAction] [{gameObject.name}] InteractButtonÇ…ê⁄êG");
                interactButton = other.GetComponent<Collider>();
            }
        }
        private void OnTriggerStay(Collider other)
        {
            ActionTriggerEvent(other, TriggerState.Stay);
        }
        private void OnTriggerExit(Collider other)
        {
            Debug.Log("[PlayerAction] ó£íE");
            ActionTriggerEvent(other, TriggerState.Exit);
            if (other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
            {
                Debug.Log("[PlayerAction] [{gameObject.name}] InteractButtonÇ©ÇÁó£ÇÍÇΩ");
                interactButton = null;
            }
        }
        private void InputAction()
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                if (interactButton != null)
                    InvokeInteractEvent(interactButton, InputButton.PrimaryIndexTrigger);
            }
            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
            {
                if (interactButton != null)
                    InvokeInteractEvent(interactButton, InputButton.PrimaryHandTrigger);
            }
            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                if(rightHandActions != null)
                    foreach (var action in rightHandActions)
                    {
                        action.OnEvent();
                    }
            }
        }
        private void InvokeInteractEvent(Collider other, InputButton input)
        {
            switch (input)
            {
                case InputButton.PrimaryIndexTrigger:
                    other.transform.GetComponent<EventBehaviour>()?.OnInputAction(input);
                    break;
                case InputButton.PrimaryHandTrigger:
                    break;
            }
        }
        
        private void ActionTriggerEvent(Collider other , TriggerState state)
        {
            if(other.gameObject.layer == LayerMask.NameToLayer("Player")) return;

            switch(state)
            {
                case TriggerState.Enter:
                    other.transform.GetComponent<EventBehaviour>()?.OnPlayerTrigger(state);
                    break;
                case TriggerState.Stay:

                    break;

                case TriggerState.Exit:
                    other.transform.GetComponent<EventBehaviour>()?.OnPlayerTrigger(state);
                    break;
            }
        }
    }
    public enum InputButton
    {
        PrimaryIndexTrigger,
        PrimaryHandTrigger,
        SecondaryIndexTrigger,
        SecondaryHandTrigger,
    }
    public enum TriggerState
    {
        Enter,
        Stay,
        Exit,
    }
}