using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJ_PHOBIA
{
    public class PlayerAction : MonoBehaviour
    {
        private Collider intaractButton;

        private void Update()
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                if (intaractButton == null) return;
                InputActionEvent(intaractButton, InputButton.PrimaryIndexTrigger);
            }
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
        private void InputActionEvent(Collider other, InputButton input)
        {
            switch (input)
            {
                case InputButton.PrimaryIndexTrigger:
                    other.transform.GetComponent<EventBehaviour>()?.OnInputTrigger(input);
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