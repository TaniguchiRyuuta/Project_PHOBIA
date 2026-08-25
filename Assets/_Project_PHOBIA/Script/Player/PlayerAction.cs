using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJ_PHOBIA
{
    public class PlayerAction : MonoBehaviour
    {
        [SerializeField] EventBehaviour handAction;

        private void Update()
        {
            InputAction();
        }
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("[PlayerAction] ê⁄êG");
            ActionTriggerEvent(other,TriggerState.Enter);
        }
        private void OnTriggerStay(Collider other)
        {
            ActionTriggerEvent(other, TriggerState.Stay);
        }
        private void OnTriggerExit(Collider other)
        {
            Debug.Log("[PlayerAction] ó£íE");
            ActionTriggerEvent(other, TriggerState.Exit);
        }
        private void InputAction()
        {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                InvokeInteractEvent(InputButton.PrimaryIndexTrigger);
            }
            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
            {
                InvokeInteractEvent(InputButton.PrimaryHandTrigger);
            }
            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                InvokeInteractEvent(InputButton.SecondaryIndexTrigger);
            }
            if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
            {
                InvokeInteractEvent(InputButton.SecondaryHandTrigger);
            }
            if (OVRInput.GetDown(OVRInput.RawButton.A))
            {
                InvokeInteractEvent(InputButton.A);
            }
            if (OVRInput.GetDown(OVRInput.RawButton.B))
            {
                InvokeInteractEvent(InputButton.B);
            }
            if (OVRInput.GetDown(OVRInput.RawButton.X))
            {
                InvokeInteractEvent(InputButton.X);
            }
            if (OVRInput.GetDown(OVRInput.RawButton.Y))
            {
                InvokeInteractEvent(InputButton.Y);
            }
        }
        private void InvokeInteractEvent(InputButton input)
        {
            switch (input)
            {
                case InputButton.PrimaryIndexTrigger:
                    handAction.OnInputAction(input);
                    break;
                case InputButton.PrimaryHandTrigger:
                    handAction.OnInputAction(input);
                    break;
                case InputButton.SecondaryIndexTrigger: 
                    handAction.OnInputAction(input);
                    break;
                case InputButton.SecondaryHandTrigger: 
                    handAction.OnInputAction(input);
                    break;
                case InputButton.A:
                    handAction.OnInputAction(input);
                    break;
                case InputButton.B:
                    handAction.OnInputAction(input);
                    break;
                case InputButton.X:
                    handAction.OnInputAction(input);
                    break;
                case InputButton.Y:
                    handAction.OnInputAction(input);
                    break;
                default:
                    Debug.LogWarning("[PlayerAction] [InvokeInteractEvent]ñ¢íËã`ÇÃì¸óÕÇ≈Ç∑");
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
        A,
        B,
        X,
        Y,
    }
    public enum TriggerState
    {
        Enter,
        Stay,
        Exit,
    }
}