using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJ_PHOBIA
{
    public class InvokeEvents : EventBehaviour
    {
        [SerializeField] private EventBehaviour[] actions;

        public override void OnEvent()
        {
            if (actions != null && actions.Length >0)
            {
                foreach (var action in actions)
                    if(action)
                        action.OnEvent();
            }
        }
    }
}