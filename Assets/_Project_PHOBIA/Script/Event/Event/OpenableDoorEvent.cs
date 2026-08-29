using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PJ_PHOBIA
{
    public class OpenableDoorEvent : EventBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private Transform target;
        private bool isOpen = false;

        public override void OnInputAction(InputButton state)
        {
            if(state == InputButton.PrimaryIndexTriggerDown ||
               state == InputButton.SecondaryIndexTriggerDown)
            {

            }
        }
    }
}