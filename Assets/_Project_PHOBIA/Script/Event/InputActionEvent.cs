using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJ_PHOBIA
{
    public class InputActionEvent : EventBehaviour
    {
        [SerializeField] private EventBehaviour[] primaryIndexTriggerDownActions;
        [SerializeField] private EventBehaviour[] primaryIndexTriggerUpActions;
        [SerializeField] private EventBehaviour[] primaryHandTriggerDownActions;
        [SerializeField] private EventBehaviour[] primaryHandTriggerUpActions;
        [SerializeField] private EventBehaviour[] secondaryIndexTriggerDownActions;
        [SerializeField] private EventBehaviour[] secondaryIndexTriggerUpActions;
        [SerializeField] private EventBehaviour[] secondaryHandTriggerDownActions;
        [SerializeField] private EventBehaviour[] secondaryHandTriggerUpActions;
        [SerializeField] private EventBehaviour[] aButtonActions;
        [SerializeField] private EventBehaviour[] bButtonActions;
        [SerializeField] private EventBehaviour[] xButtonActions;
        [SerializeField] private EventBehaviour[] yButtonActions;
        [SerializeField] private bool onlyOnce = false;
        Collider col;

        private void Awake()
        {
            if(onlyOnce) col = this.GetComponent<Collider>();
        }
        public override void OnInputAction(InputButton state)
        {
            switch (state)
            {
                case InputButton.PrimaryIndexTriggerDown:
                    Debug.Log("[inputActionEvent] PrimaryIndexTriggerDown");
                    if (primaryIndexTriggerDownActions != null && primaryIndexTriggerDownActions.Length > 0)
                        foreach (var action in primaryIndexTriggerDownActions)
                        {
                            if (action)
                                action.OnEvent();
                            action?.OnInputAction(state);
                        }
                    if (onlyOnce)col.enabled = false;
                    break;
                case InputButton.PrimaryIndexTriggerUp:
                    Debug.Log("[inputActionEvent] PrimaryIndexTriggerUp");
                    if (primaryIndexTriggerUpActions != null && primaryIndexTriggerUpActions.Length > 0)
                        foreach (var action in primaryIndexTriggerUpActions)
                        {
                            if (action)
                                action.OnEvent();
                            action?.OnInputAction(state);
                        }
                    if (onlyOnce) col.enabled = false;
                    break;
                case InputButton.PrimaryHandTriggerDown:
                    Debug.Log("[inputActionEvent] PrimaryHandTriggerDown");
                    if (primaryHandTriggerDownActions != null && primaryHandTriggerDownActions.Length > 0)
                        foreach (var action in primaryHandTriggerDownActions)
                        {
                            if (action)
                                action.OnEvent();
                            action?.OnInputAction(state);
                        }
                    if (onlyOnce) col.enabled = false;
                    break ;
                case InputButton.PrimaryHandTriggerUp:
                    Debug.Log("[inputActionEvent] PrimaryHandTriggerUp");
                    if (primaryHandTriggerUpActions != null && primaryHandTriggerUpActions.Length > 0)
                        foreach (var action in primaryHandTriggerUpActions)
                        {
                            if (action)
                                action.OnEvent();
                            action?.OnInputAction(state);
                        }
                    if (onlyOnce) col.enabled = false;
                    break;
                case InputButton.SecondaryIndexTriggerDown:
                    Debug.Log("[inputActionEvent] SecondaryIndexTriggerDown");
                    if (secondaryIndexTriggerDownActions != null && secondaryIndexTriggerDownActions.Length > 0)
                        foreach (var action in secondaryIndexTriggerDownActions)
                        {
                            if (action)
                                action.OnEvent();
                            action?.OnInputAction(state);
                        }
                    if (onlyOnce) col.enabled = false;
                    break ;
                case InputButton.SecondaryIndexTriggerUp:
                    Debug.Log("[inputActionEvent] SecondaryIndexTriggerUp");
                    if (secondaryIndexTriggerUpActions != null && secondaryIndexTriggerUpActions.Length > 0)
                        foreach (var action in secondaryIndexTriggerUpActions)
                        {
                            if (action)
                                action.OnEvent();
                            action?.OnInputAction(state);
                        }
                    if (onlyOnce) col.enabled = false;
                    break;
                case InputButton.SecondaryHandTriggerDown:
                    Debug.Log("[inputActionEvent] SecondaryHandTriggerDown");
                    if (secondaryHandTriggerDownActions != null && secondaryHandTriggerDownActions.Length > 0)
                        foreach (var action in secondaryHandTriggerDownActions)
                        {
                            if (action)
                                action.OnEvent();
                            action?.OnInputAction(state);
                        }
                    if (onlyOnce) col.enabled = false;
                    break;
                case InputButton.SecondaryHandTriggerUp:
                    Debug.Log("[inputActionEvent] SecondaryHandTriggerUp");
                    if (secondaryHandTriggerUpActions != null && secondaryHandTriggerUpActions.Length > 0)
                        foreach (var action in secondaryHandTriggerUpActions)
                        {
                            if (action)
                                action.OnEvent();
                            action?.OnInputAction(state);
                        }
                    if (onlyOnce) col.enabled = false;
                    break;
                case InputButton.A:
                    Debug.Log("[inputActionEvent] AButton");
                    if (aButtonActions != null && aButtonActions.Length > 0)
                        foreach (var action in aButtonActions)
                        {
                            if (action)
                                action.OnEvent();
                            action?.OnInputAction(state);
                        }
                    if (onlyOnce) col.enabled = false;
                    break;
                case InputButton.B:
                    Debug.Log("[inputActionEvent] BButton");
                    if (bButtonActions != null && bButtonActions.Length > 0)
                        foreach (var action in bButtonActions)
                        {
                            if (action)
                                action.OnEvent();
                            action?.OnInputAction(state);
                        }
                    if (onlyOnce) col.enabled = false;
                    break;
                case InputButton.X:
                    Debug.Log("[inputActionEvent] XButton");
                    if (xButtonActions != null && xButtonActions.Length > 0)
                        foreach (var action in xButtonActions)
                        {
                            if (action)
                                action.OnEvent();
                            action?.OnInputAction(state);
                        }
                    if (onlyOnce) col.enabled = false;
                    break;
                case InputButton.Y:
                    Debug.Log("[inputActionEvent] YButton");
                    if (yButtonActions != null && yButtonActions.Length > 0)
                        foreach (var action in yButtonActions)
                        {
                            if (action)
                                action.OnEvent();
                            action?.OnInputAction(state);
                        }
                    if (onlyOnce) col.enabled = false;
                    break;
                default:
                    Debug.LogWarning("[inputActionEvent] –¢’è‹`‚Ì“ü—Í‚Å‚·");
                    break;
            }
        }
    }
}