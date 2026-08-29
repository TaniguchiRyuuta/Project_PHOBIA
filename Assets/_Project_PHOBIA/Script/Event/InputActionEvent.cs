using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJ_PHOBIA
{
    public class InputActionEvent : EventBehaviour
    {
        [SerializeField] private EventBehaviour[] primaryIndexTriggerActions;
        [SerializeField] private EventBehaviour[] primaryHandTriggerActions;
        [SerializeField] private EventBehaviour[] secondaryIndexTriggerActions;
        [SerializeField] private EventBehaviour[] secondaryHandTriggerActions;
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
                    Debug.Log("[inputActionEvent] PrimaryIndexTrigger");
                    Debug.Log("[inputActionEvent] "+primaryIndexTriggerActions.Length);
                    if (primaryIndexTriggerActions != null && primaryIndexTriggerActions.Length > 0)
                        foreach (var action in primaryIndexTriggerActions)
                        {
                            if (action)
                                action.OnEvent();
                            action?.OnInputAction(state);
                        }
                    if (onlyOnce)col.enabled = false;
                    break;
                case InputButton.PrimaryHandTriggerDown:
                    Debug.Log("[inputActionEvent] PrimaryHandTrigger");
                    if (primaryHandTriggerActions != null && primaryHandTriggerActions.Length > 0)
                        foreach (var action in primaryHandTriggerActions)
                        {
                            if (action)
                                action.OnEvent();
                            action?.OnInputAction(state);
                        }
                    if (onlyOnce) col.enabled = false;
                    break ;
                case InputButton.SecondaryIndexTriggerDown:
                    Debug.Log("[inputActionEvent] SecondaryIndexTrigger");
                    if (secondaryIndexTriggerActions != null && secondaryIndexTriggerActions.Length > 0)
                        foreach (var action in secondaryIndexTriggerActions)
                        {
                            if (action)
                                action.OnEvent();
                            action?.OnInputAction(state);
                        }
                    if (onlyOnce) col.enabled = false;
                    break ;
                case InputButton.SecondaryHandTriggerDown:
                    Debug.Log("[inputActionEvent] SecondaryHandTrigger");
                    if (secondaryHandTriggerActions != null && secondaryHandTriggerActions.Length > 0)
                        foreach (var action in secondaryHandTriggerActions)
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