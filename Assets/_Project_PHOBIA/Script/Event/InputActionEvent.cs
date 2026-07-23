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
        [SerializeField] private bool onlyOnce = false;
        Collider col;
        public override void OnInputAction(InputButton state)
        {
            switch (state)
            {
                case InputButton.PrimaryIndexTrigger:
                    Debug.Log("[inputActionEvent] PrimaryIndexTrigger");
                    if (primaryIndexTriggerActions != null && primaryIndexTriggerActions.Length > 0)
                        foreach (var action in primaryIndexTriggerActions)
                            if (action)
                                action.OnEvent();
                    if(onlyOnce)col.enabled = false;
                    break;
                case InputButton.PrimaryHandTrigger:
                    Debug.Log("[inputActionEvent] PrimaryHandTrigger");
                    if (primaryHandTriggerActions != null && primaryHandTriggerActions.Length > 0)
                        foreach (var action in primaryHandTriggerActions)
                            if (action)
                                action.OnEvent();
                    if (onlyOnce) col.enabled = false;
                    break ;
                case InputButton.SecondaryIndexTrigger:
                    Debug.Log("[inputActionEvent] SecondaryIndexTrigger");
                    if (secondaryIndexTriggerActions != null && secondaryIndexTriggerActions.Length > 0)
                        foreach (var action in secondaryIndexTriggerActions)
                            if (action)
                                action.OnEvent();
                    if (onlyOnce) col.enabled = false;
                    break ;
                case InputButton.SecondaryHandTrigger:
                    Debug.Log("[inputActionEvent] SecondaryHandTrigger");
                    if (secondaryHandTriggerActions != null && secondaryHandTriggerActions.Length > 0)
                        foreach (var action in secondaryHandTriggerActions)
                            if (action)
                                action.OnEvent();
                    if (onlyOnce) col.enabled = false;
                    break;
                default:
                    Debug.LogWarning("[inputActionEvent] –¢’è‹`‚Ì“ü—Í‚Å‚·");
                    break;
            }
        }
    }
}