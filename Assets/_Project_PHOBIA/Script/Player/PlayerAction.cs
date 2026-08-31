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
                InvokeInteractEvent(InputButton.PrimaryIndexTriggerDown);
            }
            if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
            {
                InvokeInteractEvent(InputButton.PrimaryIndexTriggerUp);
            }
            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger))
            {
                InvokeInteractEvent(InputButton.PrimaryHandTriggerDown);
            }
            if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger))
            {
                InvokeInteractEvent(InputButton.PrimaryHandTriggerUp);
            }
            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                InvokeInteractEvent(InputButton.SecondaryIndexTriggerDown);
            }
            if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
            {
                InvokeInteractEvent(InputButton.SecondaryIndexTriggerUp);
            }
            if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
            {
                InvokeInteractEvent(InputButton.SecondaryHandTriggerDown);
            }
            if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger))
            {
                InvokeInteractEvent(InputButton.SecondaryHandTriggerUp);
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
                case InputButton.PrimaryIndexTriggerDown:
                    handAction.OnInputAction(input);
                    break;
                case InputButton.PrimaryIndexTriggerUp:
                    handAction.OnInputAction(input);
                    break;
                case InputButton.PrimaryHandTriggerDown:
                    handAction.OnInputAction(input);
                    break;
                case InputButton.PrimaryHandTriggerUp:
                    handAction.OnInputAction(input);
                    break;
                case InputButton.SecondaryIndexTriggerDown: 
                    handAction.OnInputAction(input);
                    break;
                case InputButton.SecondaryIndexTriggerUp:
                    handAction.OnInputAction(input);
                    break;
                case InputButton.SecondaryHandTriggerDown: 
                    handAction.OnInputAction(input);
                    break;
                case InputButton.SecondaryHandTriggerUp:
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
        PrimaryIndexTriggerDown,
        PrimaryIndexTriggerUp,
        PrimaryHandTriggerDown,
        PrimaryHandTriggerUp,
        SecondaryIndexTriggerDown,
        SecondaryIndexTriggerUp,
        SecondaryHandTriggerDown,
        SecondaryHandTriggerUp,
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