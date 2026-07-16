using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJ_PHOBIA
{
    public class PlayerAction : MonoBehaviour
    {
        private Collider intaractButton;
        [SerializeField] EventBehaviour[] rightHandActions;

        private void Update()
        {
            InputAction();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("IntarctButton"))
            {
                intaractButton = other.GetComponent<Collider>();
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("IntarctButton"))
            {
                intaractButton = null;
            }
        }
        private void InputAction()
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                if (intaractButton != null) 
                InputActionEvent(intaractButton, InputButton.PrimaryIndexTrigger);
            }
            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
            {
                if (intaractButton != null) 
                InputActionEvent(intaractButton, InputButton.PrimaryHandTrigger);
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
        private void InputActionEvent(Collider other, InputButton input)
        {
            switch (input)
            {
                case InputButton.PrimaryIndexTrigger:
                    other.transform.GetComponent<EventBehaviour>()?.OnInputAction(input);
                    break;
            }
        }
        
    }
    public enum InputButton
    {
        PrimaryIndexTrigger,
        PrimaryHandTrigger,
        SecondaryIndexTrigger,
        SecondaryHandTrigger
    }
}