using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJ_PHOBIA
{
    public class InputActionEvent : EventBehaviour
    {
        [SerializeField] private EventBehaviour[] indexTriggerActions;
        [SerializeField] private EventBehaviour[] handTriggerActions;
        [SerializeField] private bool onlyOnce = false;
        Collider col;
        public override void OnInputAction(InputButton state)
        {
            switch (state)
            {
                case InputButton.PrimaryIndexTrigger:
                    Debug.Log("[inputActionEvent] PrimaryIndexTrigger");
                    if (indexTriggerActions != null && indexTriggerActions.Length > 0)
                        foreach (var action in indexTriggerActions)
                            if (action)
                                action.OnEvent();
                    if(onlyOnce)col.enabled = false;
                    break;
                case InputButton.PrimaryHandTrigger:
                    Debug.Log("[inputActionEvent] PrimaryHandTrigger");
                    if (handTriggerActions != null && handTriggerActions.Length > 0)
                        foreach (var action in handTriggerActions)
                            if (action)
                                action.OnEvent();
                    if (onlyOnce) col.enabled = false;
                    break ;
            }
        }
    }
}