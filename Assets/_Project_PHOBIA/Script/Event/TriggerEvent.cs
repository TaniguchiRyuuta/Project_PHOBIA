using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJ_PHOBIA
{
    public class TriggerEvent : EventBehaviour
    {
        [SerializeField] private EventBehaviour[] enterActions;
        //[SerializeField] private EventBehaviour[] stayActions; //使用機会が少ないためコメントアウト
        [SerializeField] private EventBehaviour[] exitActions;
        [SerializeField] private bool onlyOnce = false;
        private Collider col;
        public override void OnPlayerTrigger(TriggerState state)
        {
            if (!col) col = GetComponent<Collider>();
            switch (state)
            {
                case TriggerState.Enter:
                    if (enterActions != null && enterActions.Length > 0)
                        foreach (var action in enterActions)
                            if (action)
                                action.OnEvent();
                    break;
                case TriggerState.Stay:
                    break;
                case TriggerState.Exit:
                    if (exitActions != null && exitActions.Length > 0)
                        foreach (var action in exitActions)
                            if (action)
                                action.OnEvent();
                    break;
            }
            if (onlyOnce) col.enabled = false;
        }
    }
}